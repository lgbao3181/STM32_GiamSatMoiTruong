#include "lcd_i2c.h"

#include <stdio.h>
#include <string.h>

#include "stm32f1xx_hal.h"
#include "i2c.h"

#define LCD_I2C_ADDRESS    (0x27 << 1)


uint8_t LCD_I2C_Write_CMD(uint8_t data)
{
    uint8_t buf[4] =
    {
        (uint8_t)((data & 0xF0) | 0x0C),
        (uint8_t)((data & 0xF0) | 0x08),
        (uint8_t)((data << 4) | 0x0C),
        (uint8_t)((data << 4) | 0x08)
    };

    if (HAL_I2C_Master_Transmit(
            &hi2c1,
            LCD_I2C_ADDRESS,
            buf,
            4,
            HAL_MAX_DELAY) != HAL_OK)
    {
        return 0;
    }

    return 1;
}


uint8_t LCD_I2C_Write_DATA(uint8_t data)
{
    uint8_t buf[4] =
    {
        (uint8_t)((data & 0xF0) | 0x0D),
        (uint8_t)((data & 0xF0) | 0x09),
        (uint8_t)((data << 4) | 0x0D),
        (uint8_t)((data << 4) | 0x09)
    };

    if (HAL_I2C_Master_Transmit(
            &hi2c1,
            LCD_I2C_ADDRESS,
            buf,
            4,
            HAL_MAX_DELAY) != HAL_OK)
    {
        return 0;
    }

    return 1;
}


uint8_t LCD_I2C_Init(void)
{
    if (!LCD_I2C_Write_CMD(0x33))
        return 0;

    if (!LCD_I2C_Write_CMD(0x32))
        return 0;

    if (!LCD_I2C_Write_CMD(0x28))
        return 0;

    if (!LCD_I2C_Write_CMD(0x0C))
        return 0;

    if (!LCD_I2C_Write_CMD(0x01))
        return 0;

    if (!LCD_I2C_Write_CMD(0x06))
        return 0;

    HAL_Delay(2);

    return 1;
}


uint8_t LCD_I2C_Clear(void)
{
    if (!LCD_I2C_Write_CMD(0x01))
        return 0;

    HAL_Delay(2);

    return 1;
}


uint8_t LCD_I2C_Location(uint8_t x, uint8_t y)
{
    if (x == 0)
    {
        return LCD_I2C_Write_CMD(0x80 + y);
    }
    else if (x == 1)
    {
        return LCD_I2C_Write_CMD(0xC0 + y);
    }

    return 0;
}


uint8_t LCD_I2C_Write_String(char *string)
{
    if (string == NULL)
        return 0;

    for (uint8_t i = 0; i < strlen(string); i++)
    {
        if (!LCD_I2C_Write_DATA(string[i]))
            return 0;
    }

    return 1;
}


uint8_t LCD_I2C_Write_Number(float number)
{
    char buffer[16];

    snprintf(buffer, sizeof(buffer), "%.1f", number);

    return LCD_I2C_Write_String(buffer);
}


uint8_t degree_symbol[8] =
{
    0b00110,
    0b01001,
    0b01001,
    0b00110,
    0b00000,
    0b00000,
    0b00000,
    0b00000
};


uint8_t LCD_I2C_CreateCustomChar(uint8_t location, uint8_t charmap[])
{
    location &= 0x07;

    if (!LCD_I2C_Write_CMD(0x40 | (location << 3)))
        return 0;

    for (uint8_t i = 0; i < 8; i++)
    {
        if (!LCD_I2C_Write_DATA(charmap[i]))
            return 0;
    }

    return 1;
}