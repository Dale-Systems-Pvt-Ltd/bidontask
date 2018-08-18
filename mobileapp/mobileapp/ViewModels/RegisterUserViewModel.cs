using mobileapp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mobileapp.ViewModels
{
	public class RegisterUserViewModel : ViewModelBase
	{
        public DelegateCommand GotoSetupPasswordCommand { get; }
        public DelegateCommand GotoTermsAndConditionsCommand { get; }
        public RegisterUserViewModel(INavigationService navigationService): base(navigationService)
        {
            Title = "Register";
            GotoSetupPasswordCommand = new DelegateCommand(GotoSetPassword);
            GotoTermsAndConditionsCommand = new DelegateCommand(GotoTermsAndConditions);
        }

        private async void GotoTermsAndConditions()
        {
            await NavigationService.NavigateAsync("TermsAndConditions");
        }

        private async void GotoSetPassword()
        {
            var user = new User();
            user.Email = Email;
            user.Mobile = Mobile;

            var parameters = new NavigationParameters();
            parameters.Add("User", user);
            await NavigationService.NavigateAsync("/NavigationPage/RegisterUserSetPassword", parameters);
        }

        private string firstNameLabel;
        public string FirstNameLabel
        {
            get { return firstNameLabel; }
            set { SetProperty(ref firstNameLabel, value); }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set {
                if (SetProperty(ref firstName, value))
                {

                    if (!string.IsNullOrEmpty(firstName)) FirstNameLabel = "First Name";
                    else FirstNameLabel = "";
                }
            }
        }

        private string lastNameLabel;
        public string LastNameLabel
        {
            get { return lastNameLabel; }
            set { SetProperty(ref lastNameLabel, value); }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set {
                if (SetProperty(ref lastName, value))
                {
                    if (!string.IsNullOrEmpty(lastName)) LastNameLabel = "Last Name";
                    else LastNameLabel = "";
                }
            }
        }

        private string nameIcon = Utils.MaterialIcons.perm_identity.ToString();
        public string NameIcon
        {
            get { return nameIcon; }
            set { SetProperty(ref nameIcon, value); }
        }

        private string emailLabel;
        public string EmailLabel
        {
            get { return emailLabel; }
            set { SetProperty(ref emailLabel, value); }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set {
                if (SetProperty(ref email, value))
                {
                    if (!string.IsNullOrEmpty(email)) EmailLabel = "Email";
                    else EmailLabel = "";
                }
            }
        }

        private string emailIcon = Utils.MaterialIcons.email.ToString();
        public string EmailIcon
        {
            get { return emailIcon; }
            set { SetProperty(ref emailIcon, value); }
        }

        private string mobileLabel;
        public string MobileLabel
        {
            get { return mobileLabel; }
            set { SetProperty(ref mobileLabel, value); }
        }

        private string mobile;
        public string Mobile
        {
            get { return mobile; }
            set {
                if (SetProperty(ref mobile, value))
                {
                    if (!string.IsNullOrEmpty(mobile)) MobileLabel = "Mobile";
                    else Mobile = "";
                }
            }
        }
        private string mobileIcon = Utils.MaterialIcons.phone_android.ToString();
        public string MobileIcon
        {
            get { return mobileIcon; }
            set { SetProperty(ref mobileIcon, value); }
        }

        private string addressLabel;
        public string AddressLabel
        {
            get { return addressLabel; }
            set { SetProperty(ref addressLabel, value); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set {
                if (SetProperty(ref address, value))
                {
                    if (!string.IsNullOrEmpty(address)) addressLabel = "Address";
                    else Address = "";
                }
            }
        }

        private string addressIcon = Utils.MaterialIcons.my_location.ToString();
        public string AddressIcon
        {
            get { return addressIcon; }
            set { SetProperty(ref addressIcon, value); }
        }

        private string cityLabel;
        public string CityLabel
        {
            get { return cityLabel; }
            set { SetProperty(ref cityLabel, value); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set {
                if (SetProperty(ref city, value))
                {
                    if (!string.IsNullOrEmpty(city)) CityLabel = "City";
                    CityLabel = "";
                }
            }
        }

        private string zipCodeLabel;
        public string ZipCodeLabel
        {
            get { return zipCodeLabel; }
            set { SetProperty(ref zipCodeLabel, value); }
        }

        private string zipCode;
        public string ZipCode
        {
            get { return zipCode; }
            set {
                if (SetProperty(ref zipCode, value))
                {
                    if (!string.IsNullOrEmpty(zipCode)) ZipCodeLabel = "Zip Code";
                    else ZipCodeLabel = "";
                }
            }
        }

        
    }
}
