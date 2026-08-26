/* PROJECT: Archiwizator (https://github.com/aprettycoolprogram/Archiwizator)
 *    FILE: Archiwizator.ArchiwizatorMain.EventHandlers.cs
 * UPDATED: 1-27-2021-9:24 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2020 A Pretty Cool Program All rights reserved
 */

/* This class contains the event handlers for ArchiwizatorMain.xaml.cs
 */

using System.Windows;
using System.Windows.Controls;

namespace Archiwizator
{
    public partial class ArchiwizatorMain
    {
        private void btnChooseSource_Click(object sender, RoutedEventArgs e) => ChooseSource();
        private void txbxSource_TextChanged(object sender, TextChangedEventArgs e) => ModifyArchiwizateButton();
        private void btnArchiwizate_Click(object sender, RoutedEventArgs e) => Archiwizate();
        private void ckbxRemoveSubDirectoriesNamed_CheckChanged(object sender, RoutedEventArgs e) => ModifyRemoveDirectoryTextBoxes();
        private void ckbxRemoveSubDirectoriesStartingWith_CheckChanged(object sender, RoutedEventArgs e)
        {
            // Not implemented.
        }
        private void txbxDestination_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Not implemented.
        }
        private void btnChooseDestination_Click(object sender, RoutedEventArgs e)
        {
            // Not implemented.
        }
    }
}
