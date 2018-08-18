using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class RegisterUserConfirmMobileViewModel : ViewModelBase
	{
        private User user;
        public DelegateCommand GotoSetProfilePictureCommand { get; }
        public RegisterUserConfirmMobileViewModel(INavigationService navigationService): base(navigationService)
        {

            Title = "Verify Mobile Number";
            GotoSetProfilePictureCommand = new DelegateCommand(GotoSetProfilePicture);
        }

        private async void GotoSetProfilePicture()
        {
            var parameters = new NavigationParameters();
            parameters.Add("User", user);
            await NavigationService.NavigateAsync("SetProfilePicture", parameters);
        }


        private string mobileVerificationLabel;
        public string MobileVerificationLabel
        {
            get { return mobileVerificationLabel; }
            set { SetProperty(ref mobileVerificationLabel, value); }
        }

        private string mobileIcon = Utils.MaterialIcons.phone_android.ToString();
        public string MobileIcon
        {
            get { return mobileIcon; }
            set { SetProperty(ref mobileIcon, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("User"))
            {
                user = parameters["User"] as User;
                if (user != null)
                {                    
                    MobileVerificationLabel = "We have sent you a mobile verification security code at " + user.Mobile + ". Please enter it below to confirm your mobile number";
                }
            }
        }
    }
}
