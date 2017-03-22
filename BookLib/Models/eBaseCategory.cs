using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public enum eBaseCategory
    {
       // Nan,
        Kids,
        Study,
        Reading,
        Cooking
    }
    [Serializable]
    public enum eInnerCategory
    {
        Jewish,
        Comics,
        Drama,
        Novella,
        Roman,
        Tech,
        Math,
        Medicine,
        Phisics,
        Soups,
        Desserts,
        Meat,
        Fish
    }
}

