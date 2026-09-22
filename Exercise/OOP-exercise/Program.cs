using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<MediaItem> catalog = new List<MediaItem>
            {
                new Book(1, "Lập trình C# cơ bản & nâng cao", 2018, 450),
                new Book(2, "Thiết kế mẫu (Design Patterns)", 2021, 320),
                new EBook(3, "Kiến trúc Microservices", 2023, 12.5),
                new EBook(4, "Trí tuệ nhân tạo và Machine Learning", 2024, 25.8),
                new Book(5, "Cấu trúc dữ liệu & Giải thuật", 2015, 510)
            };

            while (true)
            {
                Console.WriteLine("QUẢN LÝ THƯ VIỆN (LIBRARY MANAGEMENT)");
                Console.WriteLine("1. Add a book (ebook)");
                Console.WriteLine("2. Show list");
                Console.WriteLine("3. Find a book by id");
                Console.WriteLine("4. Sort the list by year ascending");
                Console.WriteLine("5. Borrow a book by id");
                Console.WriteLine("6. Return a book by id");
                Console.WriteLine("0. Exit");
                Console.WriteLine("==================================================");
                Console.Write("Enter your choice (0-6): ");

                string? choice = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddBook(catalog);
                        break;
                    case "2":
                        ShowList(catalog);
                        break;
                    case "3":
                        FindBookById(catalog);
                        break;
                    case "4":
                        SortListByYear(catalog);
                        break;
                    case "5":
                        BorrowBookById(catalog);
                        break;
                    case "6":
                        ReturnBookById(catalog);
                        break;
                    case "0":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình! Tạm biệt.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 0 đến 6.");
                        break;
                }
            }
        }

        // 1. Add a book (ebook)
        private static void AddBook(List<MediaItem> catalog)
        {
            Console.WriteLine("ADD A BOOK / EBOOK");
            Console.WriteLine("1. Paper Book (Sách in)");
            Console.WriteLine("2. E-Book (Sách điện tử)");
            Console.Write("Choose type (1 or 2): ");
            string? typeChoice = Console.ReadLine()?.Trim();
            if (typeChoice != "1" && typeChoice != "2")
            {
                Console.WriteLine("Loại sách không hợp lệ!");
                return;
            }

            int id;
            while (true)
            {
                Console.Write("Enter ID: ");
                if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                {
                    if (catalog.Any(x => x.Id == id))
                    {
                        Console.WriteLine($"ID {id} đã tồn tại trong hệ thống. Vui lòng nhập ID khác.");
                        continue;
                    }
                    break;
                }
                Console.WriteLine("ID phải là số nguyên dương hợp lệ!");
            }

            string title;
            while (true)
            {
                Console.Write("Enter Title: ");
                title = Console.ReadLine()?.Trim() ?? string.Empty;
                if (!string.IsNullOrEmpty(title))
                {
                    break;
                }
                Console.WriteLine("Tiêu đề không được để trống!");
            }

            int publishYear;
            while (true)
            {
                Console.Write("Enter Publish Year: ");
                if (int.TryParse(Console.ReadLine(), out publishYear) && publishYear > 0 && publishYear <= DateTime.Now.Year + 1)
                {
                    break;
                }
                Console.WriteLine($"Năm xuất bản không hợp lệ (1 - {DateTime.Now.Year + 1})!");
            }

            if (typeChoice == "1")
            {
                int numberOfPages;
                while (true)
                {
                    Console.Write("Enter Number of Pages: ");
                    if (int.TryParse(Console.ReadLine(), out numberOfPages) && numberOfPages > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Số trang phải là số nguyên dương!");
                }

                catalog.Add(new Book(id, title, publishYear, numberOfPages));
                Console.WriteLine($"Đã thêm sách in: \"{title}\" (ID: {id}) thành công!");
            }
            else
            {
                double fileSizeInMB;
                while (true)
                {
                    Console.Write("Enter File Size (MB): ");
                    if (double.TryParse(Console.ReadLine(), out fileSizeInMB) && fileSizeInMB > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Dung lượng file phải là số thực dương!");
                }

                catalog.Add(new EBook(id, title, publishYear, fileSizeInMB));
                Console.WriteLine($"Đã thêm E-Book: \"{title}\" (ID: {id}) thành công!");
            }
        }

        // 2. Show list
        private static void ShowList(List<MediaItem> catalog)
        {
            Console.WriteLine("SHOW LIST");
            if (catalog.Count == 0)
            {
                Console.WriteLine("Danh sách ấn phẩm hiện đang trống.");
                return;
            }

            Console.WriteLine($"Tổng số ấn phẩm: {catalog.Count}\n");
            for (int i = 0; i < catalog.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                catalog[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        // 3. Find a book by id
        private static void FindBookById(List<MediaItem> catalog)
        {
            Console.WriteLine("FIND A BOOK BY ID");
            Console.Write("Enter ID to find: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("[Lỗi] ID phải là số nguyên hợp lệ!");
                return;
            }

            var item = catalog.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Console.WriteLine($"Thông tin ấn phẩm ID {id}:");
                item.DisplayInfo();
            }
            else
            {
                Console.WriteLine($"Không có ấn phẩm nào với ID: {id}.");
            }
        }

        // 4. Sort the list by year ascending
        private static void SortListByYear(List<MediaItem> catalog)
        {
            Console.WriteLine("SORT LIST BY YEAR ASCENDING");
            if (catalog.Count == 0)
            {
                Console.WriteLine("Danh sách đang trống, không có dữ liệu để sắp xếp.");
                return;
            }

            catalog.Sort((a, b) => a.PublishYear.CompareTo(b.PublishYear));
            Console.WriteLine("Đã sắp xếp danh sách theo năm xuất bản tăng dần!\n");

            // Hiển thị danh sách ngay sau khi sắp xếp
            ShowList(catalog);
        }

        // 5. Borrow a book by id
        private static void BorrowBookById(List<MediaItem> catalog)
        {
            Console.WriteLine("BORROW A BOOK BY ID");
            Console.Write("Enter ID to borrow: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID phải là số nguyên hợp lệ!");
                return;
            }

            var item = catalog.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                Console.WriteLine($"Không có ấn phẩm nào với ID: {id}.");
                return;
            }

            if (item is IBorrowable borrowable)
            {
                borrowable.Borrow();
            }
            else
            {
                Console.WriteLine($"Ấn phẩm \"{item.Title}\" không hỗ trợ chức năng mượn.");
            }
        }

        // 6. Return a book by id
        private static void ReturnBookById(List<MediaItem> catalog)
        {
            Console.WriteLine("RETURN A BOOK BY ID");
            Console.Write("Enter ID to return: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID phải là số nguyên hợp lệ!");
                return;
            }

            var item = catalog.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                Console.WriteLine($"Không có ấn phẩm nào với ID: {id}.");
                return;
            }

            if (item is IBorrowable borrowable)
            {
                borrowable.Return();
            }
            else
            {
                Console.WriteLine($"Ấn phẩm \"{item.Title}\" không hỗ trợ chức năng trả.");
            }
        }
    }
}