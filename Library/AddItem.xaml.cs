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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public ItemType CurrentItem { get; set; }
      
        public enum ItemType
        {
            Default,
            Book,
            Journal
        }
        public AddItem()
        {
            InitializeComponent();
            comboBoxCategory.ItemsSource = Enum.GetValues(typeof(eBaseCategory));
            DatePickerPrintDate.SelectedDate = DateTime.Now;
            comboBoxSubCategory.IsEnabled = false;
            textBlockMainEditor.Visibility = Visibility.Hidden;
            textBlockAuthor.Visibility = Visibility.Hidden;
            TextBoxAuthor.Visibility = Visibility.Hidden;
            TextBoxMainEditor.Visibility = Visibility.Hidden;
        }
        //Add selected items by type
        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            {
                if (CurrentItem == ItemType.Default)
                {
                    MessageBox.Show("?מה ברצונך להוסיף");
                }
                else if (textBoxNameItem.Text != string.Empty
                 &&comboBoxCategory.SelectedIndex >= 0
                &&comboBoxSubCategory.SelectedIndex >= 0 )
                {
                    if (CurrentItem == ItemType.Book)
                    {

                        MainWindow.IC.addNewItem(new Book(textBoxNameItem.Text,
                            DatePickerPrintDate.SelectedDate.Value,
                            (eBaseCategory)Enum.Parse(typeof(eBaseCategory),
                            comboBoxCategory.SelectedItem.ToString()),
                            (eInnerCategory)Enum.Parse(typeof(eInnerCategory),
                            comboBoxSubCategory.SelectedItem.ToString()),
                             TextBoxAuthor.Text,
                             textBoxPublishing.Text,
                             textBoxNumberOfCopie.Text));
                    }
                    else if (CurrentItem == ItemType.Journal)
                    {
                        MainWindow.IC.addNewItem(new Journal
                            (TextBoxMainEditor.Text,
                            textBoxNameItem.Text,
                            DatePickerPrintDate.SelectedDate.Value,
                           (eBaseCategory)Enum.Parse(typeof(eBaseCategory),
                             comboBoxCategory.SelectedItem.ToString()),
                          (eInnerCategory)Enum.Parse(typeof(eInnerCategory),
                         comboBoxSubCategory.SelectedItem.ToString()),
                         textBoxPublishing.Text,
                          textBoxNumberOfCopie.Text));
                    }
                    MessageBox.Show("הפריט נוסף לספריה");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("שדות שם,קטגוריה ותת קטגוריה הינם חובה");
                }
            }
        }
        //Filling the sub-category according to the selected category
        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxSubCategory.IsEnabled = true;
            var temp = (eBaseCategory)comboBoxCategory.SelectedItem;
            comboBoxSubCategory.ItemsSource = Categories.CategoriesDictionary[temp];
        }
        // Chek the tipe
        private void CheckItem(object sender, RoutedEventArgs e)
        {
            var radioValue = sender as RadioButton;

            switch (radioValue.Name)
            {
                case "radioButtonBook":
                    textBlockMainEditor.Visibility = Visibility.Hidden;
                    TextBoxMainEditor.Visibility = Visibility.Hidden;
                    textBlockAuthor.Visibility = Visibility.Visible;
                    TextBoxAuthor.Visibility = Visibility.Visible;
                    CurrentItem = ItemType.Book;
                    break;
                case "radioButtonJournal":
                    textBlockMainEditor.Visibility = Visibility.Visible;
                    TextBoxMainEditor.Visibility = Visibility.Visible;
                    TextBoxAuthor.Visibility = Visibility.Visible;
                    textBlockAuthor.Visibility = Visibility.Hidden;
                    CurrentItem = ItemType.Journal;
                    break;
            }
        }
    }
}

