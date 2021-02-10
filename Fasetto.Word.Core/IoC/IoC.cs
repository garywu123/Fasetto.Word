#region License

// author:         吴经纬
// created:        12:34
// description:

#endregion

using Fasetto.Word.Core.ViewModel;
using Ninject;

namespace Fasetto.Word.Core.IoC
{
    /// <summary>
    ///     The IoC container for our application
    /// </summary>
    public class IoC
    {
        /// <summary>
        ///     The Kernel for our IoC Container
        /// </summary>
        public static IKernel Kernel { get; } = new StandardKernel();

        /// <summary>
        ///     Gets a service from from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }


        #region Construction

        /// <summary>
        ///     Sets up the IoC Container, binds all information required and is ready for
        ///     use
        ///     Note: Must be called as soon as your application starts up to ensure all.
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        /// <summary>
        ///     Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of application view model
            // Kernel.Bind<ApplicationViewModel>().ToSelf().InSingletonScope();
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion
    }
}