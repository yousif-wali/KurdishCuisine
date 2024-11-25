using System;
namespace KurdishCuisine.Models
{
	public class Report
	{
		private string Reporter { get { return CurrentUser.Username; } }
		public Post Reporting { get; set; }
		public string Reason { get; set; }
		public DateTime ReportTime { get; set; }
	}
}

