#region License

// author:         吴经纬
// created:        14:57
// description:

#endregion

using System.Windows;
using System.Windows.Input;
using Fasetto.Word.Core.DataModel;
using Fasetto.Word.Core.ViewModel.Base;
using Fasetto.Word.Window;

namespace Fasetto.Word.ViewModel
{

    /// <summary>
    ///     The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BasicViewModel
    {
        #region Constructor

        /// <summary>
        ///     基础的 ViewModel
        /// </summary>
        /// <param name="window"> ViewModel 用来控制的 Window 类对象. </param>
        public WindowViewModel(System.Windows.Window window)
        {
            _window = window;
            _window.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(CornerRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
                // Trace.WriteLine($"window state: {_window.WindowState}" +
                //                 $"window size: {_window.ActualHeight} H * {_window.ActualWidth} W");
            };

            // 添加最小化 command action
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            // 这里进行了异或操作（相同返回0），如果当前状态 == max 状态相等，则设置当前状态为 0 （也就是 Normalize——
            // 如果当前状态并不是 Max 状态，则返回 Maximized
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            // 修复窗口可能覆盖控制栏的问题
            var windowResizer = new WindowResizer(_window);
        }

        #endregion

        #region Private Helper

        /// <summary>
        ///     Get Current Mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            // 这个位置是鼠标相对于窗口的位置，如果你点击左上角，其坐标值大概在 (32,19）
            var position = Mouse.GetPosition(_window);

            // add the window pos so its a "ToScreen" 
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #endregion

        #region private field

        /// <summary>
        ///     The margin around the window to allow for a drop shadow
        /// </summary>
        private int _outMarginSize = 10;

        /// <summary>
        ///     The window that View Model Control
        /// </summary>
        private readonly System.Windows.Window _window;

        /// <summary>
        ///     Window Radius
        /// </summary>
        private int _windowRadius = 10;

        /// <summary>
        ///     The last known dock position
        /// </summary>
        private readonly WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Property

        public bool Borderless =>
            _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked;

        /// <summary>
        ///     窗口周围一圈用来让你调整窗口大小的边框的厚度
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 6;

        /// <summary>
        ///     边框的厚度是要考虑到 OuterMargin，因为 OuterMargin 是在应用外面的一圈。
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize + ResizeBorder);


        /// <summary>
        ///     The margin around the window to allow for a drop shadow.
        ///     当窗口最大化的时候，设置边框 thickness 为 0
        /// </summary>
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outMarginSize;

            set => _outMarginSize = value;
        }

        // 因为 xaml 绑定的属性需要时 thickness，因此我们为上面的尺寸属性设置一个 thickness 包装属性
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        ///     用来设置窗口边框的转角
        /// </summary>
        public int WindowRadius
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;

            set => _windowRadius = value;
        }

        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        ///     Caption Head 的高度
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + OuterMarginSize);

        /// <summary>
        ///     用于定义 Page Content 与 Drop Shadow bar 之间的距离
        /// </summary>
        public int PageContentPadding { get; set; } = 0;
        // 因为 xaml 绑定的属性需要时 thickness，因此我们为上面的尺寸属性设置一个 thickness 包装属性
        public Thickness PageContentPaddingThickness => new Thickness(PageContentPadding);

        #endregion

        #region Command

        /// <summary>
        ///     The command to minimize the Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        ///     The command to max the Window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        ///     The command to close the Window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        ///     The command to title bar icon button
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion
    }
}