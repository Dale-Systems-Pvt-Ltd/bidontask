using Prism;
using Prism.Ioc;
using mobileapp.ViewModels;
using mobileapp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Autofac;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace mobileapp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/Login");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.RegisterForNavigation<ForgotPassword>();
            containerRegistry.RegisterForNavigation<RegisterUser>();
            containerRegistry.RegisterForNavigation<TermsAndConditions>();
            containerRegistry.RegisterForNavigation<RegisterUserSetPassword>();
            containerRegistry.RegisterForNavigation<RegisterUserConfirmEmail>();
            containerRegistry.RegisterForNavigation<RegistrationComplete>();
            containerRegistry.RegisterForNavigation<RegisterUserConfirmMobile>();
            containerRegistry.RegisterForNavigation<SetProfilePicture>();
            containerRegistry.RegisterForNavigation<WorkerProfile>();
            containerRegistry.RegisterForNavigation<MastDetail>();
            containerRegistry.RegisterForNavigation<Dashboard>();
            
        }
    }
}
