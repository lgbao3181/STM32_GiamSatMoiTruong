#ifndef AHT20_H
#define AHT20_H

#include <stdint.h>

uint8_t AHT20_Init(void);
uint8_t AHT20_Read(float *Temperature, float *Humidity);

#endif