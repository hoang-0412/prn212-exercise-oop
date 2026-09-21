using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public class EBook : MediaItem, IBorrowable
    {
        public double FileSizeInMB { get; set; }
        public bool IsAvailable { get; private set; } = true;

        public EBook(int id, string title, int publishYear, double fileSizeInMB)
            : base(id, title, publishYear)
        {
            FileSizeInMB = fileSizeInMB;
        }

        // Phí phạt sách điện tử: 2,000 VND / ngày trễ hạn
        public override decimal CalculateOverdueFee(int overdueDays)
        {
            return overdueDays <= 0 ? 0 : overdueDays * 2000m;
        }

        public void Borrow()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"[Cảnh báo] Bản quyền E-Book \"{Title}\" đã hết lượt truy cập!");
                return;
            }
            IsAvailable = false;
            Console.WriteLine($"[Thành công] Đã mượn E-Book: \"{Title}\" (Cấp quyền đọc tải về).");
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"[Thành công] Đã hoàn trả giấy phép E-Book: \"{Title}\".");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Loại: E-Book | Dung lượng: {FileSizeInMB} MB | Bản quyền: {(IsAvailable ? "Khả dụng" : "Hết lượt")}");
        }
    }
}
