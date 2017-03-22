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
using BLL;

namespace Library
{
    /// <summary>
    /// Interaction logic for AddItemWindow.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private User NewUser = new User();
        private User CuerrentUser = new User();
        bool FirstRun;

        private void IntializeData()
        {
            comboBoxUserType.ItemsSource = Enum.GetNames(typeof(eUserType));
            //In first option is to use only the Administrator type and another used only consumer
            comboBoxUserType.SelectedIndex = FirstRun ? 2 : 0;
            //In First option is to use only the Administrator type and another using only the administrator can change the user type
            comboBoxUserType.IsEnabled = CuerrentUser.UserType == eUserType.Administrator && FirstRun == false;
             datePickerBirthDate.SelectedDate = DateTime.Now.Date ;
            
        }


        public AddUser(User _currentUser = null, bool FirstRun = false)
        {
            InitializeComponent();
            this.FirstRun = FirstRun;
            CuerrentUser = _currentUser == null? CuerrentUser : _currentUser;
            IntializeData();
        }

        private void btnNewRegister_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Text != string.Empty && textBoxUserName.Text != string.Empty)
            {
                NewUser.FirstName = textBoxFirstName.Text;
                NewUser.LastNama = textBoxLastName.Text;
                NewUser.id = textBoxId.Text;
                NewUser.Password = textBoxPassword.Text;
                NewUser.UserType = (eUserType)Enum.Parse(typeof(eUserType),
                    comboBoxUserType.SelectedItem.ToString());
                NewUser.BirthDate = datePickerBirthDate.SelectedDate.Value.Date;
                NewUser.Adress = textBoxAdress.Text;
                NewUser.UserName = textBoxUserName.Text;
                NewUser.Email = textBoxEmail.Text;
                if (MainWindow.IC.ValidateNewUser(NewUser.UserName ) == true)
                {
                    MainWindow.IC.AddUser(NewUser);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(" שם משתמש זה כבר בשימוש ");
                }
            }
            else
            {
                MessageBox.Show("חובה להזין שם משתמש וסיסמא");
            }
        }
    }
}
