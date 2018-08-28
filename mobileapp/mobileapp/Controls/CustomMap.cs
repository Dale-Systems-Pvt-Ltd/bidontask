using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace mobileapp.Controls
{
    internal class VisibleAreaChangeAssistant
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMiliSeconds { get; set; }
        System.Threading.Timer waitTimer;

        public VisibleAreaChangeAssistant(int waitingMiliSecs = 2000)
        {
            WaitingMiliSeconds = waitingMiliSecs;
            waitTimer = new System.Threading.Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void VisibleAreaChanged()
        {
            waitTimer.Change(WaitingMiliSeconds, System.Threading.Timeout.Infinite);
        }
    }

    public class CustomPin: Pin
    {
        public int Id { get; set; }
    }
    public class CustomMap: Map
    {
        //Todo: What happens when internet connection is lost.


        VisibleAreaChangeAssistant visibleAreaChangeAssistant;
        public CustomMap()
        {
            
            visibleAreaChangeAssistant = new VisibleAreaChangeAssistant();
            visibleAreaChangeAssistant.Idled += VisibleAreaChangeAssistant_Idled;
            PropertyChanged += CustomMap_PropertyChanged;
        }

        private void VisibleAreaChangeAssistant_Idled(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                //Console.WriteLine("Area changed :" + DateTime.Now.ToLongTimeString());
                if (VisibleRegionChangedCommand != null) VisibleRegionChangedCommand.Execute(VisibleRegion);
            });
        }

        private void CustomMap_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName== "VisibleRegion") visibleAreaChangeAssistant.VisibleAreaChanged();
        }

        private ObservableCollection<CustomPin> customPins;
        public ObservableCollection<CustomPin> CustomPins
        {
            get
            {
                return customPins;
            }
            set
            {
                if (Pins != null) Pins.Clear();

                customPins = value;
                if (value == null) return;
                

                customPins.CollectionChanged += CustomPins_CollectionChanged;

                if (Pins != null)
                {                    
                    foreach (var customPin in customPins)
                    {
                        Pins.Add(customPin);
                        customPin.Clicked += CustomPin_Clicked;
                    }
                }

            }
        }

        private void CustomPin_Clicked(object sender, EventArgs e)
        {
            if (CustomPinClickedCommand != null) CustomPinClickedCommand.Execute(sender as CustomPin);
        }

        private void CustomPins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count > 0)
            {
                if (Pins != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        Pins.Add(item as CustomPin);
                        ((CustomPin)item).Clicked += CustomPin_Clicked;
                    }

                    //var firstItem = e.NewItems[0] as CustomPin;
                    ////var moveTo = new MapSpan(firstItem.Position, firstItem.Position.Latitude, firstItem.Position.Longitude);
                    //var moveTo = MapSpan.FromCenterAndRadius(firstItem.Position, Distance.FromMiles(10));
                    //MoveToRegion(moveTo);
                }
            }
            if (CustomPins.Count == 0) Pins.Clear();
        }

        public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create("CustomPins", typeof(ObservableCollection<CustomPin>),
            typeof(CustomMap), new ObservableCollection<CustomPin>(), BindingMode.OneWay, null, CustomPinsPropertyChanged);

        private static void CustomPinsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomMap)bindable).CustomPins = newValue as ObservableCollection<CustomPin>;
        }

        public DelegateCommand<MapSpan> VisibleRegionChangedCommand { get; set; }

        public static readonly BindableProperty VisibleRegionChangedCommandProperty = BindableProperty.Create("VisibleRegionChangedCommand",
            typeof(DelegateCommand<MapSpan>), typeof(CustomMap),
            null, BindingMode.TwoWay, null, VisibleRegionChanged);

        private static void VisibleRegionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomMap)bindable).VisibleRegionChangedCommand = newValue as DelegateCommand<MapSpan>;
        }


        public DelegateCommand<CustomPin> CustomPinClickedCommand { get; set; }

        public static readonly BindableProperty CustomPinClickedCommandProperty = BindableProperty.Create("CustomPinClickedCommand",
            typeof(DelegateCommand<CustomPin>), typeof(CustomMap),
            null, BindingMode.OneWay, null, OnCustomPinClicked);

        private static void OnCustomPinClicked(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomMap)bindable).CustomPinClickedCommand = newValue as DelegateCommand<CustomPin>;
        }


        //public bool Contains(Position point)
        //{


        //    var bounds = new  Bounds(GetMapVisibleSouthWest(), GetMapVisibleNorthEast());

        //    if (bounds.Contains(point))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public Position GetMapVisibleSouthWest()
        {
            var halfHeightDegrees = VisibleRegion.LatitudeDegrees / 2;
            var halfWidthDegrees = VisibleRegion.LongitudeDegrees / 2;

            var left = VisibleRegion.Center.Longitude - halfWidthDegrees;
            var bottom = VisibleRegion.Center.Latitude - halfHeightDegrees;
            return new Position(bottom, left);
        }

        public Position GetMapVisibleNorthEast()
        {
            var halfHeightDegrees = VisibleRegion.LatitudeDegrees / 2;
            var halfWidthDegrees = VisibleRegion.LongitudeDegrees / 2;

            var right = VisibleRegion.Center.Longitude + halfWidthDegrees;
            var top = VisibleRegion.Center.Latitude + halfHeightDegrees;
            return new Position(top, right);
        }
    }
}
