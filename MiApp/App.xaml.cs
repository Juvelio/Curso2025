namespace MiApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            QuitarSubrayado();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        void QuitarSubrayado()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("QuitarSubrayado", (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.Background = null;
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.Background = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);
                Microsoft.UI.Xaml.Media.SolidColorBrush transparentBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Transparent);
                handler.PlatformView.BorderBrush = transparentBrush;
#endif
            });
        }
    }
}