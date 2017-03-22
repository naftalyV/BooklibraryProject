using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public abstract class AbstractItem
    {
        
        public bool IsBorrowed { get; set; }
        public bool Book { get; set; }
        public bool Journal { get; set; }
        public string Name { get; set; }
        public eBaseCategory Category { get; set; }
        public eInnerCategory SubCategory { get; set; }
        public string NumberOfCopie { get; set; }
        public string Publishing { get; set; }
        
        public DateTime PrintDate { get; set; }
        public  Guid ISBN { get; }

        public AbstractItem(string name, DateTime printDate,eBaseCategory category
            ,eInnerCategory  subCategory,  string publishing, string numberofCopie)
        {
            Name = name;
            Category = category;
            SubCategory = subCategory;
            NumberOfCopie = numberofCopie;
            Publishing = publishing;
            PrintDate = printDate;
            ISBN = Guid.NewGuid();
        }
    }
}