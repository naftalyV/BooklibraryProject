using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public class Book : AbstractItem
    {
        public string Author { get; set; }
        public Book(string name, DateTime printDate, eBaseCategory category,
           eInnerCategory subCategory, string author, string publishing, string numberofCopie)
            : base(name, printDate, category, subCategory, publishing, numberofCopie)
        {
            Author = author;
        }
    }
}