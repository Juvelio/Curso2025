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
#if ANDROID
                //SOLO EJECUTA ANDROID
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.Background = null;
#elif IOS
                //SOLO EJECUTA iOS
#endif

            });
        }
    }
}