using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public interface IBorrowable
    {
        bool IsAvailable { get;}
        void Borrow();
        void Return();
    }
}
