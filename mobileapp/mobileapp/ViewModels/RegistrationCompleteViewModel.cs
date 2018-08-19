using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace mobileapp.ViewModels
{
	public class RegistrationCompleteViewModel : ViewModelBase
	{
        public DelegateCommand GotoLoginCommand { get; }
        public DelegateCommand GotoWorkerProfileCommand { get; }
        public RegistrationCompleteViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Registration Complete";
            GotoLoginCommand = new DelegateCommand(GotoLogin);
            GotoWorkerProfileCommand = new DelegateCommand(GotoWorkerProfile);
        }

        private async void GotoWorkerProfile()
        {
            await NavigationService.NavigateAsync("/NavigationPage/WorkerProfile");
        }

        private async void GotoLogin()
        {
            await NavigationService.NavigateAsync("/MastDetail/NavigationPage/Dashboard", useModalNavigation: false);
        }

        private string headerIcon = Utils.MaterialIcons.thumb_up.ToString();
        public string HeaderIcon
        {
            get { return headerIcon; }
            set { SetProperty(ref headerIcon, value); }
        }

        private string header2Icon = Utils.MaterialIcons.monetization_on.ToString();
        public string Header2Icon
        {
            get { return header2Icon; }
            set { SetProperty(ref header2Icon, value); }
        }

        
    }
}
