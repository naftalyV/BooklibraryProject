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
        Nan,
        Study,
        Reading,
        Kids
    }
    [Serializable]
    public enum eInnerCategory
    {
        Nan,
        Comics,
        Drama,
        Novella,
        Roman,
        Technology,
        Medicine
    }
}
