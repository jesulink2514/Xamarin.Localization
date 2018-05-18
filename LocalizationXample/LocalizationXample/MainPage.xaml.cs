using Xamarin.Forms;

namespace LocalizationXample
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel();
            FlowDirection = Localization.Current.FlowDirection;
		}
    }
}
