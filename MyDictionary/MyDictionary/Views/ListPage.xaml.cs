using MyDictionary.Helper;
using MyDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        SQLiteManager manager;

        public ListPage()
        {
            InitializeComponent();
            txtSearch.BackgroundColor = Device.OnPlatform(Color.Black, Color.White, Color.White);
            List<Dictionary> dictionaryList = new List<Dictionary>();
            manager = new SQLiteManager();
            dictionaryList = manager.GetAll().ToList();

            lstDictionary.BindingContext = dictionaryList;
        }

        private void onMenuInsert (object sender, EventArgs e)
        {
            Navigation.PushAsync(new InsertPage());
        }
        private void onMenuRefresh(Object sender, EventArgs e)
        {
            RefreshData();
        }

        private async void onMenuDelete(object sender, EventArgs e)
        {
            var selectedMenuItem = (MenuItem)sender;
            var selectedDictionary = manager.Get(Convert.ToInt32(selectedMenuItem.CommandParameter.ToString()));
            bool isOK = await DisplayAlert("Warning", selectedDictionary.Word + " = " + selectedDictionary.Meaning + "record will be deleted", "DELETE", "CANCEL");
            if (isOK)
            {
                int isDeleted = manager.Delete(Convert.ToInt32(selectedMenuItem.CommandParameter.ToString()));
                if (isDeleted > 0)
                {
                    DisplayAlert("Deleted", "Successful", "OK");
                    RefreshData();
                }
                else
                    DisplayAlert("Could not delete", "Unsuccessful", "OK");
            }
        }

        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem==null)
                return;
                ListView lv = (ListView)sender;
                var selectedWord = (Models.Dictionary)e.SelectedItem;
                DisplayAlert("Preview", selectedWord.Language + " " + selectedWord.Type + " " + selectedWord.RegisterDate.ToString("yyyy.MM.dd"), "OK");
                lv.SelectedItem = null;
        }

        private void onRefresh(object sender, EventArgs e)
        {
            RefreshData();
            lstDictionary.IsRefreshing = false;
        }

        private void onTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length > 3)
            {
                lstDictionary.BindingContext = e.NewTextValue;
            }
            else if (string.IsNullOrEmpty(e.NewTextValue))
            {
                List<Dictionary> dictionaryList = new List<Dictionary>();
                manager = new SQLiteManager();
                dictionaryList = manager.GetAll().ToList();

                lstDictionary.BindingContext = dictionaryList;
            }
        }

        private void RefreshData()
        {
            List<Dictionary> dictionaryList = new List<Dictionary>();
            dictionaryList = manager.GetAll().ToList();
            lstDictionary.BindingContext = dictionaryList;
        }
    }
}