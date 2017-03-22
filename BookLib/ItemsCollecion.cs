using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManeger;
using BLL;
using System.IO;

namespace BLL
{
    public class ItemsCollecions
    {
        public List<User> Users = new List<User>();
        public List<AbstractItem> Items = new List<AbstractItem>();

        public void AddUser(User user)
        {
                Users.Add(user);
        }
        public bool ValidateNewUser(string UserName)
        {
            var NewUser = Users.Where(curUser => curUser.UserName == UserName).FirstOrDefault();
            if (NewUser!=null)
            {
                 return false;
            }
            return true;
           
        }
        public User ValidateUser(string UserName, string Password)
        {
                return Users.Where(curUser => curUser.UserName == UserName &&
                             curUser.Password == Password).FirstOrDefault();
        }
        public void addNewItem(AbstractItem NewItem)
        {
           if (NewItem is Book)
            {
                NewItem.Book = true;
            }
            else if (NewItem is Journal)
            {
                NewItem.Journal = true;
            }
            Items.Add(NewItem);
        }
        public List<AbstractItem> SearchByName(string name)
        {
            return Items.Where(i => i.Name.ToLower().Contains( name.ToLower())).ToList();
        }
        public List<AbstractItem> SearchByCategoty(eBaseCategory categoty)
        {
            return Items.Where(i => i.Category == categoty).ToList();
        }
        public List<AbstractItem> SearchByAuthor(string author)
        {
            return Items.Where(i => i.Author.ToLower().Contains( author.ToLower())).ToList();
        }
        public List<AbstractItem> SearchBySubCategoty(eInnerCategory subCategory)
        {
            return Items.Where(i => i.SubCategory == subCategory).ToList();
        }
        public List<AbstractItem> MultipleSearch(string name, string author, string publishing)
        {
            return Items.Where(i => i.Name.ToLower().Contains( name.ToLower())
            && i.Author.ToLower().Contains (author.ToLower())
            && i.Publishing.ToLower().Contains( publishing.ToLower())).ToList();
        }
        public void EditItem(AbstractItem item)
        {
            if (item!=null)
            {
                var editItem = Items.FirstOrDefault(i => i.ISBN == item.ISBN && 
                item.NumberofCopie == i.NumberofCopie);

                //if (editItem != null)
                //{
                    editItem.Name = item.Name;
                    editItem.Author = item.Author;
                    editItem.PrintDate = item.PrintDate;
                    editItem.Publishing = item.Publishing;
                    editItem.Category = item.Category;
                    editItem.SubCategory = item.SubCategory;
                //}

                if (item is Book)
                {
                    //  ((Book)editItem).Test = ((Book)item).Test;
                }
                else if (item is Journal)
                {

                }
            }
        }
        public void Remove(AbstractItem item)
        {
            if (item != null)
            {
                var RemoveItem = Items.FirstOrDefault
                    (i => i.ISBN == item.ISBN &&
                    item.NumberofCopie == i.NumberofCopie);
                if (RemoveItem!= null)
                {
                    Items.Remove(RemoveItem);
                }
            }
        }
        public void SaveData()
        {         
            DBData.Serialize(new LibraryData { Users = Users, Items = Items });
        }
        public void InitializeData()
        {
            if (File.Exists(DBData.FilePath))
            {
                var data = DBData.DeSerialize<LibraryData>();
                Users = data.Users;
                Items = data.Items;
            }
        }
    
     
    }
}
