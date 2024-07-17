namespace gAguirresemana7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.Estudiante());
        }
    }
}
