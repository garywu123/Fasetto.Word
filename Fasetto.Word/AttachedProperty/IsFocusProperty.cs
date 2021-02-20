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
    ///     Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusProperty : BaseAttachedProperty<IsFocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            base.OnValueChanged(sender, e);

            // if we don't have a control return
            if (!(sender is System.Windows.Controls.Control control))
            {
                return;
            }
            // Focus this control once loaded.
            control.Loaded += (s, se) => control.Focus();
        }
    }
}