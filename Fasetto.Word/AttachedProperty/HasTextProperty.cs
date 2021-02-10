#region License

// author:         吴经纬
// created:        22:31
// description:

#endregion

using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word.AttachedProperty
{


    /// <summary>
    ///     The MonitorPassword attached property for a <see cref="PasswordBox" />
    /// </summary>
    public class
        MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender,
                                            DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool) e.NewValue)
            {
                // Set the default value
                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when the password box changed its text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox) sender);
        }
    }


    /// <summary>
    ///     The HasText attached property for a <see cref="PasswordBox" />
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        ///     Sets the HasText property based on if the caller <see cref="PasswordBox" />
        ///     has any text.
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender,
                ((PasswordBox) sender).SecurePassword.Length > 0);
        }
    }
}