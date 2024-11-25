using KurdishCuisine.Models;
using Xamarin.Forms;
using KurdishCuisine.Services;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System;
using Xamarin.Essentials;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KurdishCuisine.Views
{	
	public partial class Post : ContentPage
	{
        private ObservableCollection<FileItem> _fileItems;

        public Post ()
		{
			InitializeComponent ();
            _fileItems = new ObservableCollection<FileItem>();
            FilesListView.ItemsSource = _fileItems;
        }

		protected override void OnAppearing()
		{
            base.OnAppearing();
			if (!CurrentUser.IsLoggedin())
			{
				new PostServices().GoingBack();
			}
        }

        private async void OnPickFileButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (Requests.RequestFilePermissionsAsync().Result != "Granted")
                {
                    throw new Exception("Permission is not Granted");
                }
                // Let the user pick an image or video
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
            {
                { DevicePlatform.Android, new[] { "image/*", "video/*" } },
                { DevicePlatform.iOS, new[] { "public.image", "public.movie" } },
                { DevicePlatform.UWP, new[] { ".jpg", ".png", ".mp4", ".mov" } }
            })
                });

                if (result != null)
                {
                    var filePath = result.FullPath;
                    var fileType = result.FileName.ToLower();

                    // Check if the file is a video or image based on the file extension
                    if (fileType.EndsWith(".mp4") || fileType.EndsWith(".mov"))
                    {
                        // For videos, use a thumbnail (placeholder for simplicity)
                        var thumbnailPath = "video_thumbnail.png"; // Placeholder thumbnail for video
                        _fileItems.Add(new FileItem { FilePath = filePath, FileThumbnail = thumbnailPath });
                    }
                    else
                    {
                        // For images, display the image itself
                        _fileItems.Add(new FileItem { FilePath = filePath, FileThumbnail = filePath });
                    }

                    FilesListView.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Error: {ex.Message}";
            }
        }

        // File selection in the ListView (if you want to handle individual file actions)
        private void OnFileSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as FileItem;
            if (selectedItem != null)
            {
                // Handle file selection if needed
            }
        }

        // Upload Button click handler
        private async void OnUploadButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Loop through each selected file and upload
                foreach (var fileItem in _fileItems)
                {
                    await UploadFileAsync(fileItem);
                }
                StatusLabel.Text = "Files uploaded successfully!";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Upload failed: {ex.Message}";
            }
        }
        private async Task UploadFileAsync(FileItem fileItem)
        {
            // Open the file stream
            var fileStream = File.OpenRead(fileItem.FilePath);

            // Prepare the content for upload
            var formContent = new MultipartFormDataContent();
            var fileContent = new StreamContent(fileStream);
            fileContent.Headers.Add("Content-Type", "application/octet-stream");
            formContent.Add(fileContent, "file", fileItem.FileName);

            // Upload the file to the server
            var httpClient = new HttpClient();
            var apiUrl = "https://yourapi.com/upload"; // Replace with your API URL
            var response = await httpClient.PostAsync(apiUrl, formContent);

            if (response.IsSuccessStatusCode)
            {
                StatusLabel.Text = "File uploaded successfully!";
            }
            else
            {
                StatusLabel.Text = "Error uploading file.";
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var filePath = button?.CommandParameter.ToString();

            // Find and remove the file item from the list based on the file path
            var fileToRemove = _fileItems.FirstOrDefault(item => item.FilePath == filePath);
            if (fileToRemove != null)
            {
                _fileItems.Remove(fileToRemove);
            }
        }

    }
}

