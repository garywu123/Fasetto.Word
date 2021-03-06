﻿#region License

// author:         吴经纬
// created:        18:43
// description:

#endregion

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word.Animation
{
    /// <summary>
    ///     为 FrameworkElement 与 StoryboardHelper 绑定，设置对应的动画。
    /// </summary>
    public static class FrameworkElementAnimationsHelper
    {
        /// <summary>
        ///     Add a slide and fade in animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="width">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int width = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // Add slide from right animation
            storyBoard.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeIn(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }

        /// <summary>
        ///     Add a slide and fade in animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="width">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int width = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // Add slide from right animation
            storyBoard.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeIn(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }

        /// <summary>
        ///     Add a slide and fade out animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="width">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int width = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // // Add slide to left animation
            storyBoard.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeOut(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }

        /// <summary>
        ///     Add a slide and fade out animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="width">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int width = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // // Add slide to left animation
            storyBoard.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeOut(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }


        /// <summary>
        ///     Add a slide and fade out animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="height">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottomAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int height = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // // Add slide to left animation
            storyBoard.AddSlideFromBottom(seconds, height == 0 ? element.ActualWidth : height,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeIn(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }


        /// <summary>
        ///     Add a slide and fade out animation to the story board
        /// </summary>
        /// <param name="element"> The element that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <param name="keepMargin">
        ///     Whether to keep the element at the same width during
        ///     animation
        /// </param>
        /// <param name="height">
        ///     The animation width to animate to. If not specified the
        ///     elements width is used
        /// </param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottomAsync(
            this FrameworkElement element,
            float seconds = 0.3f,
            bool keepMargin = true,
            int height = 0)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // // Add slide to left animation
            storyBoard.AddSlideToBottom(seconds, height == 0 ? element.ActualWidth : height,
                keepMargin: keepMargin);
            // Add slide fade In
            storyBoard.AddSlideFadeOut(seconds);

            storyBoard.Begin(element);
            // storyboard开始，以为这动画开始，那么我们将 element 显示出来
            element.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int) (seconds * 1000));
        }
    }
}