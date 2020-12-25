/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.MainWindow.xaml.cs
 * UPDATED: 12-24-2020-1:30 PM
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

            Setup();
        }

        public void Setup()
        {
            SetupControls();
        }

        private void SetupControls()
        {
            // Compression level options.
            cmbxCompressionLevel.Items.Add("Store");
            cmbxCompressionLevel.Items.Add("Fastest");
            cmbxCompressionLevel.Items.Add("Fast");
            cmbxCompressionLevel.Items.Add("Normal");
            cmbxCompressionLevel.Items.Add("Maximum");
            cmbxCompressionLevel.Items.Add("Ultra");
            cmbxCompressionLevel.SelectedIndex = 3;

            // Folder choice.
            txbxFolderChoice.Text = "";

            // Delete original folder options.
            ckbxDeleteOriginalFolder.IsEnabled = false;
            ckbxDeleteOriginalFolder.IsChecked = false;

            // Prepend date stamp options.
            ckbxPrependDateStamp.IsChecked = false;

            // Delete specific files options.
            //ckbxDeleteSpecificFilesBeforeCompressing.IsEnabled = false;
            ckbxDeleteSpecificDirectoriesBeforeCompressing.IsChecked = false;
            txbxSpecificDirectoriesToDeleteBeforeCompressing.Text    = "*temp*, *Temp*";

            // Uncompress before compressing options.
            ckbxUncompressFilesBeforeCompressing.IsEnabled = false;
            ckbxUncompressFilesBeforeCompressing.IsChecked = false;
            cmbxLevelsOfFilesToUncompressBeforeCompressing.Items.Add("1");
            cmbxLevelsOfFilesToUncompressBeforeCompressing.Items.Add("2");
            cmbxLevelsOfFilesToUncompressBeforeCompressing.Items.Add("3");

            // Start button.
            btnStart.IsEnabled = false;
        }

        private void ModifyStartButtonState()
        {
            if(txbxFolderChoice.Text != "")
            {
                btnStart.IsEnabled = Directory.Exists(txbxFolderChoice.Text);
            }
        }

        private void ChooseFolder()
        {
            txbxFolderChoice.Text = DuFolderDialog.GetFolderPath();
        }

        private void Start()
        {
            SevenZip.Create(txbxFolderChoice.Text, (string)cmbxCompressionLevel.SelectedItem, lblUpdateUser, (bool)ckbxDeleteOriginalFolder.IsChecked, (bool)ckbxPrependDateStamp.IsChecked, txbxSpecificDirectoriesToDeleteBeforeCompressing.Text);
        }

        // EVENT HANDLERS
        private void btnFolderChoice_Click(object sender, RoutedEventArgs e) => ChooseFolder();
        private void txbxFolderChoice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) => ModifyStartButtonState();
        private void btnStart_Click(object sender, RoutedEventArgs e) => Start();
    }
}
