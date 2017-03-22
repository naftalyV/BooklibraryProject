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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public static User User { get; set; }
        public static ItemsCollecion IC = new ItemsCollecion();

        public MainWindow()
        {
            InitializeComponent();
            if (User.UserType!=eUserType.consumer)
            {
               //These options are restricted to consumer
                btnUsers.IsEnabled = true;
                btnAddItem.IsEnabled = true;
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
                var AddWindow = new AddItem();
                AddWindow.Show();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var SearchItem = new SearchWindo();
            SearchItem.Show();
        }
        //Save In Closing all change
        private void SaveInClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IC.SaveData();
        }
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            var UserManagement = new UserManagementWindow(User);
            UserManagement.Show();
        }
    }
}
