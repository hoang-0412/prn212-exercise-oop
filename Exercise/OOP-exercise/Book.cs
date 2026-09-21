using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public class Book : MediaItem, IBorrowable
    {
        public int NumberOfPages { get; set; }
        public bool IsAvailable { get; private set; } = true;

        public Book(int id, string title, int publishYear, int numberOfPages)
            : base(id, title, publishYear)
        {
            NumberOfPages = numberOfPages;
        }

        // Phí phạt sách in: 5,000 VND / ngày trễ hạn
        public override decimal CalculateOverdueFee(int overdueDays)
        {
            return overdueDays <= 0 ? 0 : overdueDays * 5000m;
        }

        public void Borrow()
        {
            if (!IsAvailable)
            {
                Console.WriteLine($"[Cảnh báo] Sách in \"{Title}\" hiện đang được mượn!");
                return;
            }
            IsAvailable = false;
            Console.WriteLine($"[Thành công] Đã mượn sách in: \"{Title}\".");
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"[Thành công] Đã trả sách in: \"{Title}\".");
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Loại: Sách in | Số trang: {NumberOfPages} | Tình trạng: {(IsAvailable ? "Có sẵn" : "Đang mượn")}");
        }
    }
}