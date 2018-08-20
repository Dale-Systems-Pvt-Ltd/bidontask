using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mobileapp.ViewModels
{
    public class MyBadgeViewModel
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }
	public class MyBadgesViewModel : ViewModelBase
	{
        public MyBadgesViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "My Badges";
        }

        private ObservableCollection<MyBadgeViewModel> itemsSource = new ObservableCollection<MyBadgeViewModel>();
        public ObservableCollection<MyBadgeViewModel> ItemsSource
        {
            get { return itemsSource; }
            set { SetProperty(ref itemsSource, value); }
        }

        private bool showNoDataMessage = true;
        public bool ShowNoDataMessage
        {
            get { return showNoDataMessage; }
            set { SetProperty(ref showNoDataMessage, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            ReadBadgesData();
            if (ItemsSource.Count > 0) ShowNoDataMessage = false;
        }

        private void ReadBadgesData()
        {
            this.ItemsSource.Add(new MyBadgeViewModel
            {
                Icon = "email",
                Name = "Email Verified Badge",
                Details = "Email prakashdale@gmail.com verified on 05/01/2018" 
            });
            this.ItemsSource.Add(new MyBadgeViewModel
            {
                Icon = "phone_android",
                Name = "Mobile Verified",
                Details = "Phone 987654321 verified on 05/01/2018"
            });
            this.ItemsSource.Add(new MyBadgeViewModel
            {
                Icon = "payment",
                Name = "Paypal Payment Verified",
                Details = "Verified on 05/01/2018"
            });
        }


    }
}
