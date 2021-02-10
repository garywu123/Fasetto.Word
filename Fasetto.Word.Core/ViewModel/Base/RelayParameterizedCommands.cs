#region License

// author:         吴经纬
// created:        11:33
// description:

#endregion

using System;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core.ViewModel.Base
{
    /// <summary>
    ///     This class is the supplement of RelyCommands because RelyCommands
    ///     cannot access to the password property because it is encrypted.
    /// </summary>
    public class RelayParameterizedCommands : ICommand
    {
        #region Property

        private readonly Action<object> _action;

        #endregion

        #region Contructor

        public RelayParameterizedCommands(Action<object> action)
        {
            _action = action;
        }

        #endregion

        #region Command Execution

        /// <summary>
        ///     这个 Command 一直可以用
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            // MessageBox.Show("Can Executed");
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        /// <summary>
        ///     The event that fired when <see cref="CanExecute" /> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) =>
        {
            
        };

        #endregion
    }
}