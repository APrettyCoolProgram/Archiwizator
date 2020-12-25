/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.SevenZip.cs
 * UPDATED: 12-25-2020-9:27 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

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
        public static void Create(DuSevenZip sz)
        {
            var subDirectories = DuDirectory.GetSubDirectoryNames(sz.SevenZipArgs.SourcePath);

            var numberOfSubDirectories = subDirectories.Count;
            var currSubDirectoryCount = 1;

            foreach(var subDirectory in subDirectories)
            {
                var cmd = DuSevenZip.BuildSevenZipCommand(sz);


            }










            //var dirsToDelete = DuString.ToListAtDelimiter(directoriesToDelete, ',');

            //foreach(var subDirectory in subDirectories)
            //{
            //    var sourceDirectory = $"{folderPath}{subDirectory}\\";
            //    var archiveFilePath = "";

            //    if(deleteSpecificDirectories)
            //    {
            //        var subSubDirectories = DuDirectory.GetSubDirectoryNames(sourceDirectory);

            //        foreach(var subsub in subSubDirectories)
            //        {
            //            if(directoriesToDelete.Contains(subsub))
            //            {
            //                DuDirectory.Delete($"{sourceDirectory}{subsub}\\");
            //            }
            //        }
            //    }

            //    if(uncompressFilesBeforeCompressing)
            //    {
            //        var files = DuDirectory.GetFileNames(sourceDirectory);

            //        foreach(var file in files)
            //        {
            //            var fileExtension = file.Extension.ToLower();




            //            if(fileExtension == ".zip")
            //            {
            //                var fi = Path.GetFileNameWithoutExtension(file.FullName);

            //                archiveFilePath = $"{file.FullName}";
            //                var extractCommand = $"x {archiveFilePath} -o{sourceDirectory}{fi}";
            //                DuSevenZip.ExtractToDirectory(sevenZipExecutablePath, archiveFilePath, extractCommand);
            //            }



            //        }
            //    }

            //    if(prependDateStamp)
            //    {
            //        var dt = DateTime.Now.ToString("yyMMdd");

            //        archiveFilePath = $"{folderPath}{subDirectory}-{dt}.7z";
            //    }
            //    else
            //    {
            //        archiveFilePath = $"{folderPath}{subDirectory}.7z";
            //    }

            //    var archiveCommand = "";

            //    if(deleteOriginalFolder)
            //    {
            //        archiveCommand = $"a {compressionLevel} \"{archiveFilePath}\" \"{sourceDirectory}*\" -sdel";
            //    }
            //    else
            //    {
            //        archiveCommand = $"a {compressionLevel} \"{archiveFilePath}\" \"{sourceDirectory}*\"";
            //    }

            //    if(deleteOriginalFolder)
            //    {
            //        DuDirectory.Delete(sourceDirectory);
            //    }

            //    lblProgress.Content = $"PROGRESS: File {currSubDirectoryCount} of {numberOfSubDirectories}: {subDirectory}";
            //    Refresh(lblProgress);

            //    DuSevenZip.CreateFromDirectory(sevenZipExecutablePath, archiveFilePath, archiveCommand);



            //    currSubDirectoryCount++;
            //}

            //lblProgress.Content = $"PROGRESS: COMPLETE!";
        }
    }
}
