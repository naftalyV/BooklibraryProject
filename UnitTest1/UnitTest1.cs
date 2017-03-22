using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public  ItemsCollecion IC = new ItemsCollecion();
        [TestMethod]
        public void TestAddItem()
        {
          
            Book b = new Book("aa", new DateTime(2016, 12, 30), eBaseCategory.Study,
                eInnerCategory.Medicine, "BB", "nn", "1");
            Journal j = new Journal("bb", "jj", new DateTime(2016, 12, 20), eBaseCategory.Cooking,
                eInnerCategory.Desserts, "hh", "1");
           IC.addNewItem(b);
            IC.addNewItem(j);
            Assert.AreEqual(2, IC.Items.Count);
        }

        [TestMethod]
        public void TestAddUser()
        {
       
            User u = new User { id = "1", FirstName = "hjhjh", LastNama = "jhjhj" };
            IC.AddUser(u);
            
            Assert.AreEqual(1, IC.Users.Count);
            
        }

        [TestMethod]
        public void TestSearch()
        {

            Book b = new Book("aa", new DateTime(2016, 12, 30), eBaseCategory.Study,
                 eInnerCategory.Medicine, "BB", "nn", "1");
            Journal j = new Journal("bb", "jj", new DateTime(2016, 12, 20), eBaseCategory.Cooking,
                eInnerCategory.Desserts, "hh", "1");
            IC.addNewItem(b);
            IC.addNewItem(j);
          var item =  IC.SearchByName("a");
            Assert.AreEqual(1, item.Count);

        }
    }
}
           