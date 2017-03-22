using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public class Book : AbstractItem
    {

        public int Test{ get; set; }

        public Book(string name, DateTime printDate, eBaseCategory category, eInnerCategory subCategory,
            string author, string publishing, int numberofCopie)
            : base(name, printDate, category, subCategory, author, publishing, numberofCopie)
        {
        }
    }
}