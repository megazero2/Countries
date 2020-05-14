using Countries.Views;
using Countries.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Countries.ViewModels
{
    class LoginViewModel
    {
        private UserAccounts userAccounts = new UserAccounts();

        public UserAccounts UserAccounts
        {
            get { return userAccounts; }
            set
            {
                userAccounts = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    if (UserAccounts.Username == "test@domain.com" && UserAccounts.Password == "abc123")
                    {

                        await App.Current.MainPage.Navigation.PushAsync(new CountriesPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Notification", "Try again", "Ok");
                    }
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
