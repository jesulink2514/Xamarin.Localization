using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace LocalizationXample
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Localization.Current.EnsureDeviceOrDefaultCulture(
                defaultCultureName:"en",availableCultures:new []{"en","ar"});
            
            Localization.Current.OnCultureChanged += (culture)=>
            {
                Messages.Culture = culture;
            };

            Messages.Culture = Localization.Current.CurrentCultureInfo;

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
