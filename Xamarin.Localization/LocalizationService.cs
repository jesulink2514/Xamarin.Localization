using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xamarin.Forms;

namespace Xamarin
{
    public class LocalizationService : ILocalizationService
    {
        CultureInfo _currentCultureInfo = CultureInfo.InstalledUICulture;
        public CultureInfo CurrentCultureInfo
        {
            get
            {
                return _currentCultureInfo;
            }
            set
            {
                _currentCultureInfo = value;
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
                OnCultureChanged?.Invoke(value);
            }
        }


        public CultureInfo CurrentNeutralCultureInfo
        {
            get
            {
                return CurrentCultureInfo.IsNeutralCulture ? CurrentCultureInfo:
                    CurrentCultureInfo.Parent;
            }
        }

        public bool IsRightToLeft => CurrentCultureInfo.TextInfo.IsRightToLeft;

        public CultureInfo DeviceCultureInfo { get { return CultureInfo.InstalledUICulture; } }

        public CultureInfo[] CultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.AllCultures); } }

        public CultureInfo[] NeutralCultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.NeutralCultures); } }

        public FlowDirection FlowDirection => IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

        public event CultureChanged OnCultureChanged;

        public void EnsureDeviceOrDefaultCulture(string defaultCultureName,params string[] availableCultures)
        {
            var code = CurrentCultureInfo.Name;
            if(availableCultures.Any(x=>x == code))
            {
                return;
            }

            if (CurrentCultureInfo.IsNeutralCulture)
            {
                var codeToSearch = $"{code}-";
                var cultures = availableCultures.Where(x=>x.StartsWith(codeToSearch)).ToArray();
                if(cultures.Length > 0)
                {
                    CurrentCultureInfo = GetCultureInfo(cultures[0]);
                    return;
                }
            }

            var neutralCode = CurrentCultureInfo.Parent.Name;

            var culturesRelatedToParent = availableCultures.Where(x=> x.StartsWith(neutralCode)).ToArray();
            if(culturesRelatedToParent.Length > 0)
            {
                CurrentCultureInfo  =GetCultureInfo(culturesRelatedToParent[0]);
                return;
            }

            CurrentCultureInfo = GetCultureInfo(defaultCultureName);
        }

        public CultureInfo GetCultureInfo(string name) { return CultureInfo.GetCultureInfo(name); }
    }
}
