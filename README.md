# ESP32S3_Distance_SoftUART Project

![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
[![STM32](https://img.shields.io/badge/STM32-F103C8T6-blue)](https://www.st.com/en/microcontrollers-microprocessors/stm32f103c8.html)
[![CubeIDE](https://img.shields.io/badge/IDE-STM32CubeIDE-darkblue)](http://st.com/en/development-tools/stm32cubeide.html)
[![ESP8266](https://img.shields.io/badge/NodeMCU-ESP8266-orange)](https://www.espressif.com/en/products/socs/esp8266)

## Project Overview

An embedded distance measurement and monitoring system built around the ESP32-S3. The system uses a US-100 ultrasonic sensor to measure distance and communicates with a Windows application through a custom Software UART interface.

The ESP32-S3 handles sensor communication using its hardware UART while implementing a Software UART for communication with a PC. Distance measurements and command responses are transmitted using a custom data frame format with CRC16 (Modbus) for data integrity and error detection.

A C# WinForms application can be used as the PC-side interface to receive, display, and exchange data with the ESP32-S3 in real time.

The main objective of this project is to demonstrate practical embedded communication techniques, including hardware UART, Software UART, serial communication, custom data framing, CRC16 error checking, and MCU-to-PC communication.

## Video Demonstrations

https://github.com/user-attachments/assets/dbce4fbd-9232-4349-a6b2-657dd52cdb27

*Hardware Connection*

https://github.com/user-attachments/assets/ffbd0b4b-3688-4bb0-8ef7-bbc035a9ca31

*UART Output showing device connecting to wifi and getting ip address*

## Project Schematic

![schematic diagram](https://github.com/user-attachments/assets/6c5f4e55-692b-443c-bb82-c000e2a8ac29)

## Hardware Components

| Component                | Quantity | Purpose                                                                 |
| ------------------------ | -------- | ----------------------------------------------------------------------- |
| ESP32-S3                 | 1        | Main microcontroller running the application and Software UART          |
| US-100 Ultrasonic Sensor | 1        | Measures distance and communicates with ESP32-S3 via hardware UART      |
| USB-to-UART Converter    | 1        | Provides serial communication between ESP32-S3 Software UART and the PC |
| PC / Laptop              | 1        | Runs the C# WinForms application for monitoring and communication       |

## Pin Configuration

### US-100 to ESP32-S3 (Hardware UART)

| ESP32-S3 Pin | Function | US-100 Pin | Notes                                               |
| ------------ | -------- | ---------- | --------------------------------------------------- |
| **GPIO17**   | UART RX  | **TX**     | ESP32-S3 receives distance data from US-100         |
| **GPIO18**   | UART TX  | **RX**     | ESP32-S3 sends measurement command to US-100        |
| **GND**      | Ground   | **GND**    | **Must be connected!**                              |
| **5V / VCC** | Power    | **VCC**    | Supply according to the US-100 module specification |

### Software UART to PC

| ESP32-S3 Pin | Function         | USB-UART Converter | Purpose                            |
| ------------ | ---------------- | ------------------ | ---------------------------------- |
| **GPIO43**   | Software UART TX | **RX**             | ESP32-S3 sends distance data to PC |
| **GPIO44**   | Software UART RX | **TX**             | ESP32-S3 receives commands from PC |
| **GND**      | Ground           | **GND**            | **Must be connected!**             |


## ESP32-S3 Communication Architecture

### System Architecture

```text
┌─────────────────────┐
│   C# WinForms App   │
│  PC Monitoring UI   │
└──────────┬──────────┘
           │ Software UART
           │ @DATA:CRC&
           ▼
┌─────────────────────┐
│      ESP32-S3       │
│                     │
│ ┌─────────────────┐ │
│ │  Software UART  │ │
│ │   + CRC16       │ │
│ └────────┬────────┘ │
│          │          │
│ ┌────────▼────────┐ │
│ │  Hardware UART  │ │
│ └────────┬────────┘ │
└──────────┼──────────┘
           │ UART
           ▼
┌─────────────────────┐
│       US-100        │
│ Ultrasonic Sensor   │
└─────────────────────┘
```

### Communication Workflow

1. **Initialization**

   * Initialize the US-100 Hardware UART.
   * Configure the Software UART for PC communication.

2. **Distance Measurement**

   * Send `0x55` to the US-100.
   * Read and validate the 2-byte distance value.

3. **Data Transmission**

   * Calculate CRC16 (Modbus).
   * Send the measurement using `@DATA:CRC&`.

4. **PC Communication**

   * Receive and parse commands from the WinForms application.
   * Verify the received CRC.
   * Return the data or `CRC_FAIL`.

5. **Continuous Operation**

   * Measure distance periodically.
   * Handle PC communication concurrently during operation.

> **NOTE**: The Software UART operates at 9600 baud using 8N1 format. CRC16 (Modbus) is used to verify data integrity between the ESP32-S3 and the PC.


## Getting Started

### Software Prerequisites

| Software                 | Version | Purpose                                          |
| ------------------------ | ------- | ------------------------------------------------ |
| Arduino IDE / PlatformIO | Latest  | ESP32-S3 development and firmware flashing       |
| ESP32 Arduino Core       | Latest  | ESP32-S3 hardware and peripheral support         |
| C# / .NET WinForms       | .NET 6+ | PC-side monitoring and communication application |
| Serial Terminal          | Any     | Serial communication testing and debugging       |

### Hardware Setup

Before running the firmware, connect the components according to the **Pin Configuration** section:

* Connect the US-100 to GPIO17 (RX) and GPIO18 (TX) using the ESP32-S3 Hardware UART.
* Connect the USB-to-UART converter to GPIO43 (TX) and GPIO44 (RX) for Software UART communication with the PC.
* Make sure the ESP32-S3, US-100, and USB-to-UART converter share a common **GND**.
* Ensure the USB-to-UART converter uses a voltage level compatible with the ESP32-S3.

### Installation

1. Clone the repository:

```bash
git clone <repository-url>
cd ESP32S3_Distance_SoftUART
```

2. Open the project in **Arduino IDE or PlatformIO**.

3. Select the appropriate **ESP32-S3 board** and configure the correct USB/serial port.

4. Connect the US-100 and USB-to-UART converter according to the pin configuration.

5. Build and upload the firmware to the ESP32-S3.

6. Open the C# WinForms application and select the corresponding serial port.

7. Start the system. The ESP32-S3 will periodically measure distance from the US-100 and transmit the result using the `@DATA:CRC&` frame format.

### Communication Test

You can use a serial terminal or the WinForms application to verify communication. Send a valid frame to the ESP32-S3 and check whether the CRC is correctly validated and the expected response is returned.


## Resources

* [ESP32-S3 Datasheet](https://www.espressif.com/sites/default/files/documentation/esp32-s3_datasheet_en.pdf)
* [ESP32-S3 Technical Reference Manual](https://www.espressif.com/sites/default/files/documentation/esp32-s3_technical_reference_manual_en.pdf)
* [Arduino-ESP32 Documentation](https://docs.espressif.com/projects/arduino-esp32/en/latest/)
* [US-100 Ultrasonic Sensor Datasheet](https://www.mouser.com/datasheet/2/813/US-100-DS-1218130.pdf)
* [Microsoft .NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
* [Windows Forms Documentation](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
* [Modbus CRC16](https://www.modbustools.com/modbus_crc16.htm)


## Project Status

* **Status**: Complete
* **Version**: v1.0
* **Last Updated**: September 2026

## Contact

**Gia Bao**
📧 Email: *[your-email@example.com](mailto:your-email@example.com)*
🐙 GitHub: *your-github-profile*

