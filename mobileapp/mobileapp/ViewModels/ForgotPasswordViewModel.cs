using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class ForgotPasswordViewModel : ViewModelBase
	{
        public ForgotPasswordViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Forgot Password";
        }
	}
}
