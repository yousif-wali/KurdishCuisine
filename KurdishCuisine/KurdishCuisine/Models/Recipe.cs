using System;
namespace KurdishCuisine.Models
{
	public class Recipe
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public MeasurmentUnitEnum Unit { get; set; }
		public double? Measurement { get; set; }

        public Recipe()
        {
            Measurement = null;
            Unit = MeasurmentUnitEnum.Grams; 
        }
    }
}

