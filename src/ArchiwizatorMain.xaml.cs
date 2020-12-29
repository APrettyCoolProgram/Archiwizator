/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.ArchiwizatorMain.xaml.cs
 * UPDATED: 12-29-2020-11:49 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Du;

namespace Archiwizator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetLogo();
            SetCompressionLevelOptions();
            SetCompressionmethodOptions();
        }

        /// <summary>Setup the Archiwizator logo.</summary>
        public void SetLogo()
        {
            var assemblyName           = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            BitmapImage bitmapLogo     = DuBitmap.FromUri(assemblyName, "./Resources/Asset/Image/Logo/archiwizator-575x150.png");
            imgArchiwizatorLogo.Source = bitmapLogo;
        }

        /// <summary>Setup the compression level options.</summary>
        /// <remarks>These options mirror the options available in 7-Zip.</remarks>
        private void SetCompressionLevelOptions()
        {
            // TODO: This should eventually be moved to the .xaml file.
            cmbxCompressionLevel.Items.Add("Store");
            cmbxCompressionLevel.Items.Add("Fastest");
            cmbxCompressionLevel.Items.Add("Fast");
            cmbxCompressionLevel.Items.Add("Normal");
            cmbxCompressionLevel.Items.Add("Maximum");
            cmbxCompressionLevel.Items.Add("Ultra");

            cmbxCompressionLevel.SelectedIndex = 3;
        }

        /// <summary>Setup the compression method options.</summary>
        /// <remarks>These options mirror the options available in 7-Zip.</remarks>
        private void SetCompressionmethodOptions()
        {
            // TODO: This should eventually be moved to the .xaml file.
            cmbxCompressionMethod.Items.Add("LZMA2");
            cmbxCompressionMethod.Items.Add("LZMA");
            cmbxCompressionMethod.Items.Add("PPMd");
            cmbxCompressionMethod.Items.Add("BZip2");

            cmbxCompressionMethod.SelectedIndex = 0;
        }


        /// <summary>Enables/disables the txbxSpecificDirectoriesToDeleteBeforeCompressing control.</summary>
        private void ModifyTxbxSpecificDirectoriesToDeleteBeforeCompressingState()
        {
            txbxRemoveDirectoriesThatStartWith.IsEnabled = (bool)ckbxRemoveSubDirectoriesThatStartWith.IsChecked;
        }

        /// <summary>Enables/disables the btnStart control.</summary>
        private void ModifyStartButtonState()
        {
            if(txbxFolderChoice.Text != "")
            {
                btnArchiwizate.IsEnabled = Directory.Exists(txbxFolderChoice.Text);
            }
        }

        /// <summary>Prompts the user to choose a folder.</summary>
        private void ChooseFolder()
        {
            txbxFolderChoice.Text = DuFolderDialog.GetFolderPath();
        }

        /// <summary>Start Archiwizator.</summary>
        private void Start()
        {
            var archiwizator = new DuArchiwizator()
            {
                SourcePath                            = txbxFolderChoice.Text,
                PostfixDateStamp                      = (bool)ckbxPrependDateStamp.IsChecked,
                ExtractRootArchives                   = (bool)ckbxExtractRootArchives.IsChecked,
                ExtractSubDirectoryArchives           = (bool)ckbxExtractSubDirectoryArchives.IsChecked,
                RemoveDirectoriesThatStartWith        = (bool)ckbxRemoveSubDirectoriesThatStartWith.IsChecked,
                DirectoriesThatStartWith              = txbxRemoveDirectoriesThatStartWith.Text,
                RemoveDirectoriesNamed                = (bool)ckbxRemoveSubDirectoriesNamed.IsChecked,
                DirectoriesNamed                      = txbxRemoveDirectoriesNamed.Text
            };

            var sevenZip = new DuSevenZip()
            {
                Action                       = "a",
                SourcePath                   = archiwizator.SourcePath,
                DestinationPath              = archiwizator.SourcePath,
                CompressionLevel             = (string)cmbxCompressionLevel.SelectedItem,
                DeleteSourceAfterCompression = (bool)ckbxDeleteSourceAfterCompressing.IsChecked
            };

            DuArchiwizator.CreateArchive(archiwizator, sevenZip, lblProgressOverview, lblProgressDetails);
        }

        // EVENT HANDLERS
        private void btnFolderChoice_Click(object sender, RoutedEventArgs e) => ChooseFolder();
        private void txbxFolderChoice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => ModifyStartButtonState();
        private void btnArchiwizate_Click(object sender, RoutedEventArgs e) => Start();
        private void ckbxDeleteDirectoriesBeforeCompressing_Checked(object sender, RoutedEventArgs e) => ModifyTxbxSpecificDirectoriesToDeleteBeforeCompressingState();
    }
}
