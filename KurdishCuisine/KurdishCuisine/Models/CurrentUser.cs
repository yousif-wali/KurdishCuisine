using System;
namespace KurdishCuisine.Models
{
	public static class CurrentUser
	{
		public static string Username { get; set; }
		public static string Email { get; set; }

		public static bool IsLoggedin()
		{
			return Username != null;
		}
		public static void Logout()
		{
			Username = null;
			Email = null;
		}
		public static void Update(string _Username, string _Email)
		{
			Username = _Username;
			Email = _Email;
		}
	}
}

