#region License
// author:         吴经纬
// created:        16:21
// description:
#endregion

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PropertyChanged;

namespace Fasetto.Word.Core.ViewModel.Base
{
    /// <summary>
    /// A basic view model that fires property changed 
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BasicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        # region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set
        /// If the flag is true, that indicating the function is already running
        /// then the action is not run.
        ///
        /// If the flag is false, that indicating the function is not running. then action is run.
        /// Once the action is finished if it was run, then the flag is reset to false.
        /// </summary>
        /// <param name="updatingFlag"> The bool property flag defining if the command is already running </param>
        /// <param name="action">The action to run if the command is not ready </param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag,
                                        Func<Task> action)
        {
            /*
             * 这里使用了 Expression 来代替我们之前使用的 If 判断
             */
            // Check if the flag property is true(meaning the function is already running)
            if (updatingFlag.GetPropertyValue())
            {
                return;
            }

            // Set the property flag to true
            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                // set the property flag back to false now it's finished
                updatingFlag.SetPropertyValue(false);
            }
        }
        # endregion
    }

}