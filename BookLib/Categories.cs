using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public static class Categories
    {
        public static Dictionary<eBaseCategory, List<eInnerCategory>> CategoriesDictionary = new Dictionary<eBaseCategory, List<eInnerCategory>>
            {
             {
                eBaseCategory.Study,
                new List<eInnerCategory> {eInnerCategory.Technology,eInnerCategory.Medicine }
            },
             {
                eBaseCategory.Reading,
                new List<eInnerCategory> {eInnerCategory.Novella,eInnerCategory.Drama
                 ,eInnerCategory.Comics,eInnerCategory.Medicine,eInnerCategory.Roman,eInnerCategory.Technology}
            },
             {
                eBaseCategory.Kids,
                new List<eInnerCategory> {eInnerCategory.Comics,eInnerCategory.Roman,eInnerCategory.Drama,eInnerCategory.Novella} },
            };



    }
}
