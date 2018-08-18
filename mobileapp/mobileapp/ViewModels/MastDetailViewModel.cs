using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class MastDetailViewModel : ViewModelBase
	{
        public DelegateCommand<string> NavigateCommand { get; }
        public MastDetailViewModel(INavigationService navigationService): base(navigationService)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string pageName)
        {
            if (pageName == "Login") await NavigationService.NavigateAsync("/Login");
            await NavigationService.NavigateAsync("NavigationPage/" + pageName);
        }
    }
}
