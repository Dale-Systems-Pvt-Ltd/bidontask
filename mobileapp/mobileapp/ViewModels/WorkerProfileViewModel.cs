using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class WorkerProfileViewModel : ViewModelBase
	{
        private  User user;
        public DelegateCommand GotoLoginCommand { get; }
        public WorkerProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "My Business Profile";

            GotoLoginCommand = new DelegateCommand(GotoLogin);
            
        }

        private async void GotoLogin()
        {
            await NavigationService.NavigateAsync("/NavigationPage/Login");
        }

        private string navigateNextIcon = Utils.MaterialIcons.navigate_next.ToString();
        public string NavigateNextIcon
        {
            get { return navigateNextIcon; }
            set { SetProperty(ref navigateNextIcon, value); }
        }

        private string checkboxIcon = Utils.MaterialIcons.check_box.ToString();
        public string CheckboxIcon
        {
            get { return checkboxIcon; }
            set { SetProperty(ref checkboxIcon, value); }
        }
    }
}
