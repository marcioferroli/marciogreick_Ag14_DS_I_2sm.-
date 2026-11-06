
using Microsoft.Maui.Controls.Shapes;

namespace HotelAurora.Views
{
    public class ReservationsPage : ContentPage
    {
        public ReservationsPage()
        {
            Title = "Minhas reservas";

            BackgroundColor = Color.FromArgb("#F6F3ED");

            VerticalStackLayout layout =
                new VerticalStackLayout
                {
                    Padding = 20,
                    Spacing = 15
                };

            layout.Children.Add(new Label
            {
                Text = "HISTÓRICO DE RESERVAS",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#14243A")
            });

            if (App.ServicoReservas.Reservas.Count == 0)
            {
                layout.Children.Add(new Label
                {
                    Text = "Nenhuma reserva cadastrada.",
                    TextColor = Colors.Gray
                });
            }

            foreach (var reserva in
                     App.ServicoReservas.Reservas)
            {
                Border cartao = new Border
                {
                    Stroke = Color.FromArgb("#D9AD5B"),
                    StrokeThickness = 1,
                    Padding = 15,

                    StrokeShape = new RoundRectangle
                    {
                        CornerRadius = 12
                    },

                    BackgroundColor = Colors.White,

                    Content = new VerticalStackLayout
                    {
                        Spacing = 7,

                        Children =
                        {
                            new Label
                            {
                                Text = reserva.Hospede,
                                FontSize = 18,
                                FontAttributes =
                                    FontAttributes.Bold,
                                TextColor =
                                    Color.FromArgb("#14243A")
                            },

                            new Label
                            {
                                Text = reserva.Acomodacao,
                                TextColor = Colors.Gray
                            },

                            new Label
                            {
                                Text =
                                    $"Check-in: {reserva.CheckIn:dd/MM/yyyy}"
                            },

                            new Label
                            {
                                Text =
                                    $"Check-out: {reserva.CheckOut:dd/MM/yyyy}"
                            },

                            new Label
                            {
                                Text =
                                    $"Diárias: {reserva.Diarias}"
                            },

                            new Label
                            {
                                Text =
                                    $"Total: {reserva.Total:C}",
                                FontAttributes =
                                    FontAttributes.Bold,
                                TextColor =
                                    Color.FromArgb("#9B702C")
                            }
                        }
                    }
                };

                layout.Children.Add(cartao);
            }

            Content = new ScrollView
            {
                Content = layout
            };
        }
    }
}
