#region License
// author:         吴经纬
// created:        18:43
// description:
#endregion

using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Fasetto.Word.Animation;

namespace Fasetto.Word.Page
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimationsHelper
    {
        /// <summary>
        /// Add a slide and fade in animation to the story board
        /// </summary>
        /// <param name="page"> The page that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(
            this System.Windows.Controls.Page page,
            float seconds)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();

            // Add slide from right animation
            storyBoard.AddSlideFromRight(seconds, page.WindowWidth);
            // Add slide fade In
            storyBoard.AddSlideFadeIn(seconds);

            storyBoard.Begin(page);
            // storyboard开始，以为这动画开始，那么我们将 page 显示出来
            page.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int)(seconds * 1000));

        }

        /// <summary>
        /// Add a slide and fade out animation to the story board
        /// </summary>
        /// <param name="page"> The page that needs animation </param>
        /// <param name="seconds"> The animation duration </param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(
            this System.Windows.Controls.Page page,
            float seconds)
        {
            // Create the storyboard
            var storyBoard = new Storyboard();
            // // Add slide to left animation
            storyBoard.AddSlideToLeft(seconds, page.WindowWidth);
            // Add slide fade In
            storyBoard.AddSlideFadeOut(seconds);

            storyBoard.Begin(page);
            // storyboard开始，以为这动画开始，那么我们将 page 显示出来
            page.Visibility = Visibility.Visible;

            // 等待动画结束，此时，该page的线程出于stop的状态，任何操作都不允许。
            await Task.Delay((int)(seconds * 1000));

        }
    }
}