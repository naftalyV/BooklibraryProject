using BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for SearchWindo.xaml
    /// </summary>
    [Serializable]
    public partial class SearchWindo : Window
    {

        public SearchWindo()
        {
            InitializeComponent();
           //Fill The Combo Box with items
            comboBoxMultipleSearch.Items.Add("no category selected");
            foreach (var item in Enum.GetValues(typeof(eBaseCategory)))
            {
                CmbCategoty.Items.Add(item);
                comboBoxMultipleSearch.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(eInnerCategory)))
            {
                CmbSubCategoty.Items.Add(item);
            }
            //These options are restricted to consumer
            if (MainWindow.User.UserType == eUserType.consumer)
            {
                btnEdit.IsEnabled = false;
                btnRmove.IsEnabled = false;
                btnNewItem.IsEnabled = false;
            }
        }
        //Different types of search
        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var Name = textBoxName.Text;

            dataGridSearch.ItemsSource = MainWindow.IC.SearchByName(Name);
        }

        private void CmbCategoty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var Category = (eBaseCategory)CmbCategoty.SelectedItem;
            dataGridSearch.ItemsSource = MainWindow.IC.SearchByCategoty(Category);
        }
       
        private void CmbSubCategoty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SubCategory = (eInnerCategory)CmbSubCategoty.SelectedItem;
            dataGridSearch.ItemsSource = MainWindow.IC.SearchBySubCategoty(SubCategory);
        }
        private void textBoxPublishing_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var Publishing = textBoxPublishing.Text;
            dataGridSearch.ItemsSource = MainWindow.IC.SearchByPublishing(Publishing);
        }

        private void MultipleSearch(object sender, RoutedEventArgs e)
        {
            eBaseCategory? CategoryIndex = comboBoxMultipleSearch.SelectedValue is eBaseCategory
                ? (eBaseCategory?)comboBoxMultipleSearch.SelectedValue : null;
            var Name = textBoxMultipleSearchName.Text;
            var Publishing = TextBoxMultipleSearchPublishing.Text;
            dataGridSearch.ItemsSource = MainWindow.IC.MultipleSearch(Name, CategoryIndex, Publishing);
        }
        //Set Date
        private void dataGridSearch_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType== typeof(DateTime))
            {
                var c = e.Column as DataGridTextColumn;
                c.Binding.StringFormat = "dd-MM-yyyy";
            }
        }
        //Remove item
        private void button_Click(object sender, RoutedEventArgs e)
        {

            var RemoveItem = (AbstractItem)dataGridSearch.SelectedItem;
            if (RemoveItem != null)
            {
                MainWindow.IC.RemoveItem(RemoveItem);
                Refresh();
                System.Windows.MessageBox.Show("הפריט נמחק");
            }
        }
        //Edit item
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dataGridSearch.IsReadOnly = false;
            var EditItem = (AbstractItem)dataGridSearch.SelectedItem;
            MainWindow.IC.EditItem(EditItem);
            Refresh();
        }
        //Show all item
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            dataGridSearch.ItemsSource = MainWindow.IC.Items.ToList();
        }
        //borrow item
        private void btnToborrow_Click(object sender, RoutedEventArgs e)
        {
            var item = (AbstractItem)dataGridSearch.SelectedItem;
            if (item != null)
            {
                item.IsBorrowed = true;
                Refresh();
            }
        }
        //return item
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            var item = (AbstractItem)dataGridSearch.SelectedItem;
            if (item != null)
            {
                item.IsBorrowed = false;
                Refresh();

            }

        }
        //Add new item
        private void btnNewItem_Click(object sender, RoutedEventArgs e)
        {
            var AddWindow = new AddItem();
            AddWindow.ShowDialog();
            Refresh();
        }
        //Refresh the data
        private void Refresh()
        {
            dataGridSearch.ItemsSource = MainWindow.IC.Items;
            dataGridSearch.Items.Refresh();
        }
       

    }
}
