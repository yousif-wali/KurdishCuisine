using System;
using System.Collections.Generic;

namespace KurdishCuisine.Models
{
	public class Likes
	{
		public User User { get; set; }
		public List<Post> Like { get; set; }
		public Likes()
		{
			Like = new List<Post>();
		}
	}
}

