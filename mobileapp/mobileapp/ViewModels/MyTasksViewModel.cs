using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mobileapp.ViewModels
{
    public class MyTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
	public class MyTasksViewModel : ViewModelBase
	{
        public MyTasksViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "My Tasks";
        }

        
    }
}
