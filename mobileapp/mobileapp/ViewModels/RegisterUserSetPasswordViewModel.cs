using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class RegisterUserSetPasswordViewModel : ViewModelBase
	{
        public DelegateCommand GotoNextPageCommand { get; }
        public DelegateCommand GotoSaveCommand { get; }
        private User user;
        public RegisterUserSetPasswordViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Set Password";
            GotoNextPageCommand = new DelegateCommand(GotoNextPage);
            GotoSaveCommand = new DelegateCommand(GotoSave);
        }

        private async void GotoSave()
        {
            var parameters = new NavigationParameters();
            parameters.Add("User", user);
            await NavigationService.NavigateAsync("RegisterUserConfirmEmail", parameters);
        }

        private async void GotoNextPage()
        {
            var parameters = new NavigationParameters();
            parameters.Add("User", user);

            await NavigationService.NavigateAsync("RegisterUserConfirmEmail", parameters);
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }



        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("User"))
            {
                user = parameters["User"] as User;
                if (user != null)
                {
                    UserName = user.Email;
                }
            }
        }
    }
}
