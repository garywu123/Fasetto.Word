#region License
// author:         吴经纬
// created:        16:21
// description:
#endregion

using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;
using WPF_Advanced.Annotations;

namespace WPF_Advanced.Directory.DirectoryViewModel
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
    }
}