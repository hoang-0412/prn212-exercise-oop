using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public interface IBorrowable
    {
        bool IsAvailable { get; set; }
        void Borrow();
        void Return();
    }
}
