# Dự án STM32F103C8T6 – Giám sát nhiệt độ, độ ẩm và rò rỉ khí gas

![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)
![STM32F103C8T6](https://img.shields.io/badge/MCU-STM32F103C8T6-blue)
![STM32CubeMX](https://img.shields.io/badge/STM32-STM32CubeMX-green)
![PlatformIO](https://img.shields.io/badge/Build-PlatformIO-orange)
![I2C](https://img.shields.io/badge/Communication-I2C-lightgrey)
![UART](https://img.shields.io/badge/Communication-UART-green)
![.NET WinForms](https://img.shields.io/badge/PC%20App-.NET%20WinForms-darkblue)

## Giới thiệu

Đây là một dự án **Embedded Systems** sử dụng **STM32F103C8T6** làm vi điều khiển trung tâm để xây dựng hệ thống **giám sát nhiệt độ, độ ẩm và phát hiện rò rỉ khí gas**.

Firmware được phát triển bằng cách kết hợp **STM32CubeMX** để cấu hình phần cứng, ngoại vi và mã khởi tạo với **PlatformIO** để quản lý project, biên dịch và nạp firmware.

Hệ thống sử dụng:

* **AHT20** giao tiếp **I2C** để đo nhiệt độ và độ ẩm.
* **MQ-2** để phát hiện khí gas/khói và đưa tín hiệu cảnh báo về STM32.
* **LCD 16x2 giao tiếp I2C** để hiển thị nhiệt độ, độ ẩm và trạng thái cảnh báo.
* **Mạch chuyển mức logic 5V ↔ 3.3V** để bảo đảm tương thích mức điện áp giữa các thiết bị ngoại vi 5V và STM32F103C8T6.
* **Relay 5V** để điều khiển đèn cảnh báo **220V**.
* **UART** để truyền dữ liệu đo được từ STM32 lên PC.
* **Ứng dụng C# WinForms tự xây dựng** trên PC để hiển thị nhiệt độ, độ ẩm, trạng thái rò rỉ khí gas và đưa ra cảnh báo khi giá trị vượt ngưỡng cài đặt.

Mục tiêu của dự án là xây dựng một hệ thống giám sát thực tế, đồng thời thực hành các kỹ năng **STM32, I2C, ADC/GPIO, UART, điều khiển relay, xử lý ngưỡng cảnh báo và giao tiếp giữa MCU với phần mềm PC**.

---

## Video minh họa

[![Xem video](https://img.youtube.com/vi/TBA_9MDTWb8/hqdefault.jpg)](https://youtube.com/shorts/TBA_9MDTWb8)

---

## Sơ đồ nguyên lý

![Sơ đồ nguyên lý](demo/Schematic.svg)

Sơ đồ nguyên lý thể hiện các khối chức năng chính của hệ thống:

* **STM32F103C8T6**: MCU trung tâm, thực hiện đọc cảm biến, xử lý điều kiện cảnh báo, điều khiển LCD, relay và truyền dữ liệu UART.
* **AHT20**: cảm biến nhiệt độ và độ ẩm, giao tiếp với STM32 thông qua I2C.
* **LCD 16x2 + module I2C**: hiển thị thông tin đo được và trạng thái cảnh báo.
* **MQ-2**: cảm biến dùng để phát hiện khí gas/khói; tín hiệu từ module được đưa qua mạch chuyển mức phù hợp trước khi vào MCU.
* **Mạch chuyển mức 5V ↔ 3.3V**: chuyển đổi mức logic giữa các thiết bị ngoại vi và STM32F103C8T6, đặc biệt trên tuyến giao tiếp I2C và tín hiệu từ module MQ-2 và LCD 16x2 giao tiếp I2C.
* **Relay 5V**: nhận tín hiệu điều khiển từ mạch MCU để đóng cắt loa cảnh báo 220V.
* **USB–UART / UART**: cầu nối truyền dữ liệu giữa STM32 và PC.


## Thành phần phần cứng

| Thành phần | Số lượng | Vai trò |
| ------------------------------ | -------: | ----------------------------------------------- |
| STM32F103C8T6 | 1 | MCU trung tâm, xử lý dữ liệu và điều khiển hệ thống |
| AHT20 | 1 | Đo nhiệt độ và độ ẩm qua I2C |
| LCD 16x2 + module I2C | 1 | Hiển thị nhiệt độ, độ ẩm và cảnh báo |
| MQ-2 | 1 | Phát hiện khí gas/khói |
| Mạch chuyển mức 5V ↔ 3.3V | 1 | Tương thích mức logic giữa ngoại vi và STM32 |
| Relay 5V | 1 | Đóng/cắt tải cảnh báo |
| Đèn/tải 220V | 1 | Cảnh báo bằng tín hiệu đèn |
| USB–UART Converter | 1 | Cầu nối UART giữa STM32 và PC |
| PC / Laptop | 1 | Chạy ứng dụng WinForms để giám sát |

---

## Cấu hình giao tiếp và chân

> Một số chân GPIO phụ thuộc trực tiếp vào file cấu hình STM32CubeMX và project PlatformIO. Bảng dưới đây mô tả **chức năng giao tiếp**, còn số chân cụ thể nên lấy theo schematic/.ioc của phiên bản project đang sử dụng.

### AHT20 – STM32F103C8T6 (I2C)

| STM32 | Chức năng | AHT20 | Ghi chú |
| -------------------------------- | ------- | ----- | ------------------------------------------------ |
| GPIO PB10 | I2C Clock | SCL | Đường xung clock |
| GPIO PB11 | I2C Data | SDA | Đường dữ liệu |
| 3.3V | Nguồn | VCC | Cấp nguồn theo thiết kế |
| GND | Mass | GND | **Bắt buộc nối chung** |

### LCD 16x2 – Module I2C – STM32

| STM32 / Bus | Chức năng | LCD I2C | Ghi chú |
| ---------------- | --------- | ------- | ------------------------------------------ |
| GPIO PB6 | Data | SDA | Đi qua mạch chuyển mức vì LCD chạy ở điện áp 5V |
| GPIO PB7 | Clock | SCL | Đi qua mạch chuyển mức vì LCD chạy ở điện áp 5V |
| GND | Mass | GND | **Bắt buộc nối chung ở phía logic** |
| 5V | Nguồn LCD | VCC | Theo thiết kế phần cứng của module LCD |

### MQ-2 – STM32F103C8T6

| Tín hiệu | Chức năng | Kết nối MCU | Ghi chú |
| -------- | --------- | ----------- | ---------------------------------------------- |
| DO | Digital Output | GPIO PA3 | Dùng để xác định trạng thái cảnh báo gas, cần nối qua module chuyển mức đế ra tín hiệ 3.3V |
| VCC | Nguồn | 5V | Theo module MQ-2 |
| GND | Mass | GND | Nối chung với hệ thống |

> Vì MQ-2 module thường hoạt động ở mức 5V, cần bảo đảm tín hiệu đưa vào GPIO/ADC của STM32 không vượt quá mức điện áp cho phép (3.3V). Ở đây sử dụng mạch chuyển mức/giảm áp để chueyern tín hiệu 5V thành tín hiệu 3.3V đưa vào GPIO/ADC của STM32

### Relay 5V – STM32F103C8T6

| Tín hiệu | Chức năng | MCU | Ghi chú |
| -------- | --------- | --- | -------------------------------------------- |
| RELAY_CTRL | Điều khiển relay | GPIO PA4 | Điều khiển relay đóng ngắt đèn báo |
| VCC | Nguồn relay | 5V | Cấp nguồn theo module relay |
| GND | Mass | GND | Nối chung phía điều khiển |

Relay được sử dụng để đóng/cắt đèn cảnh báo **220V**.

> **Cảnh báo an toàn:** phần tải 220V phải được cách ly và đấu nối đúng kỹ thuật. Không thao tác phần điện lưới khi đang cấp điện; ưu tiên sử dụng hộp bảo vệ, cầu chì/bảo vệ quá dòng và khoảng cách cách điện phù hợp.

### UART – STM32 ↔ PC

| STM32 | Chức năng | USB–UART Converter | Mục đích |
| -------- | ------- | ------------------ | -------------------------------- |
| GPIO PA9 | Transmit | RX | STM32 gửi dữ liệu lên PC |
| GPIO PA10 | Receive | TX | STM32 nhận dữ liệu từ PC nếu cần |
| GND | Mass | GND | **Bắt buộc nối chung** |

---

## Hệ thống giám sát và cảnh báo — phần trọng tâm của dự án

Mỗi chu kỳ hoạt động, firmware thực hiện việc đọc dữ liệu từ cảm biến, cập nhật LCD, kiểm tra các điều kiện cảnh báo, điều khiển relay/đèn và truyền dữ liệu lên PC.

### 1. Đọc nhiệt độ và độ ẩm từ AHT20

AHT20 giao tiếp với STM32F103C8T6 thông qua **I2C**.

Firmware thực hiện:

1. Gửi lệnh đo tới AHT20.
2. Chờ cảm biến hoàn thành phép đo.
3. Đọc dữ liệu nhiệt độ và độ ẩm qua I2C.
4. Chuyển đổi dữ liệu sang giá trị nhiệt độ/độ ẩm để hiển thị và xử lý.

Các giá trị này được sử dụng đồng thời cho **LCD tại thiết bị** và **ứng dụng WinForms trên PC**.

### 2. Phát hiện rò rỉ khí gas bằng MQ-2

MQ-2 được sử dụng làm tín hiệu phát hiện khí gas/khói. Trong cấu hình sử dụng ngõ ra số, firmware đọc trạng thái **DO** thông qua GPIO.

Khi tín hiệu gas đạt trạng thái cảnh báo:

* LCD hiển thị thông báo **rò rỉ khí gas**.
* Hệ thống kích hoạt **đèn/tải 220V thông qua relay 5V**.
* Trạng thái gas được truyền lên PC.
* Ứng dụng WinForms hiển thị cảnh báo tương ứng.

> Ngưỡng phát hiện thực tế của MQ-2 phụ thuộc module, mạch, thời gian làm nóng và cách hiệu chỉnh cảm biến. Vì vậy trạng thái DO trong project nên được xem là **tín hiệu cảnh báo theo cấu hình phần cứng**, không phải một giá trị nồng độ ppm tuyệt đối nếu chưa có quy trình hiệu chuẩn.

### 3. Cảnh báo nhiệt độ vượt ngưỡng

Firmware có thể kiểm tra nhiệt độ đo được với giới hạn cài đặt trong chương trình.

Ví dụ:

```text
Nhiệt độ > giới hạn
        │
        ▼
   Kích hoạt cảnh báo
        │
   ┌────┴─────────────┐
   ▼                  ▼
LCD cảnh báo      Relay / đèn
```

Ngưỡng nhiệt độ nên được định nghĩa bằng hằng số/biến cấu hình để dễ thay đổi mà không phải sửa nhiều vị trí trong mã nguồn.

### 4. Hiển thị LCD 16x2

LCD được sử dụng để cung cấp thông tin trực tiếp tại thiết bị, giúp hệ thống có thể hoạt động mà không cần theo dõi PC liên tục.

Nội dung hiển thị được tổ chức theo các trạng thái:

```text
+----------------+
| T: 28.5 C      |
| H: 65.2 %      |
+----------------+
```

Khi có sự cố, LCD chuyển sang thông báo cảnh báo:

```text
+----------------+
| CANH BAO      |
| RO RI KHI GAS |
+----------------+
```

### 5. Điều khiển relay và đèn cảnh báo 220V

STM32 xuất tín hiệu điều khiển tới relay 5V. Relay đóng/cắt đèn cảnh báo ở phía điện áp cao.

Luồng điều khiển:

```text
Điều kiện cảnh báo
        │
        ▼
 STM32F103C8T6
        │
        ▼
 RELAY_CTRL(GPIO PB4)
        │
        ▼
   Relay 5V
        │
        ▼
   Đèn / tải 220V
```

Phần MCU chỉ xử lý tín hiệu điều khiển điện áp thấp; tải 220V phải được bố trí và cách ly phù hợp với thiết kế phần cứng.

### 6. Truyền dữ liệu UART lên PC

STM32 truyền dữ liệu giám sát tới ứng dụng WinForms thông qua UART.

Một khung dữ liệu có thể chứa các trường chính như:

```text
Temperature,Humidity,GasStatus,AlarmStatus
```

Ví dụ dữ liệu:

```text
28.5,65.2,0,0
```

Trong đó:

* `Temperature` — nhiệt độ hiện tại.
* `Humidity` — độ ẩm hiện tại.
* `GasStatus` — trạng thái phát hiện gas.
* `AlarmStatus` — trạng thái cảnh báo tổng.

> Định dạng thực tế cần đối chiếu với firmware hiện tại và chương trình WinForms của project.

---

## Ứng dụng WinForms trên PC

Ứng dụng **C# WinForms** được tự xây dựng để làm giao diện giám sát phía PC.

Các chức năng chính:

* Kết nối tới cổng COM của STM32 thông qua USB–UART.
* Nhận dữ liệu UART theo thời gian thực.
* Hiển thị **nhiệt độ**.
* Hiển thị **độ ẩm**.
* Hiển thị trạng thái **rò rỉ khí gas**.
* Hiển thị trạng thái **cảnh báo**.
* Cảnh báo khi nhiệt độ vượt ngưỡng.
* Cảnh báo khi hệ thống phát hiện rò rỉ khí gas.

Kiến trúc giao tiếp tổng quát:

```text
┌─────────────────────────┐
│      STM32F103C8T6      │
│                         │
│ AHT20 ── I2C ──┐        │
│ MQ-2 ── GPIO ──┤        │
│                │        │
│ LCD ── I2C ────┤        │
│ Relay ─ GPIO ──┤        │
│                │        │
│        UART ───┴────────┼────────┐
└─────────────────────────┘        │
                                   ▼
                        ┌──────────────────────┐
                        │      USB–UART        │
                        └──────────┬───────────┘
                                   │
                                   ▼
                        ┌──────────────────────┐
                        │    C# WinForms       │
                        │                      │
                        │ - Nhiệt độ           │
                        │ - Độ ẩm              │
                        │ - Rò rỉ khí gas      │
                        │ - Cảnh báo            │
                        └──────────────────────┘
```

---

## Kiến trúc hệ thống tổng quan

```text
                           ┌──────────────────────┐
                           │      PC / Laptop     │
                           │     C# WinForms      │
                           └──────────┬───────────┘
                                      │
                                      │ UART
                                      ▼
┌─────────────────────────────────────────────────────────┐
│                   STM32F103C8T6                         │
│                                                         │
│  ┌─────────────┐       ┌────────────────────────────┐  │
│  │    AHT20    │◄──I2C─┤ Đọc nhiệt độ + độ ẩm      │  │
│  └─────────────┘       └──────────────┬─────────────┘  │
│                                       │                │
│  ┌─────────────┐                      ▼                │
│  │    MQ-2     │──GPIO──►     Xử lý ngưỡng cảnh báo   │
│  └─────────────┘                      │                │
│                                       ├────► LCD 16x2 │
│  ┌─────────────┐                      │       (I2C)   │
│  │ Mạch chuyển │◄──── 5V ↔ 3.3V ────┤                │
│  │ mức logic   │                      ├────► Relay 5V │
│  └─────────────┘                      │                │
│                                       └────► UART ─────┼──► PC
└─────────────────────────────────────────────────────────┘
                                                  │
                                                  ▼
                                         ┌────────────────┐
                                         │  Đèn / tải     │
                                         │      220V      │
                                         └────────────────┘
```

### Quy trình hoạt động

1. **Khởi tạo:** STM32F103C8T6 khởi tạo GPIO, I2C, UART và các ngoại vi cần thiết.
2. **Đọc cảm biến:** STM32 đọc nhiệt độ và độ ẩm từ AHT20 qua I2C, đồng thời đọc trạng thái MQ-2.
3. **Xử lý dữ liệu:** firmware cập nhật các biến đo lường và kiểm tra các điều kiện cảnh báo.
4. **Hiển thị tại thiết bị:** LCD 16x2 hiển thị nhiệt độ, độ ẩm hoặc thông báo cảnh báo.
5. **Điều khiển cảnh báo:** khi điều kiện cảnh báo xảy ra, STM32 điều khiển relay 5V để kích hoạt đèn/tải 220V theo cấu hình.
6. **Truyền dữ liệu:** STM32 gửi dữ liệu giám sát lên PC thông qua UART.
7. **Giám sát trên PC:** ứng dụng WinForms nhận dữ liệu, cập nhật giao diện và đưa ra cảnh báo khi vượt giới hạn.

---

## Bắt đầu

### Yêu cầu phần mềm

| Phần mềm | Phiên bản | Mục đích |
| -------------------------------- | --------- | ----------------------------------------------- |
| STM32CubeMX | Theo phiên bản project | Cấu hình MCU, GPIO, I2C, UART và sinh mã khởi tạo |
| PlatformIO | Mới nhất | Quản lý project, biên dịch và nạp firmware |
| VS Code | Khuyến nghị | Môi trường phát triển cho PlatformIO |
| STM32Cube HAL | Theo project | Thư viện HAL sử dụng trong firmware |
| C# / .NET WinForms | Theo project | Phát triển ứng dụng giám sát trên PC |
| ST-LINK Utility / STM32CubeProgrammer | Theo môi trường sử dụng | Nạp và kiểm tra firmware |
| Serial Terminal | Bất kỳ | Kiểm thử UART và debug |

### Lắp phần cứng

* Kết nối **AHT20** với bus I2C của STM32.
* Kết nối **LCD 16x2 I2C** qua mạch chuyển mức logic nếu module hoạt động ở 5V.
* Kết nối **MQ-2** theo thiết kế; nếu tín hiệu đưa vào MCU là tín hiệu 5V thì phải chuyển mức/giảm áp về mức phù hợp với STM32.
* Kết nối **Relay 5V** với chân điều khiển của MCU thông qua mạch driver phù hợp với tải của relay.
* Kết nối tải/đèn **220V** vào tiếp điểm relay theo đúng thiết kế điện và yêu cầu an toàn.
* Kết nối **UART của STM32** với USB–UART Converter để giao tiếp với PC.
* Nối chung GND ở phía mạch logic theo thiết kế.

### Cài đặt

1. Sao chép repository:

```bash
git clone <repository-url>
cd <repository-folder>
```

2. Mở thư mục project bằng **Visual Studio Code + PlatformIO**.

3. Kiểm tra cấu hình trong `platformio.ini` và bảo đảm board STM32F103C8T6 đúng với project.

4. Đối chiếu cấu hình GPIO/I2C/UART với file cấu hình **STM32CubeMX** và schematic.

5. Biên dịch firmware:

```bash
pio run
```

6. Nạp firmware bằng ST-LINK hoặc phương thức upload được cấu hình trong `platformio.ini`:

```bash
pio run -t upload
```

7. Kết nối USB–UART với PC và xác định đúng cổng COM.

8. Mở ứng dụng WinForms.

9. Khởi động hệ thống và kiểm tra dữ liệu nhiệt độ, độ ẩm, trạng thái MQ-2 và cảnh báo.

### Kiểm thử hệ thống

Các nội dung cần kiểm tra:

* STM32F103C8T6 khởi động bình thường.
* AHT20 trả về dữ liệu nhiệt độ và độ ẩm hợp lệ.
* LCD 16x2 hiển thị đúng nội dung.
* Mạch chuyển mức 5V ↔ 3.3V hoạt động ổn định trên các đường tín hiệu cần thiết.
* MQ-2 thay đổi trạng thái khi xuất hiện điều kiện phát hiện khí theo cấu hình module.
* Relay 5V đóng/cắt đúng theo tín hiệu điều khiển.
* Đèn/tải 220V hoạt động đúng theo relay.
* UART truyền dữ liệu ổn định lên PC.
* WinForms nhận và hiển thị dữ liệu đúng.
* Cảnh báo xuất hiện khi nhiệt độ vượt ngưỡng đã cấu hình.
* Cảnh báo xuất hiện khi MQ-2 báo trạng thái gas.

---

## Cấu trúc project đề xuất

```text
.
├── firmware/
│   ├── include/
│   ├── lib/
│   ├── src/
│   ├── test/
│   └── platformio.ini
│
├── cube_mx/
│   └── *.ioc
│
├── pc_app/
│   └── WinForms project
│
├── demo/
│   ├── Schematic.svg
│   ├── PCB.svg
│   └── ...
│
└── README.md
```

> Cấu trúc trên mang tính mô tả; tên thư mục thực tế cần giữ đúng theo repository hiện tại của dự án.

---

## Tài liệu tham khảo

* [Datasheet STM32F103C8](https://www.st.com/resource/en/datasheet/stm32f103c8.pdf)
* [STM32CubeMX](https://www.st.com/en/development-tools/stm32cubemx.html)
* [PlatformIO Documentation](https://docs.platformio.org/)
* [AHT20 Datasheet](https://www.aosong.com/userfiles/files/media/AHT20%20datasheet%20Version-1.0.pdf)
* [Microsoft .NET](https://learn.microsoft.com/en-us/dotnet/)
* [Windows Forms](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)

---

## Trạng thái dự án

* **Trạng thái:** Hoàn thành
* **Phiên bản:** v1.0
* **Cập nhật lần cuối:** Tháng 9/2026

---

## Liên hệ

**Gia Bảo**

📧 Email: *[your-email@example.com](mailto:your-email@example.com)*  
🐙 GitHub: *your-github-profile*
