/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.MainWindow.xaml.cs
 * UPDATED: 12-28-2020-11:20 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

using System.IO;
using System.Windows;
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
        }

        public void SetLogo()
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            var ass2 = ass.ToString();
            var bm = DuBitmap.FromUri(ass, "./Resources/Asset/Image/Logo/archiwizator-575x150.png");
            imgLogo.Source = bm;

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

        /// <summary>Enables/disables the txbxSpecificDirectoriesToDeleteBeforeCompressing control.</summary>
        private void ModifyTxbxSpecificDirectoriesToDeleteBeforeCompressingState()
        {
            txbxSpecificDirectoriesToDeleteBeforeCompressing.IsEnabled = (bool)ckbxDeleteDirectoriesBeforeCompressing.IsChecked;
        }

        /// <summary>Enables/disables the btnStart control.</summary>
        private void ModifyStartButtonState()
        {
            if(txbxFolderChoice.Text != "")
            {
                btnStart.IsEnabled = Directory.Exists(txbxFolderChoice.Text);
            }
        }

        /// <summary>Prompts the user to choose a folder.</summary>
        private void ChooseFolder()
        {
            txbxFolderChoice.Text = DuFolderDialog.GetFolderPath();
        }

        private void Start()
        {
            var az = new DuArchiwizator()
            {
                SourcePath                            = txbxFolderChoice.Text,
                PostfixDateStamp                      = (bool)ckbxPrependDateStamp.IsChecked,
                RemoveDirectoriesPriorToCompression   = (bool)ckbxDeleteDirectoriesBeforeCompressing.IsChecked,
                DirectoriesToRemovePriorToCompression = txbxSpecificDirectoriesToDeleteBeforeCompressing.Text,
                UncompressPriorToCompression          = (bool)ckbxUncompressFilesBeforeCompressing.IsChecked
            };

            var sz = new DuSevenZip()
            {
                Action                      = "a",
                SourcePath                  = az.SourcePath,
                DestinationPath             = az.SourcePath,
                CompressionLevel            = (string)cmbxCompressionLevel.SelectedItem,
                DeleteFilesAfterCompression = (bool)ckbxDeleteSourceAfterCompressing.IsChecked
            };

            DuArchiwizator.Create(az, sz, lblProgressOverview, lblProgressDetails);
        }

        // EVENT HANDLERS
        private void btnFolderChoice_Click(object sender, RoutedEventArgs e)                                     => ChooseFolder();
        private void txbxFolderChoice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => ModifyStartButtonState();
        private void btnStart_Click(object sender, RoutedEventArgs e)                                            => Start();
        private void ckbxDeleteDirectoriesBeforeCompressing_Checked(object sender, RoutedEventArgs e)            => ModifyTxbxSpecificDirectoriesToDeleteBeforeCompressingState();
    }
}
