using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class SetProfilePictureViewModel : ViewModelBase
	{
        private User user;
        public DelegateCommand GotoRegistrationCompleteCommand { get; }
        public SetProfilePictureViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Set Profile Picture";
            GotoRegistrationCompleteCommand = new DelegateCommand(GotoRegistrationComplete);
        }

        private async void GotoRegistrationComplete()
        {
            await NavigationService.NavigateAsync("/NavigationPage/RegistrationComplete");
        }

        private string cameraIcon = Utils.MaterialIcons.add_a_photo.ToString();
        public string CameraIcon
        {
            get { return cameraIcon; }
            set { SetProperty(ref cameraIcon, value); }
        }
    }
}
