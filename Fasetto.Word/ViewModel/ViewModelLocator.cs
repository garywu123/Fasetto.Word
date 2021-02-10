#region License

// author:         吴经纬
// created:        22:36
// description:

#endregion

using Fasetto.Word.Core.IoC;
using Fasetto.Word.Core.ViewModel;

namespace Fasetto.Word.ViewModel
{
    /// <summary>
    ///     Locates View Models form the IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///     Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel =>
            IoC.Get<ApplicationViewModel>();
    }
}