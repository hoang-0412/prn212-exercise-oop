using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== HỆ THỐNG QUẢN LÝ THƯ VIỆN ĐIỆN TỬ (E-LIBRARY) ===\n");

            // 1. Tạo danh sách các ấn phẩm
            List<MediaItem> catalog = new List<MediaItem>
            {
                new Book(1, "Lập trình C# cơ bản & nâng cao", 2018, 450),
                new Book(2, "Thiết kế mẫu (Design Patterns)", 2021, 320),
                new EBook(3, "Kiến trúc Microservices", 2023, 12.5),
                new EBook(4, "Trí tuệ nhân tạo và Machine Learning", 2024, 25.8),
                new Book(5, "Cấu trúc dữ liệu & Giải thuật", 2015, 510)
            };

            // 2. Minh họa Đa hình (Polymorphism) & Tính phí trễ hạn
            Console.WriteLine("--- 1. DANH MỤC VÀ TÍNH PHÍ QUÁ HẠN (ĐA HÌNH) ---");
            int overdueDays = 5;
            foreach (var item in catalog)
            {
                item.DisplayInfo();
                decimal fee = item.CalculateOverdueFee(overdueDays);
                Console.WriteLine($"  => Phí quá hạn ({overdueDays} ngày): {fee:N0} VND\n");
            }

            // 3. Minh họa Mượn / Trả qua Interface IBorrowable
            Console.WriteLine("--- 2. THỰC HIỆN MƯỢN VÀ TRẢ SÁCH (INTERFACE) ---");
            if (catalog[0] is IBorrowable bookToBorrow)
            {
                bookToBorrow.Borrow();
                bookToBorrow.Borrow(); // Thử mượn lần 2 để kiểm tra validation
                bookToBorrow.Return();
            }

            Console.WriteLine();
            if (catalog[2] is IBorrowable ebookToBorrow)
            {
                ebookToBorrow.Borrow();
                ebookToBorrow.Return();
            }

            // 4. Lưu trữ và hiển thị LoanRecord
            Console.WriteLine("\n--- 3. LỊCH SỬ MƯỢN SÁCH (RECORD) ---");
            List<LoanRecord> loanHistory = new List<LoanRecord>
            {
                new LoanRecord(101, 1001, 1, DateTime.Now.AddDays(-10)),
                new LoanRecord(102, 1002, 3, DateTime.Now.AddDays(-3)),
                new LoanRecord(103, 1001, 4, DateTime.Now)
            };

            foreach (var record in loanHistory)
            {
                Console.WriteLine(record);
            }

            // 5. Sử dụng Extension Method để lọc ấn phẩm
            Console.WriteLine("\n--- 4. LỌC ẤN PHẨM XUẤT BẢN SAU NĂM 2020 (EXTENSION METHOD) ---");
            int filterYear = 2020;
            List<MediaItem> modernItems = catalog.GetItemsPublishedAfter(filterYear);

            Console.WriteLine($"Số ấn phẩm phát hành sau năm {filterYear}: {modernItems.Count}");
            foreach (var item in modernItems)
            {
                Console.WriteLine($"- [{item.PublishYear}] {item.Title}");
            }

            Console.WriteLine("\n=== HOÀN TẤT CHƯƠNG TRÌNH ===");
        }
    }
}