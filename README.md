## Localization for Xamarin.Forms, Xamarin.iOS , Xamarin.Android, Xamarin.Mac and Xamarin.WPF
Powerfull netstandard plugin for handling language localization in Xamarin.Forms.

![](https://github.com/jesulink2514/Xamarin.Localization/blob/master/images/demo-localization.gif?raw=true)

### NuGet
* Available on NuGet: [Xamarin.Forms.Localization](https://www.nuget.org/packages/Xamarin.Forms.Localization) [![NuGet](https://img.shields.io/nuget/v/Xamarin.Forms.Localization.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Forms.Localization)

* Sources package available [Xamarin.Localization.Sources](https://www.nuget.org/packages/Xamarin.Localization.Sources)  [![NuGet](https://img.shields.io/nuget/v/Xamarin.Localization.Sources.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.Localization.Sources) (No Xamarin.Forms dependency) :gift:

## Features

- Get and set current culture
- Get device culture
- Ensure device culture match available cultures or set a default culture even when culture are neutral and device culture is not.
- Get culture list
- Get specific culture by name
- Raise event when current culture change to update Resources Culture
- Detect `FlowDirection` based on current culture :gift:
- **No markup extension needed to bind resource messages**
- Intellisense available for Resources :heart:

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Mono| 5.4+|
|Xamarin.Forms| 3.0+|
|Xamarin.iOS|iOS 10.14+|
|Xamarin.Android|API 14+|
|Windows 10 UWP|10+|
|Xamarin.Mac|+3.8|
|watchOS|All|
|tvOS|All|

### Setup
* Install into your Net Standard project (clients are not needed).

* If you want to use in Android, iOS with no Xamarin.Forms dependency use the Sources package.

### Getting Started

1. Add your Resx files

![](https://github.com/jesulink2514/Xamarin.Localization/blob/master/images/2018-05-20_23-33-02.png?raw=true)

2. Add one .resx file per language you want to support. As you can imagine it must follow a specific naming convention: use the same filename as the base resources file (eg. Messages) followed by a period (.) and then the language code.

![](https://github.com/jesulink2514/Xamarin.Localization/blob/master/images/2018-05-20_23-32-32.png?raw=true)

3. In order to recognize the device language, you can use `EnsureDeviceOrDefaultCulture`, if device's language match available cultures, that culture will be set, otherwise, `defaultCultureName` will be used.

       Localization.Current.EnsureDeviceOrDefaultCulture(defaultCultureName:"en",
                                    availableCultures:new []{"en","ar","fr"});

4. Set the culture of your resource class file when initializing your application.

       Messages.Culture = Localization.Current.CurrentCultureInfo;

5. Ensure that you handle the language change event to ensure resource class `Culture` matchs.

       Localization.Current.OnCultureChanged += (culture)=>
       {
           Messages.Culture = culture;
       };
       
*If you are using Xamarin Forms it would be in your App.cs*

### Xamarin Forms Specifics

This pacakage depends on new Xamarin.Forms 3.0 package with support to RTL content.

To use the resources in XAML, you need to import your resource class namespace and set any property value using the Static expression. You don't need any custom markup extension and it brings Intellisense support ;)

![](https://github.com/jesulink2514/Xamarin.Localization/blob/master/images/2018-05-20_23-45-20.png?raw=true)

### iOS Considerations
In the `Info.plist` file add the keys **Localizations & Localization native development region** to change the user interface OS elements. It will take the device language.

![](https://github.com/jesulink2514/Xamarin.Localization/blob/master/images/2018-05-20_23-45-29.png?raw=true)

### API Details

Call `Localization.Current` from any project or .net standard library project to gain access to APIs.

**CurrentCultureInfo**

Gets and set the current culture. By default will be set to the device culture.

Usage sample:

    Localization.Current.CurrentCultureInfo = new CultureInfo("en");

**CurrentNeutralCultureInfo**

Gets the neutral culture version of the current culture.

Usage sample:

    Localization.Current.CurrentNeutralCultureInfo;

**DeviceCultureInfo**

Gets the device culture

Usage sample:

    Localization.Current.DeviceCultureInfo;

**CultureInfoList**

Gets all cultures supported in .NET Framework (neutral & specific cultures)

Usage sample:

    Localization.Current.CultureInfoList;

**NeutralCultureInfoList**

Gets all cultures associated with a language (not specific to a country/region).

Usage sample:

    Localization.Current.NeutralCultureInfoList;

**GetCultureInfo**

Gets a specific culture by language code.

Usage sample:

    Localization.Current.GetCultureInfo("es");
    
**IsRightToLeft**

Gets `true` if the current culture is RTL language. 

Usage sample:

    Localization.Current.IsRightToLeft

**FlowDirection**

Gets a FlowDirection enum value used for Xamarin.Forms to add RTL support. For more information, review https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/localization/right-to-left.

Usage sample:

      public partial class MainPage : ContentPage
      {
          public MainPage()
          {
              InitializeComponent();
              FlowDirection = Localization.Current.FlowDirection;
          }
      }
     
**EnsureDeviceOrDefaultCulture(string defaultCultureName, params string[] availableCultures)**
Try to set the `CurrentCultureInfo` value based on device culture only if it matches available cultures.

Usage sample:

       Localization.Current.EnsureDeviceOrDefaultCulture(defaultCultureName:"en",
                                    availableCultures:new []{"en","ar","fr"});

**OnCultureChanged**
An event that arises when you change the `CurrentCultureInfo`.

Usage sample:

       Localization.Current.OnCultureChanged += (culture)=>
       {
           Messages.Culture = culture;
       };

### Contributors

* [Jesus Angulo](https://github.com/jesulink2514)
