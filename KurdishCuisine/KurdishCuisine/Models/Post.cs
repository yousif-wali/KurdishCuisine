using System;
using System.Collections.Generic;

namespace KurdishCuisine.Models
{
	public class Post
	{
		// Post id
		public int PostId { get; set; }
		// For user id whom published the post
		public User Publisher { get; set; }
		// Title of the post
		public string Title { get; set; }
		// Description of the post
		public string Description { get; set; }
		// Any Images/Videos have been uploaded
		public List<string> Sources { get; set; }
		// List of Recipes
		public List<Recipe> Recipes { get; set; }
		// Published Date
		public string PublishedAt { get; set; }
		// Viewer number
		public int Viewers { get; set; } = 0;

        public Post()
        {
            Recipes = new List<Recipe>();
            Sources = new List<string>();
        }
    }
}

