using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LocalizationXample
{
    public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
            Localization.Current.OnCultureChanged += (culture) =>
            {
                Messages.Culture = culture;
            };

            Localization.Current.EnsureDeviceOrDefaultCulture(
                defaultCultureName: "en", availableCultures: new[] { "en", "ar", "fr" });
            
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
