using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;
using Du;


namespace Archiwizator
{
    public class SevenZip
    {
        private static readonly Action EmptyDelegate = delegate { };

        /// <summary>
        /// Refresh the progress label.
        /// </summary>
        /// <param name="label">The progress label.</param>
        public static void Refresh(Label label)
        {
            label.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }

        /// <summary>
        /// Create an archive.
        /// </summary>
        /// <param name="folderPath">Path to the folder to archive.</param>
        /// <param name="compressLevel">The compression level.</param>
        /// <param name="lblProgress">The progress indicator</param>
        /// <param name="deleteOriginalFolder">Determines if the original folder should be deleted after archiving.</param>
        public static void Create(string folderPath, string compressLevel, Label lblProgress, bool deleteOriginalFolder, bool prependDateStamp, bool deleteSpecificDirectories, string directoriesToDelete, bool uncompressFilesBeforeCompressing)
        {
            var subDirectories= DuDirectory.GetSubDirectoryNames(folderPath);

            var compressionLevel = compressLevel switch
            {
                "Fastest" => "-mx1",
                "Fast"    => "-mx3",
                "Normal"  => "-mx5",
                "Maximum" => "-mx7",
                "Ultra"   => "-mx9",
                _         => "-mx0",
            };

            var sevenZipExecutablePath = DuOperatingSystem.MSWindows.Is64Bit()
                ? @"./resources/Bin/7Zip/64bit/7za.exe"
                : @"./resources/Bin/7Zip/32bit/7za.exe";

            var numberOfSubDirectories = subDirectories.Count;
            var currSubDirectoryCount = 1;

            var dirsToDelete = DuString.ToListAtDelimiter(directoriesToDelete, ',');

            foreach(var subDirectory in subDirectories)
            {
                var sourceDirectory = $"{folderPath}{subDirectory}\\";
                var archiveFilePath = "";

                if(deleteSpecificDirectories)
                {
                    var subSubDirectories = DuDirectory.GetSubDirectoryNames(sourceDirectory);

                    foreach(var subsub in subSubDirectories)
                    {
                        if(directoriesToDelete.Contains(subsub))
                        {
                            DuDirectory.Delete($"{sourceDirectory}{subsub}\\");
                        }
                    }
                }

                if(uncompressFilesBeforeCompressing)
                {
                    var files = DuDirectory.GetFileNames(sourceDirectory);

                    foreach(var file in files)
                    {
                        var fileExtension = file.Extension.ToLower();




                        if(fileExtension == ".zip")
                        {
                            var fi = Path.GetFileNameWithoutExtension(file.FullName);

                            archiveFilePath = $"{file.FullName}";
                            var extractCommand = $"x {archiveFilePath} -o{sourceDirectory}{fi}";
                            DuCompression.SevenZip.ExtractToDirectory(sevenZipExecutablePath, archiveFilePath, extractCommand);
                        }



                    }
                }

                if(prependDateStamp)
                {
                    var dt = DateTime.Now.ToString("yyMMdd");

                    archiveFilePath = $"{folderPath}{subDirectory}-{dt}.7z";
                }
                else
                {
                    archiveFilePath = $"{folderPath}{subDirectory}.7z";
                }

                var command = $"a {compressionLevel} \"{archiveFilePath}\" \"{sourceDirectory}*\"";

                lblProgress.Content = $"PROGRESS: File {currSubDirectoryCount} of {numberOfSubDirectories}: {subDirectory}";
                Refresh(lblProgress);

                DuCompression.SevenZip.CreateFromDirectory(sevenZipExecutablePath, archiveFilePath, command);

                if(deleteOriginalFolder)
                {
                    DuDirectory.Delete(sourceDirectory);
                }

                currSubDirectoryCount++;
            }

            lblProgress.Content = $"PROGRESS: COMPLETE!";
        }
    }
}
