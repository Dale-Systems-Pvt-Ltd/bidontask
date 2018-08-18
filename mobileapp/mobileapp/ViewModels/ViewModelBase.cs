using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobileapp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private Xamarin.Forms.Color darkPrimaryColor = Xamarin.Forms.Color.FromHex("#00796B");
        public Xamarin.Forms.Color DarkPrimaryColor
        {
            get { return darkPrimaryColor; }
            set { SetProperty(ref darkPrimaryColor, value); }
        }

        private Color lightPrimaryColor = Color.FromHex("#B2DFDB");
        public Color LightPrimaryColor
        {
            get { return lightPrimaryColor; }
            set { SetProperty(ref lightPrimaryColor, value); }
        }

        private Color primaryColor = Color.FromHex("#009688");
        public Color PrimaryColor
        {
            get { return primaryColor; }
            set { SetProperty(ref primaryColor, value); }
        }

        private Color textIconColor = Color.FromHex("#FFFFFF");
        public Color TextIconColor
        {
            get { return textIconColor; }
            set { SetProperty(ref textIconColor, value); }
        }

        private Color primaryTextColor = Color.FromHex("#212121");
        public Color PrimaryTextColor
        {
            get { return primaryTextColor; }
            set { SetProperty(ref primaryTextColor, value); }
        }

        private Color secondaryTextColor = Color.FromHex("#757575");
        public Color SecondaryTextColor
        {
            get { return secondaryTextColor; }
            set { SetProperty(ref secondaryTextColor, value); }
        }

        private Color dividerColor = Color.FromHex("#757575");
        public Color DividerColor
        {
            get { return dividerColor; }
            set { SetProperty(ref dividerColor, value); }
        }

        private Xamarin.Forms.Color accentColor = Xamarin.Forms.Color.FromHex("#7C4DFF");
        public Xamarin.Forms.Color AccentColor
        {
            get { return accentColor; }
            set { SetProperty(ref accentColor, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
