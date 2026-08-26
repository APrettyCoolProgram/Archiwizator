// =============================================================================
// Archiwizator
// A totally metal archiver
// https://github.com/APrettyCoolProgram/Archiwizator)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2016-2022 A Pretty Cool Program
// =============================================================================
//
// -----------------------------------------------------------------------------
// About Archiwizator v1.0.0.0-b220522+dev105821
// -----------------------------------------------------------------------------
// Archiwizator is a archiving application.
//
// More information soon.
// 
// More information: https://github.com/APrettyCoolProgram/Archiwizator#readme
// Development notes: <url>

// MainWindow.xaml.cs
// Archiwizator main window.
// b220522.105828

using System.Windows;

namespace Archiwizator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Entry point for Archiwizator
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            SetTitleBarText();
        }

        /// <summary>
        ///     Sets the title bar text
        /// </summary>
        private void SetTitleBarText()
        {
            Title = $"Archiwizator v{Du.WithAssembly.GetInfo("informationalVersion")}";
        }

        private void ControlStatuses()
        {
            if(chbxExtractExistingRootArchives.IsChecked == true)
            {
                chbxExtractExistingRootArchivesInTarget.IsEnabled = true;

            }
        }

    }
}
