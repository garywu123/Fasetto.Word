#region License

// author:         吴经纬
// created:        16:00
// description:

#endregion

using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word.AttachedProperty
{
    public class PasswordAttachedProperty
    {
        public static readonly DependencyProperty
            MonitorPasswordProperty =
                DependencyProperty.RegisterAttached("MonitorPassword",
                    typeof(bool),
                    typeof(PasswordAttachedProperty),
                    new PropertyMetadata(false,
                        OnMonitorPasswordChanged));

        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText",
                typeof(bool),
                typeof(PasswordAttachedProperty),
                new PropertyMetadata(false));


        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool) element.GetValue(MonitorPasswordProperty);
        }

        public static void SetMonitorPassword(PasswordBox element,
                                              bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        public static void SetHasText(PasswordBox element, bool value)
        {
            element.SetValue(HasTextProperty,
                element.SecurePassword.Length > 0);
        }

        public static bool GetHasText(PasswordBox element)
        {
            return (bool) element.GetValue(HasTextProperty);
        }

        public static void OnMonitorPasswordChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            // MessageBox.Show("Start to monitor password changed");

            var passwordBox = d as PasswordBox;

            if (passwordBox == null) return;

            // 清除之前的事件handler
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if (!(bool) e.NewValue) return;
            /*
             * 当你开始设置监视PasswordBox的时候，触发 Monitor 事件
             * 然后根据 PasswordBox 中的文字长度设置 HasText 的值
             */
            SetHasText(passwordBox, true);
            // 然后注册 PasswordChanged 事件
            passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(object sender,
                                                        RoutedEventArgs e)
        {
            // MessageBox.Show("Password Changed.");
            SetHasText((PasswordBox) sender, true);
        }
    }
}