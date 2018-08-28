using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileapp.ViewModels
{
	public class MastDetailViewModel : ViewModelBase
	{
        private IPageDialogService _pageDialogService;
        public DelegateCommand<string> NavigateCommand { get; }
        public MastDetailViewModel(INavigationService navigationService, IPageDialogService pageDialogService): base(navigationService)
        {
            _pageDialogService = pageDialogService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private async void Navigate(string pageName)
        {
            if (pageName == "Login") await NavigationService.NavigateAsync("/Login");
            if (pageName == "BrowseTasksOnMap") await GotoBrowseTasksOnMap();
            await NavigationService.NavigateAsync("NavigationPage/" + pageName);
        }

        private async Task GotoBrowseTasksOnMap()
        {

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        //await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                        status = results[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    //var results = await CrossGeolocator.Current.GetPositionAsync(10000);
                    //LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                    await NavigationService.NavigateAsync("NavigationPage/BrowseTasksOnMap");
                }
                else if (status != PermissionStatus.Unknown)
                {
                    //await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                await _pageDialogService.DisplayAlertAsync("Error", ex.Message, "Ok");
            }


            
        }
    }
}
