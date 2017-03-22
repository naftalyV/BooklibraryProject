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
    public class ItemsCollecion
    {
        public List<User> Users = new List<User>();
        public List<AbstractItem> Items = new List<AbstractItem>();

        public void AddUser(User user)
        {
                Users.Add(user);
        }
       // Checks to see if user already exists
        public bool ValidateNewUser(string UserName)
        {
            var NewUser = Users.Where(curUser => curUser.UserName == UserName).FirstOrDefault();
            if (NewUser!=null)
            {
                 return false;
            }
            return true;
        }
        //Gets the existing user data
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
        //Different types of search
        public List<AbstractItem> SearchByName(string name)
        {
            return Items.Where(i => i.Name.ToLower().Contains( name.ToLower())).ToList();
        }
        public List<AbstractItem> SearchByCategoty(eBaseCategory categoty)
        {
            return Items.Where(i => i.Category == categoty).ToList();
        }
        public List<AbstractItem> SearchByPublishing(string publishing)
        {
            return Items.Where(i => i.Publishing.ToLower().Contains(publishing.ToLower())).ToList();
        }
        public List<AbstractItem> SearchBySubCategoty(eInnerCategory subCategory)
        {
            return Items.Where(i => i.SubCategory == subCategory).ToList();
        }
        public List<AbstractItem> MultipleSearch(string name , eBaseCategory? category, string publishing)
        {
            bool checkCategory = category.HasValue ? true : false;
            return Items.Where(i => i.Name.ToLower().Contains(name.ToLower())
            && (checkCategory? (i.Category == category): true)
            && i.Publishing.ToLower().Contains(publishing.ToLower())).ToList();
        }

        public void EditItem(AbstractItem item)
        {
            if (item!=null)
            {
                var editItem = Items.FirstOrDefault(i => i.ISBN == item.ISBN && 
                item.NumberOfCopie == i.NumberOfCopie);
                    editItem.Name = item.Name;
                    editItem.PrintDate = item.PrintDate;
                    editItem.Publishing = item.Publishing;
                    editItem.Category = item.Category;
                    editItem.SubCategory = item.SubCategory;

                if (item is Book)
                {
                    ((Book)editItem).Author = ((Book)editItem).Author;
                }
                else if (item is Journal)
                {
                    ((Journal)editItem).MainEditor = ((Journal)editItem).MainEditor;
                }
            }
        }

        public void RemoveItem(AbstractItem item)
        {
            if (item != null)
            {
                var RemoveItem = Items.FirstOrDefault
                    (i => i.ISBN == item.ISBN &&
                    item.NumberOfCopie == i.NumberOfCopie);
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
