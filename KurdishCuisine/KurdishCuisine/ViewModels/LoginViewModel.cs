using KurdishCuisine.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using KurdishCuisine.Models;
using System.Threading;
using KurdishCuisine.Services;

namespace KurdishCuisine.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command SignupCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignupCommand = new Command(OnSignupClicked);
        }

        private void OnLoginClicked(object obj)
        {
            // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            CurrentUser.Update("Admin", "admin@gmail.com");
            Navigate.PopToRootAsync();
        }
        private void OnSignupClicked()
        {
            Navigate.To(new Signup());
        }
    }
}

