using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class MyTasksViewModel : ViewModelBase
	{
        public MyTasksViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "My Tasks";
        }
	}
}
