#region License

// author:         吴经纬
// created:        20:49
// description:

#endregion

using System;
using System.Windows;

namespace Fasetto.Word.AttachedProperty
{
    /// <summary>
    ///     A base attached property to replace the vanilla WPF attached property
    ///     A single instance.
    /// </summary>
    /// <typeparam name="TParent"> The parent class to be the attached property</typeparam>
    /// <typeparam name="TProperty"> The type of this attached property </typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : BaseAttachedProperty<TParent, TProperty>, new(
        ) // 这个代表了传入的Parent能够被实例化并且是 BaseAttachedProperty 的子类
    {
        #region Property

        /// <summary>
        ///     A singleton instance of our parent class.
        ///     依赖属性都是静态的，一次性注册的单例模式，所以创建一个 Instance 用来存储实例
        /// </summary>
        public static TParent Instance { get; } = new TParent();

        #endregion

        #region Attached Property Definitation

        /// <summary>
        ///     The attached property definition
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value",
                typeof(TProperty),
                typeof(BaseAttachedProperty<TParent, TProperty>),
                new UIPropertyMetadata(
                    default(TProperty),
                    OnValuePropertyChanged,
                    OnValuePropertyUpdated));

        #endregion


        /// <summary>
        ///     The callback event when <see cref="ValueProperty" /> is changed, even if it
        ///     is the same value
        /// </summary>
        /// <param name="d"> The UI element that had it's property changed </param>
        /// <param name="e"> The arguments for the event </param>
        private static object OnValuePropertyUpdated(DependencyObject d, object baseValue)
        {
            Instance.OnValueUpdated(d, baseValue);
            Instance.ValueUpdated(d, baseValue);

            return baseValue;
        }

        /// <summary>
        ///     The Callback event when the <see cref="ValueProperty" /> is changed
        /// </summary>
        /// <param name="d"> The UI element that had it's property </param>
        /// <param name="e"> The arguments for the event </param>
        private static void OnValuePropertyChanged(DependencyObject d,
                                                   DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        ///     Gets the attached property
        /// </summary>
        /// <param name="d"> The UI Element gets property from </param>
        /// <returns></returns>
        public static TProperty GetValue(DependencyObject d)
        {
            return (TProperty) d.GetValue(ValueProperty);
        }

        /// <summary>
        ///     Sets the attached property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <param name="value"> The value to set </param>
        public static void SetValue(DependencyObject d, TProperty value)
        {
            d.SetValue(ValueProperty, value);
        }

        #region Public Events

        /// <summary>
        ///     Fired when value changed.
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs>
            ValueChanged = (sender, e) => { };

        public event Action<DependencyObject, object>
            ValueUpdated = (sender, value) => { };

        #endregion


        #region Event Method

        /// <summary>
        ///     The method that is called when any attached property of this type is
        ///     changed.
        /// </summary>
        /// <param name="sender"> The UI Element that this property changed for</param>
        /// <param name="e">The arguments for this event.</param>
        public virtual void OnValueChanged(DependencyObject sender,
                                           DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        ///     The method that is called when any attached property of this type is
        ///     changed. Even the value is the same
        /// </summary>
        /// <param name="sender"> The UI Element that this property changed for</param>
        /// <param name="e">The arguments for this event.</param>
        public virtual void OnValueUpdated(DependencyObject sender,
                                           object value)
        {

        }
        #endregion
    }
}