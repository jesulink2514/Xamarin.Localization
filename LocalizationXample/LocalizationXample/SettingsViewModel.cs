using System.Collections.Generic;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Forms;

namespace LocalizationXample
{
    public class SettingsViewModel : BindableObject
    {
        private CultureInfo _currentLanguage;

        public SettingsViewModel()
        {
            //Uncomment to see all languages available
            //Languages = Localization.Current.CultureInfoList.ToList();
            CurrentLanguage = Localization.Current.CurrentNeutralCultureInfo;
            SetCommand = new Command(Set);
        }

        public List<CultureInfo> Languages { get; } = new List<CultureInfo>
        {
            Localization.Current.GetCultureInfo("en"),
            Localization.Current.GetCultureInfo("ar")
        };

        public CultureInfo CurrentLanguage
        {
            get => _currentLanguage;
            set { 
                _currentLanguage = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand SetCommand { get;}


        private void Set(object obj)
        {
            Localization.Current.CurrentCultureInfo = CurrentLanguage;
            
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}
