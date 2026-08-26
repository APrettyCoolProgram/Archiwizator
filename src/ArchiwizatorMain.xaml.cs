/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.ArchiwizatorMain.xaml.cs
 * UPDATED: 12-31-2020-1:28 PM
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
        /// <summary>Default constructor.</summary>
        public MainWindow()
        {
            InitializeComponent();

            SetupArchiwizator(this);
        }

        /// <summary>Setup Archiwizator when it launches.</summary>
        /// <param name="archiwizatorMainWindow">The Archiwizinator MainWindow object.</param>
        private static void SetupArchiwizator(Window archiwizatorMainWindow)
        {
            archiwizatorMainWindow.Title = $"Archiwizator v{DuApplication.GetApplicationVersion()}";
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

        // EVENT HANDLERS
        private void btnChooseSource_Click(object sender, RoutedEventArgs e) => ChooseSource();

        private void txbxSource_TextChanged(object sender, TextChangedEventArgs e) => ModifyArchiwizateButton();

        private void btnArchiwizate_Click(object sender, RoutedEventArgs e) => Archiwizate();

        private void ckbxRemoveSubDirectoriesNamed_CheckChanged(object sender, RoutedEventArgs e) => ModifyRemoveDirectoryTextBoxes();

        /*  These event handlers are placeholders for functionality that is not yet implemented.
         */

        private void ckbxRemoveSubDirectoriesStartingWith_CheckChanged(object sender, RoutedEventArgs e)
        {
        }

        private void txbxDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnChooseDestination_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}