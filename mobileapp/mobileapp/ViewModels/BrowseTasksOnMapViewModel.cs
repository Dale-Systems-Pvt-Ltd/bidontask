using mobileapp.Controls;
using mobileapp.Models;
using mobileapp.Repo;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace mobileapp.ViewModels
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/map
    /// https://developer.xamarin.com/samples/xamarin-forms/CustomRenderers/Map/Pin/
    /// </summary>
	public class BrowseTasksOnMapViewModel : ViewModelBase
	{
        public DelegateCommand<MapSpan> VisibleRegionChangedCommand { get; }
        public DelegateCommand<CustomPin> CustomPinClickedCommand { get; }
        public BrowseTasksOnMapViewModel(INavigationService navigationService, IJobRepo jobRepo): base(navigationService)
        {
            VisibleRegionChangedCommand = new DelegateCommand<MapSpan>(VisibleRegionChanged);
            CustomPinClickedCommand = new DelegateCommand<CustomPin>(async (pin) => await CustomPinClickedAsync(pin));
           _jobRepo = jobRepo;
        }


        private async Task<bool> CustomPinClickedAsync(CustomPin pin)
        {

            return true;
        }
        private void VisibleRegionChanged(MapSpan obj)
        {
            var excludeIds = customPins.Select(x => x.Id).ToArray();
            var jobPins = _jobRepo.GetJobMapPinsInRegion(obj, excludeIds);
            Console.WriteLine("Browse: " + obj.Center.Latitude + " " + obj.Center.Longitude);
            Console.WriteLine("lat degree" + obj.LatitudeDegrees);
            Console.WriteLine("lon degree" + obj.LongitudeDegrees);
            
            foreach (JobMapPin item in jobPins)
            {
                var position = new Position(item.Latitude, item.Longitude);
                var pin = new CustomPin
                {
                    Id = item.Id,
                    Type = PinType.Place,
                    Position = position,
                    Label = item.Name,
                    Address = item.Description
                };
                CustomPins.Add(pin);
            }
        }

        private ObservableCollection<CustomPin> customPins = new ObservableCollection<CustomPin>();
        private readonly IJobRepo _jobRepo;

        public ObservableCollection<CustomPin> CustomPins
        {
            get { return customPins; }
            set { SetProperty(ref customPins, value); }
        }

        //public override async void OnNavigatedTo(NavigationParameters parameters)
        //{
        //    var address = "52 Greenwoods, Sus Road, Baner, Pune - 411045";
        //    var locations = await Geocoding.GetLocationsAsync(address);
        //    var location = locations?.FirstOrDefault();
        //    if(location != null)
        //    {
        //        var position = new Position(location.Latitude, location.Longitude);
        //        var pin = new CustomPin
        //        {
        //            Type = PinType.Place,
        //            Position = position,
        //            Label = "52, Greenwoods",
        //            Address = address
        //        };
        //        customPins.Add(pin);
        //    }
            
        //}

        
    }
}
