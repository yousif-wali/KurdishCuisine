using System;
using Xamarin.Forms;
using KurdishCuisine.Views;
using System.ComponentModel;
using KurdishCuisine.Models;
using Plugin.Toast;
using Xamarin.CommunityToolkit.Extensions;
using KurdishCuisine.Services;

namespace KurdishCuisine.ViewModels
{
    public class SettingViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private bool _signinButtonEnable; 

        public bool SigninButtonEnable
        {
            get { return _signinButtonEnable; }
            set
            {
                 _signinButtonEnable = value;
                 OnPropertyChanged();        
            }
        }


        public Command SignIn { get; }
        public Command Logout { get; }

        public SettingViewModel()
        {
            SignIn = new Command(SignInDirection);
        }
        private async void SignInDirection()
        {
            // Perform navigation
            Navigate.To(new LoginPage());
        }
    }
}
