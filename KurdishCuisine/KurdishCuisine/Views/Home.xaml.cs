using System;
using System.Collections.Generic;
using Xamarin.Forms;
using KurdishCuisine.Services;

namespace KurdishCuisine.Views
{	
	public partial class Home : ContentPage
	{	
		public Home ()
		{
			InitializeComponent ();
		}

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigate.To(new Post());
        }
    }
}

