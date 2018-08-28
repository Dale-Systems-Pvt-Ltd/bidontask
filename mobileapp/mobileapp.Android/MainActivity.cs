using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using Plugin.Permissions;
using Prism;
using Prism.Ioc;

namespace mobileapp.Droid
{
    [Activity(Label = "Bid On Task", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


            var config = new PayPalConfiguration(PayPalEnvironment.Sandbox, "AUSqNHjhcdaugdDElFFQHr0GxqWLPgKnfb_TZ-sQhVrS3OaPdOkdax6Pbs22QQKugw3eZtmpSJEgd3yE")
            {
                //If you want to accept credit cards
                AcceptCreditCards = true,
                //Your business name
                MerchantName = "BidOnTask.com",
                //Your privacy policy Url
                MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
                //Your user agreement Url
                MerchantUserAgreementUri = "https://www.example.com/legal",
                // OPTIONAL - ShippingAddressOption (Both, None, PayPal, Provided)
                ShippingAddressOption = ShippingAddressOption.None,
                // OPTIONAL - Language: Default languege for PayPal Plug-In
                Language = "en",
                // OPTIONAL - PhoneCountryCode: Default phone country code for PayPal Plug-In
                PhoneCountryCode = "1",
                
            };


            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            CrossPayPalManager.Init(config, this);
            Xamarin.FormsMaps.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            PayPalManagerImplementation.Manager.OnActivityResult(requestCode, resultCode, data);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if(PayPalManagerImplementation.Manager != null) PayPalManagerImplementation.Manager.Destroy();
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

