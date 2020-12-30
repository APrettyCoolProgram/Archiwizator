/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.ArchiwizatorMain.xaml.cs
 * UPDATED: 12-29-2020-4:51 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.IO;
using System.Windows;
using System.Windows.Controls;
using Du;

namespace Archiwizator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enables/disables the textboxes that contains sub-directories to remove information.
        /// </summary>
        /// <remarks>This handles both sub-directory list boxes.</remarks>
        private static void ModifyRemoveSubDirectoryTextBoxes(TextBox txbx, bool isEnabled)
        {
            DuTextBox.SetIsEnabled(txbx, isEnabled);
            DuTextBox.SaveTextAndClear(txbx);
        }

        /// <summary>
        /// Enables/disables the btnStart control.
        /// </summary>
        /// <remarks>The Archiwizate button is only enabled if there is a valid source folder.</remarks>
        private void ModifyArchiwizateButton()
        {
            if(txbxSource.Text != "")
            {
                btnArchiwizate.IsEnabled = Directory.Exists(txbxSource.Text);
            }
        }

        /// <summary>
        /// Prompts the user to choose a folder.
        /// </summary>
        private void ChooseSource()
        {
            txbxSource.Text = DuFolderDialog.GetFolderPath();
        }

        /// <summary>
        /// Start Archiwizator.
        /// </summary>
        private void Archiwizate()
        {
            var archiwizator = new DuArchiwizator()
            {
                SourcePath                     = txbxSource.Text,
                PostfixDateStamp               = (bool)ckbxPrependDateStamp.IsChecked,
                ExtractRootArchives            = (bool)ckbxExtractRootArchives.IsChecked,
                ExtractSubDirectoryArchives    = (bool)ckbxExtractSubDirectoryArchives.IsChecked,
                //RemoveDirectoriesThatStartWith = (bool)ckbxRemoveSubDirectoriesStartingWith.IsChecked, // This is disabled in the current release.
                //DirectoriesThatStartWith       = txbxRemoveSubDirectoriesStartingWith.Text,            // This is disabled in the current release.
                RemoveDirectoriesNamed         = (bool)ckbxRemoveSubDirectoriesNamed.IsChecked,
                DirectoriesNamed               = txbxRemoveSubDirectoriesNamed.Text
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

        // EVENT HANDLERS
        private void btnChooseSource_Click(object sender, RoutedEventArgs e)
        {
            ChooseSource();
        }

        // This is disabled in the current release.
        private void btnChooseDestination_Click(object sender, RoutedEventArgs e)
        {
            //ChooseDestination();
        }

        private void txbxSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModifyArchiwizateButton();
        }

        // This is disabled in the current release.
        private void txbxDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ModifyArchiwizateButton();
        }

        private void btnArchiwizate_Click(object sender, RoutedEventArgs e)
        {
            Archiwizate();
        }

        private void ckbxRemoveSubDirectoriesNamed_CheckChanged(object sender, RoutedEventArgs e)
        {
            ModifyRemoveSubDirectoryTextBoxes(txbxRemoveSubDirectoriesNamed, (bool)ckbxRemoveSubDirectoriesNamed.IsChecked);
        }

        // This is disabled in the current release.
        //private void ckbxRemoveSubDirectoriesStartingWith_CheckChanged(object sender, RoutedEventArgs e)
        //{
        //    ModifyRemoveSubDirectoryTextBoxes(txbxRemoveSubDirectoriesStartingWith, (bool)ckbxRemoveSubDirectoriesStartingWith.IsChecked);
        //}
    }
}
