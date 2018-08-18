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
        private User user;
        
        public WorkerProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "My Business Profile";
            
        }

        private string navigateNextIcon = Utils.MaterialIcons.navigate_next.ToString();
        public string NavigateNextIcon
        {
            get { return navigateNextIcon; }
            set { SetProperty(ref navigateNextIcon, value); }
        }
    }
}
