using System;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
namespace KurdishCuisine.Services
{
	public class PostServices
	{
		public PostServices()
		{
		}

        public async void GoingBack()
        {
            await Shell.Current.Navigation.PopAsync();
            await Application.Current.MainPage.DisplayToastAsync("Please Login first", 2000);
        }
    }
}

