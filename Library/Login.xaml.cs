using BLL;
using DataManeger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        User CurrentUser = new User();
        public Login()
        {
            InitializeComponent();
            UserBox.Focus();
            MainWindow.IC.InitializeData();
            //First Use
            if (!File.Exists(DBData.FilePath))
            {
                MessageBox.Show(".המערכת מזהה כניסה ראשונה לספריה. אנא הזן שם משתמש וסיסמא אשר ישמשו כסיסמת מנהל");
                (new AddUser(CurrentUser, MainWindow.IC.Users.Count == 0)).Show();
            }

        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password != string.Empty && UserBox.Text != string.Empty)
            {
                CurrentUser = MainWindow.IC.ValidateUser(UserBox.Text, passwordBox.Password);

                if (CurrentUser == null)
                {
                    MessageBox.Show(".משתמש לא קיים, הינך מועבר להרשמה");
                    (new AddUser(CurrentUser, MainWindow.IC.Users.Count == 0)).Show();
                }
                else
                {
                    MainWindow.User = CurrentUser;
                    (new MainWindow()).Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("אנא הזן שם משתמש וסיסמא");
            }
        }

        private void btnRegister_Click_1(object sender, RoutedEventArgs e)
        {
            (new AddUser()).Show();
        }
    }

}
