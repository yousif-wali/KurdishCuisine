using System;
using System.Collections.Generic;

namespace KurdishCuisine.Models
{
	public class Favorites
	{
		public User User { get; set; }
		public List<Post> Favorite { get; set; }
		public Favorites()
		{
			Favorite = new List<Post>();
		}
	}
}

