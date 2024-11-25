using System;
namespace KurdishCuisine.Interfaces
{
	public interface IPost
	{
		bool IsFileUploaded();
		bool IsInsertedInDatabase();
	}
}

