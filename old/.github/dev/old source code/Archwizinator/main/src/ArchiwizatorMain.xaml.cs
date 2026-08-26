/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.ArchiwizatorMain.xaml.cs
 * UPDATED: 1-27-2021-9:29 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* Event handlers are located in ArchiwizatorMain.EventHandlers.cs.
 */

using System.IO;
using System.Windows;
using Du;

namespace Archiwizator
{
    public partial class ArchiwizatorMain : Window
    {
        /// <summary>Default constructor.</summary>
        public ArchiwizatorMain()
        {
            InitializeComponent();

            SetupArchiwizator();
        }

        /// <summary>Setup Archiwizator when it launches.</summary>
        private void SetupArchiwizator()
        {
            var archiwizatorAssemblyName = DuApplication.GetAssemblyName();

            Title = $"Archiwizator v{DuApplication.GetVersionInformational()}";
            imgArchiwizatorLogo.Source = DuBitmap.FromUri(archiwizatorAssemblyName, "/Resources/Asset/Image/Logo/archiwizator-logo-575x150.png");
        }

        /// <summary>Enables/disables the textboxes that contains sub-directories to remove information.</summary>
        /// <remarks>This handles both sub-directory list boxes.</remarks>
        private void ModifyRemoveDirectoryTextBoxes()
        {
            if((bool)ckbxRemoveSubDirectoriesNamed.IsChecked)
            {
                txbxRemoveSubDirectoriesNamed.IsEnabled = true;
            }
            else
            {
                DuTextBox.SaveTextAndClear(txbxRemoveSubDirectoriesNamed);
                txbxRemoveSubDirectoriesNamed.IsEnabled = false;
            }
        }

        /// <summary>Enables/disables the btnArchiwizate control.</summary>
        /// <remarks>The Archiwizate button is only enabled if there is a valid source folder.</remarks>
        private void ModifyArchiwizateButton()
        {
            if(txbxSourcePath.Text is not "")
            {
                btnArchiwizate.IsEnabled = Directory.Exists(txbxSourcePath.Text);
            }
        }

        /// <summary>Prompts the user to choose a folder.</summary>
        private void ChooseSource()
        {
            txbxSourcePath.Text = DuFolderDialog.GetFolderPath();
        }

        /// <summary>Start Archiwizator.</summary>
        private void Archiwizate()
        {
            var archiwizator = new DuArchiwizator()
            {
                SourcePath                       = txbxSourcePath.Text,
                PostfixDateStamp                 = (bool)ckbxPrependDateStamp.IsChecked,
                ExtractRootArchives              = (bool)ckbxExtractRootArchives.IsChecked,
                ExtractTargetArchives            = (bool)ckbxExtractTargetArchives.IsChecked,
                //RemoveDirectoriesThatStartWith = (bool)ckbxRemoveSubDirectoriesStartingWith.IsChecked, // This is disabled in the current release.
                //DirectoriesThatStartWith       = txbxRemoveSubDirectoriesStartingWith.Text,            // This is disabled in the current release.
                RemoveDirectoriesNamed           = (bool)ckbxRemoveSubDirectoriesNamed.IsChecked,
                DirectoriesNamed                 = txbxRemoveSubDirectoriesNamed.Text
            };

            var sevenZip = new DuSevenZip()
            {
                Action                       = "a",
                SourcePath                   = archiwizator.SourcePath,
                DestinationPath              = archiwizator.SourcePath,
                CompressionLevel             = cmbxCompressionLevel.Text,
                DeleteSourceAfterCompression = (bool)ckbxDeleteSourceAfterCompressing.IsChecked
            };

            DuArchiwizator.CreateArchive(archiwizator, sevenZip, lblProgressOverview, lblProgressDetails);
        }
    }
}