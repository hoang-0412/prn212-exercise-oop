using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public abstract class MediaItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        protected MediaItem(int id, string title, int publishYear)
        {
            Id = id;
            Title = title;
            PublishYear = publishYear;
        }
        public abstract decimal CalculateOverdueFee(int overdueDays);
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[ID: {Id}] {Title} ({PublishYear})");
        }
    }
}
