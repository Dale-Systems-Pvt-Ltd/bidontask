using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class PostATaskViewModel : ViewModelBase
	{
        public PostATaskViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Post a task";
        }
	}
}
