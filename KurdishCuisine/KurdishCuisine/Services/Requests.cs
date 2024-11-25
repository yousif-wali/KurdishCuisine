using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace KurdishCuisine.Services
{
	public static class Requests
	{
        public static async Task<string> RequestFilePermissionsAsync()
        {
            try
            {
                // Request permissions for reading and writing external storage
                var status = await Permissions.RequestAsync<Permissions.StorageRead>();

                // Check if permission is granted
                if (status == PermissionStatus.Granted)
                {
                    // Permission granted, proceed with file picker
                    return "Granted";
                }
                else
                {
                    // Permission denied
                    return "Permission to access files denied.";
                }
            }
            catch (Exception ex)
            {
                // Handle permission request errors
                return $"Error: {ex.Message}";
            }
        }
    }
}

