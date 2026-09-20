#ifndef LCD_I2C_H
#define LCD_I2C_H

#include <stdint.h>

uint8_t LCD_I2C_Init(void);

uint8_t LCD_I2C_Write_CMD(uint8_t data);
uint8_t LCD_I2C_Write_DATA(uint8_t data);

uint8_t LCD_I2C_Clear(void);
uint8_t LCD_I2C_Location(uint8_t x, uint8_t y);

uint8_t LCD_I2C_Write_String(char *string);
uint8_t LCD_I2C_Write_Number(float number);

uint8_t LCD_I2C_CreateCustomChar(uint8_t location, uint8_t charmap[]);

#endif