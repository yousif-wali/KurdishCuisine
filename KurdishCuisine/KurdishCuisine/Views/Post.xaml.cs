using System;
using System.Collections.Generic;
using KurdishCuisine.Models;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using KurdishCuisine.Services;

namespace KurdishCuisine.Views
{	
	public partial class Post : ContentPage
	{	
		public Post ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
            base.OnAppearing();
			if (!CurrentUser.IsLoggedin())
			{
				new PostServices().GoingBack();
			}
        }
		
	}
}

