using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
        public DelegateCommand SignInCommand { get; }
        public DelegateCommand GotoForgotPasswordCommand { get; }
        public DelegateCommand GotoRegisterUserCommand { get; }
        public LoginViewModel(INavigationService navigationService): base(navigationService)
        {
            SignInCommand = new DelegateCommand(SignIn);
            GotoForgotPasswordCommand = new DelegateCommand(GotoForgotPassoword);
            GotoRegisterUserCommand = new DelegateCommand(GotoRegisterUser);
            
        }

        private async void SignIn()
        {
            await NavigationService.NavigateAsync("/MastDetail/NavigationPage/Dashboard", useModalNavigation: false);
        }

        private async void GotoRegisterUser()
        {
            await NavigationService.NavigateAsync("RegisterUser");
        }

        private async void GotoForgotPassoword()
        {
            await NavigationService.NavigateAsync("ForgotPassword");
        }
    }
}
