using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace mobileapp.ViewModels
{
    public class MyPostedTaskViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NoOfOffers { get; set; }
        public string Offers { get; set; }
        public string ProfileImage { get; set; }
        public string Status { get; set; }
    }
    public class MyPostedTasksViewModel : ViewModelBase
	{
        public MyPostedTasksViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "My Posted Tasks";
        }

        private ObservableCollection<MyPostedTaskViewModel> itemsSource = new ObservableCollection<MyPostedTaskViewModel>();
        public ObservableCollection<MyPostedTaskViewModel> ItemsSource
        {
            get { return itemsSource; }
            set { SetProperty(ref itemsSource, value); }
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            ReadMyJobssAsync();
        }

        private bool ReadMyJobssAsync()
        {
            this.ItemsSource.Add(new MyPostedTaskViewModel
            {
                Id = 1,
                Name = "Bathtub faucet leakage",
                Offers = "Budget: $50 Min Offer: $35 Max Offer: $100",
                NoOfOffers = "2 Offers",
                ProfileImage = "work6.jpg",
                Status = "Draft"
            });

            this.ItemsSource.Add(new MyPostedTaskViewModel
            {
                Id = 2,
                Name = "Shelvinng/cabinetry for 2 closets",
                NoOfOffers = "1 Offers",
                Offers = "Budget: $350 Min Offer: $500",
                ProfileImage = "work3.jpg",
                Status = "Open for bidding"
            });

            return true;
        }
    }
}
