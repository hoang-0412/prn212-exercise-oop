using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public interface IBorrowable
    {
        bool isAvailable { get; set; }
        void Borrow();
        void Return();
    }
}
