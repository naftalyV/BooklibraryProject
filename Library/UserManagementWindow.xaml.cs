using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{

    /// <summary>
    /// Interaction logic for UserManagementWindow.xaml
    /// </summary>
    public partial class UserManagementWindow : Window
    {
        User CurrentUser;
        public UserManagementWindow(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
        }

        private void btnShowAllUsers_Click(object sender, RoutedEventArgs e)
        {
            dataGridUsers.ItemsSource = MainWindow.IC.Users.ToList();
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            (new AddUser(CurrentUser)).ShowDialog();
            Refresh();
        }
        //User can not delete itself or manager
        private void btnRemoveUser_Click(object sender, RoutedEventArgs e)
        {
            var RemoveUser = (User)dataGridUsers.SelectedItem;
            if (RemoveUser != null && CurrentUser!=RemoveUser &&
                RemoveUser.UserType!=eUserType.Administrator)
            {
                MainWindow.IC.Users.Remove(RemoveUser);
                MessageBox.Show("!משתמש נמחק");
                Refresh();
            }
            //The administrator can delete another manager
            else if (RemoveUser != null && CurrentUser != RemoveUser && 
                CurrentUser.UserType == eUserType.Administrator)
            {
                MainWindow.IC.Users.Remove(RemoveUser);
                MessageBox.Show("!משתמש נמחק");
                Refresh();
            }
        }
        private void Refresh()
        {
            dataGridUsers.ItemsSource = MainWindow.IC.Users;
            dataGridUsers.Items.Refresh();

        }

    }
}

