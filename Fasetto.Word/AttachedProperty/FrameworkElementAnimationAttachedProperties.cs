#region License

// author:         吴经纬
// created:        16:50
// description:

#endregion

using System.Windows;
using Fasetto.Word.Animation;

/*
 * 为侧边栏添加一个”动画“附加属性
 * 这个属性是告诉 wpf xaml 这个侧边栏是需要实现动画的。
 * 之所以使用 ValueUpdated 而不是 ValueChanged，是因为如果我们希望在页面加载的时候动画也能实现
 * 因为这个动画属性在注册的时候默认值是 false，在启动的时候，wpf 会根据 xaml 对它在进行一遍 false 赋值
 * 我们希望当这个窗口加载时候的赋值也能够启动动画，（ValueChanged 则是只有在值不同的时候，比如从 false 变为 true 的时候才会发生）。
 * 因此我们在这里使用 ValueUpdated 事件。那 ValueUpdated 事件
 */
namespace Fasetto.Word.AttachedProperty
{

    /// <summary>
    ///     A base class to run any animation method when a boolean is set to true and
    ///     a reverse animation when set to false;
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    public abstract class AnimateBaseProperty<TParent> : BaseAttachedProperty<TParent, bool>
        where TParent : BaseAttachedProperty<TParent, bool>, new()
    {
        /// <summary>
        /// A flag indicating if this is the first time this property has been changed.
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            base.OnValueUpdated(sender, value);

            // Get the framework element
            if (!(sender is FrameworkElement element))
            {
                return;
            }
            // 获取该控件上的附加依赖属性值，如果值没有发生变化，则不作任何动作
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
            {
                return;
            }

            // 首次加载
            if (FirstLoad)
            {
                // Create a single self-unhook-able event for the elements loaded event
                void OnLoaded(object ss, RoutedEventArgs ee)
                {
                    // 当加载完成且动画执行完成后，解除“首次加载”事件的关联
                    element.Loaded -= OnLoaded;

                    // 执行动画操作
                    DoAnimationAsync(element, (bool) value);

                    FirstLoad = false;
                }

                // 当控件加载的时候，调用 OnLoaded 方法
                element.Loaded += OnLoaded;
            }
            else
            {
                DoAnimationAsync(element,(bool) value);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value changes.
        /// </summary>
        /// <param name="element"> The element </param>
        /// <param name="value"> The new value </param>
        protected virtual void DoAnimationAsync(FrameworkElement element, bool value)
        {
            
        }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show and sliding out to the left on hide.
    /// </summary>
    public class
        AnimatedSlideInFromLeftProperty : AnimateBaseProperty<
            AnimatedSlideInFromLeftProperty>
    {
        protected override async void DoAnimationAsync(FrameworkElement element, bool value)
        {
            if (value)
            {
                // 进入动画，如果是首次加载，设置动画事件为 0，让元素直接隐藏
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin:false);
            }
            else
            {
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// Animates a framework element sliding up from the bottom on show and sliding out to the bottom on hide.
    /// </summary>
    public class
        AnimateSlideInFromBottomProperty : AnimateBaseProperty<
            AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimationAsync(FrameworkElement element, bool value)
        {
            if (value)
            {
                // 进入动画，如果是首次加载，设置动画事件为 0，让元素直接隐藏
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }
}