#region License

// author:         吴经纬
// created:        18:39
// description:

#endregion

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word.Animation
{
    /// <summary>
    ///     Animation helpers for <see cref="Storyboard" />. This class contains all
    ///     the page
    ///     animation in this app.
    /// </summary>
    public static class StoryboardHelper
    {
        /// <summary>
        ///     Add the slide and fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance of the right to start from</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        public static void AddSlideFromRight(this Storyboard storyboard,
                                             float seconds,
                                             double offset,
                                             float decelerationRatio = 0.9f,
                                             bool keepMargin = true)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 从界面的右边出发
                From = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                // 到原本 page 应该显示的地方
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Add the slide and fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance of the left to start from</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        public static void AddSlideFromLeft(this Storyboard storyboard,
                                            float seconds,
                                            double offset,
                                            float decelerationRatio = 0.9f,
                                            bool keepMargin = true)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 从界面的右边出发
                From = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                // 到原本 page 应该显示的地方
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Add the slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance of the left to end at</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        public static void AddSlideToLeft(this Storyboard storyboard,
                                          float seconds,
                                          double offset,
                                          float decelerationRatio = 0.9f,
                                          bool keepMargin = true)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            Debug.WriteLine($"Is Keep Margin: {(keepMargin ? offset : 0)}", "Debug");

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 到原本 page 应该显示的地方
                From = new Thickness(0),
                // 到页面的左面
                To = new Thickness(-offset, 0, keepMargin ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Add the slide to right animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        /// <param name="offset">the distance of the Right to end at</param>
        /// <param name="decelerationRatio">the rate of deceleration</param>
        /// <param name="keepMargin"> Whether to keep the element at the same width during animation</param>
        public static void AddSlideToRight(this Storyboard storyboard,
                                           float seconds,
                                           double offset,
                                           float decelerationRatio = 0.9f,
                                           bool keepMargin = true)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 从原本 page 应该显示的地方
                From = new Thickness(0),
                // 到页面的右面
                To = new Thickness(keepMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = decelerationRatio
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Add the slide from right fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        public static void AddSlideFadeIn(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 从界面的右边出发
                From = 0,
                To = 1
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }

        /// <summary>
        ///     Add the slide fade out to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">the time the animation will take</param>
        public static void AddSlideFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            // Thickness相当于定义了起始点和终点
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                // 设置 Opacity 的起始值和终点至
                From = 1,
                To = 0
            };
            // 将动画应用在目标元素的margin属性上
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            // storyboard 设置动画，并设置哪个元素需要使用动画
            storyboard.Children.Add(animation);
        }
    }
}