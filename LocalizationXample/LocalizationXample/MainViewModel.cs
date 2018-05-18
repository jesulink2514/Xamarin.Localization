using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LocalizationXample
{
    public class MainViewModel: BindableObject
    {
        public MainViewModel()
        {
            ChangeCommand = new Command(Change);
        }

        private void Change(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new SettingsPage());   
        }

        public ICommand ChangeCommand { get;}
    }
}
