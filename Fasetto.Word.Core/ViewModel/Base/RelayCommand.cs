#region License
// author:         吴经纬
// created:        16:57
// description:
#endregion

using System;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core.ViewModel.Base
{
    /// <summary>
    /// 将这个 Command 和一个 Button 绑定，只需要传入一个 Action 来运行
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        /// <summary>
        /// 这个 Command 一直可以用
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {

            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        /// <summary>
        /// The event that fired when <see cref="CanExecute"/> value has changed.
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) =>
        {
            
        };
    }
}