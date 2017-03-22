using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public abstract class AbstractItem
    {
        public bool Book { get; set; }
        public bool Journal { get; set; }
        public bool IsBorrowed { get; set; }
        public string Name { get; set; }
        public  Guid ISBN { get; }
        public DateTime PrintDate { get; set; }
        public eBaseCategory Category { get; set; }
        public eInnerCategory SubCategory { get; set; }
        //public eInnerCategory SubCategory
        //{
        //    get { return _subCategory; }
        //    set
        //    {
        //        if (IsValid(value))
        //        {
        //            _subCategory = value;
        //        }
        //        else
        //            throw new ArgumentException("SubCategory not valid");
        //    }
        //}

        public string Author { get; set; }
        public string Publishing { get; set; }
        public int NumberofCopie { get; set; }

        public AbstractItem(string name, DateTime printDate, eBaseCategory category
            , eInnerCategory subCategory, string author, string publishing, int numberofCopie)
        {
            Name = name;
            ISBN = Guid.NewGuid();
            PrintDate = printDate;
            Category = category;
            SubCategory = subCategory;
            Author = author;
            Publishing = publishing;
            NumberofCopie = numberofCopie;
        }
        //public bool IsValid(eInnerCategory inner)
        //{
        //    try
        //    {
        //        if (Categories.CategoriesDictionary[Category].Contains(inner))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex1)
        //    {

        //        throw new Exception(ex1.Message);
        //    }

        //}

    }
}