using KurdishCuisine.Models;
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

                DeleteAccountButton.IsVisible = false;
                DeleteAccountButton.IsEnabled = false;



                UsernameText.Text = "";
            }
            else
            {
                SignInButton.IsEnabled = false;
                SignInButton.IsVisible = false;

                Logout.IsVisible = true;
                Logout.IsEnabled = true;

                DeleteAccountButton.IsEnabled = true;
                DeleteAccountButton.IsVisible = true;

                Logout.BackgroundColor = Color.Red;
                DeleteAccountButton.BackgroundColor = Color.Red;


                UsernameText.Text = CurrentUser.Username;
            }
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            CurrentUser.Logout();
            SigninButtonAlteration();
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigate.To(new Post());
        }
    }
}

