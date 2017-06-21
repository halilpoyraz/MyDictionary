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
    public partial class InsertPage : ContentPage
    {
        public InsertPage()
        {
            InitializeComponent();
        }

        private void onInsert (object sender, EventArgs e)
        {
            SQLiteManager manager = new SQLiteManager();
            Dictionary _dictionary = new Dictionary();
            
            _dictionary.Language = pckrLanguage.SelectedItem.ToString();
            _dictionary.Type = pckrType.SelectedItem.ToString();
            _dictionary.Word = txtWord.Text;
            _dictionary.Meaning = txtMeaning.Text;
            _dictionary.W_SampleSentence = txtW_SampleSentence.Text;
            _dictionary.M_SampleSentence = txtM_SampleSentence.Text;
            _dictionary.RegisterDate = DateTime.Now;

            int isInserted = manager.Insert(_dictionary);
            if (isInserted>0)
            {
                DisplayAlert("Successful", _dictionary.Word + " = " + _dictionary.Meaning, "OK");
            }
            else
                DisplayAlert("Unsuccessful", _dictionary.Word + " = " + _dictionary.Meaning, "OK");
        }
    }
}