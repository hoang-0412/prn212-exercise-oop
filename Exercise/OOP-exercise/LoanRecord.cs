using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_exercise
{
    public record LoanRecord(int LoanId, int MemberId, int ItemId, DateTime BorrowDate);
}
