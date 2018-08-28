using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using mobileapp.Controls;
using mobileapp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace mobileapp.Droid.Renderers
{
    /// <summary>
    /// https://github.com/xamarin/xamarin-forms-samples/blob/master/CustomRenderers/Map/Pin/Droid/CustomMapRenderer.cs
    /// </summary>
    class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        ObservableCollection<CustomPin> customPins;
        public CustomMapRenderer(Context context): base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
                
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                Control.GetMapAsync(this);

                
            }
        }

       

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            //if (!string.IsNullOrWhiteSpace(customPin.Url))
            //{
                //var url = Android.Net.Uri.Parse(customPin.Url);
                //var intent = new Intent(Intent.ActionView, url);
                //intent.AddFlags(ActivityFlags.NewTask);
                //Android.App.Application.Context.StartActivity(intent);
            //}
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in customPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
            //pin.Clicked += Pin_Clicked;
            return marker;
        }

        private void Pin_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("marker clicked");
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (customPin.Type == PinType.Place)
                {
                    //view = inflater.Inflate(Resource.Layout.TaskInfoWindow, null);
                }
                else
                {
                    //view = inflater.Inflate(Resource.Layout.TaskInfoWindow, null);
                }

                    //var infoTitle = view.FindViewById<TextView>(Resource.Id.taskWindowTitle1);
                    //var infoSubtitle = view.FindViewById<TextView>(Resource.Id.taskWindowSubTitle1);

                //if (infoTitle != null)
                //{
                //    infoTitle.Text = marker.Title;
                //}
                //if (infoSubtitle != null)
                //{
                //    infoSubtitle.Text = marker.Snippet;
                //}

                return null;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}