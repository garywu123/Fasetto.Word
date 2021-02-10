#region License

// author:         吴经纬
// created:        22:31
// description:

#endregion

using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fasetto.Word.AttachedProperty
{
    /// <summary>
    ///     The NoFrameHistory attached property for creating a <see cref="Frame" />
    ///     that never shows navigation and keeps the navigation history empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender,
                                            DependencyPropertyChangedEventArgs e)
        {
            
            var frame = (sender as Frame);
            // Hide Navigation bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            // clear history 
            frame.Navigated += (ss, ee) =>
                ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}