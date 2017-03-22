using System;
using System.Collections.Generic;

namespace BLL
{
    [Serializable]

    public class LibraryData
    {
        public List<AbstractItem> Items { get;  set; }
        public List<User> Users { get;  set; }
    }
}