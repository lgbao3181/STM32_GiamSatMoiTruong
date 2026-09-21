/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2026 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "i2c.h"
#include "usart.h"
#include "gpio.h"

#include "aht20.h"
#include "lcd_i2c.h"

#include <stdio.h>
#include <string.h>


char buff[30];

uint8_t data_rx;


/* Private function prototypes -----------------------------------------------*/

void SystemClock_Config(void);








int main(void)
{
    HAL_Init();
    SystemClock_Config();

    MX_GPIO_Init();
    MX_I2C1_Init();
    MX_I2C2_Init();
    MX_USART1_UART_Init();




uint8_t init =AHT20_Init();
LCD_I2C_Init();
float temperature, humidity;
char buff[32];
uint8_t gas_do;
while (1)
{
    /* ================= Đọc cảm biến ================= */

    AHT20_Read(&temperature, &humidity);

    /* Đọc cảm biến khí gas tại GPIOA Pin 1 */
    gas_do = HAL_GPIO_ReadPin(GPIOA, GPIO_PIN_3);

    /* ================= LCD ================= */

    if (gas_do == GPIO_PIN_RESET)
    {
        LCD_I2C_Clear();

        LCD_I2C_Location(0, 0);
        LCD_I2C_Write_String("CANH BAO");

        LCD_I2C_Location(1, 0);
        LCD_I2C_Write_String("RO RI KHI GA");

        HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_SET);
    }
    else if (temperature > 35.0f)
    {
        LCD_I2C_Clear();

        LCD_I2C_Location(0, 0);
        LCD_I2C_Write_String("CANH BAO");

        LCD_I2C_Location(1, 0);
        LCD_I2C_Write_String("NHIET DO CAO");

        HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_SET);
    }
    else if (humidity > 95.0f)
    {
        LCD_I2C_Clear();

        LCD_I2C_Location(0, 0);
        LCD_I2C_Write_String("CANH BAO");

        LCD_I2C_Location(1, 0);
        LCD_I2C_Write_String("DO AM CAO");

        HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_SET);
    }
    else
    {
        HAL_GPIO_WritePin(GPIOA, GPIO_PIN_4, GPIO_PIN_RESET);

        LCD_I2C_Clear();

        /* ================= Dòng 1 ================= */

        LCD_I2C_Location(0, 0);
        sprintf(buff, "NHIET: %.2f C", temperature);
        LCD_I2C_Write_String(buff);

        /* ================= Dòng 2 ================= */

        LCD_I2C_Location(1, 0);
        sprintf(buff, "DO AM: %.2f %%", humidity);
        LCD_I2C_Write_String(buff);
    }

    /* ================= UART ================= */
uint8_t gas_detected = !gas_do;
    sprintf(buff,
            "@ T=%.2f H=%.2f G=%d &",
            temperature,
            humidity,
            gas_detected);

    HAL_UART_Transmit(
        &huart1,
        (uint8_t *)buff,
        strlen(buff),
        HAL_MAX_DELAY
    );

    /* ================= Delay ================= */

    HAL_Delay(1000);
}

}
  /* USER CODE END 3 */


/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_NONE;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_HSI;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}
#ifdef USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
