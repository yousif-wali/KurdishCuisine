using System;
using System.Collections.Generic;
using KurdishCuisine.Models;
using KurdishCuisine.ViewModels;
using Xamarin.Forms;
using KurdishCuisine.Services;
namespace KurdishCuisine.Views
{	
	public partial class Setting : ContentPage
	{
        public Setting ()
		{
			InitializeComponent ();
            SigninButtonAlteration();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SigninButtonAlteration();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
        }
        private void SigninButtonAlteration()
        {
            if (!CurrentUser.IsLoggedin())
            {
                SignInButton.IsEnabled = true;
                SignInButton.IsVisible = true;

                Logout.IsVisible = false;
                Logout.IsEnabled = false;

                

                UsernameText.Text = "";
            }
            else
            {
                SignInButton.IsEnabled = false;
                SignInButton.IsVisible = false;

                Logout.IsVisible = true;
                Logout.IsEnabled = true;

                UsernameText.Text = CurrentUser.Username;
            }
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            CurrentUser.Logout();
            SigninButtonAlteration();
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigate.To(new Post());
        }
    }
}

