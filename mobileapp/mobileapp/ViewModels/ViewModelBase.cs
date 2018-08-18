using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

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

        private Xamarin.Forms.Color accentColor = Xamarin.Forms.Color.FromHex("#536DFE");
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
