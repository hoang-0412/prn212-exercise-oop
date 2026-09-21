using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public static class MediaItemExtensions
    {
        public static List<MediaItem> GetItemsPublishedAfter(this List<MediaItem> items, int year)
        {
            if(items == null) return new List<MediaItem>();
            return items.Where(item => item.PublishYear > year).ToList();
        }
    }
}
