using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Input;
using Xamarin.Forms;

namespace ZipAndShareExample.ViewModels
{
    public class ZipAndShareViewModel : BaseViewModel
    {
        public ZipAndShareViewModel()
        {
            Title = "Zip and Share";
        }

        public ICommand ZipAndShareCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        IsBusy = true;

                        StatusMessage = "Loading ... ";

                        //  Create a location for our data
                        var dataPath = Path.Combine(Xamarin.Essentials.FileSystem.CacheDirectory, "RandomData", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
                        Directory.CreateDirectory(dataPath);

                        //  Download and save some random data that we'll use as files to zip
                        var filesToCreate = 10;
                        for (var i = 1; i <= filesToCreate; i++)
                        {
                            StatusMessage = $"Downloading {i} of {filesToCreate} files for zipping ... ";
                            // Get some random text data to save to files
                            var uri = new Uri($"https://baconipsum.com/api/?type=meat-and-filler&paras=500&format=text");
                            string data = null;

                            using (var webClient = new WebClient())
                            {
                                data = await webClient.DownloadStringTaskAsync(uri);
                            }

                            var filePath = Path.Combine(dataPath, $"{Guid.NewGuid().ToString()}.txt");
                            //File.CreateText(filePath);
                            File.WriteAllText(filePath, data);
                        }

                        StatusMessage = "Zipping ... ";

                        //  Zip everything and present a share dialog to the user
                        await Utilities.ExportUtilties.CompressAndExportFolder(dataPath);

                        StatusMessage = "Done!";

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                });
            }
        }
    }
}