using System;
using Xamarin.Forms;
namespace KurdishCuisine.Services
{
	public static class Navigate
	{
		public static async void To(Page page)
		{
			await Shell.Current.Navigation.PushAsync(page);
		}
		public static async void PopToRootAsync()
		{
            await Shell.Current.Navigation.PopToRootAsync();
        }

    }
}

