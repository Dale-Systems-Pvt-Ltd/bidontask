using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class RegisterUserConfirmEmailViewModel : ViewModelBase
	{
        private User user;
        public DelegateCommand GotoMobileConfirmationCommand { get; }
        public RegisterUserConfirmEmailViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Confirm Details";
            GotoMobileConfirmationCommand = new DelegateCommand(GotoMobileConfirmation);
        }

        private async  void GotoMobileConfirmation()
        {
            var parameters = new NavigationParameters();
            parameters.Add("User", user);
            await NavigationService.NavigateAsync("RegisterUserConfirmMobile", parameters);
        }

       
        private string emailVerificationLabel;
        public string EmailVerificationLabel
        {
            get { return emailVerificationLabel; }
            set { SetProperty(ref emailVerificationLabel, value); }
        }

       

        private string emailIcon = Utils.MaterialIcons.email.ToString();
        public string EmailIcon
        {
            get { return emailIcon; }
            set { SetProperty(ref emailIcon, value); }
        }

        

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("User"))
            {
                user = parameters["User"] as User;
                if (user != null)
                {
                    EmailVerificationLabel = "We have sent you a security code at " + user.Email + ". Please enter it below to confirm your email address";
                    
                }
            }
        }
    }
}
