
using HotelAurora.Services;
using HotelAurora.Views;

namespace HotelAurora
{
    public partial class App : Application
    {
        public static ReservaService ServicoReservas { get; } =
            new ReservaService();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromArgb("#14243A"),
                BarTextColor = Colors.White
            };
        }
    }
}
