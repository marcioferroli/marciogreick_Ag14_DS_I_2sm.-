
using HotelAurora.Models;
using HotelAurora.Views;

namespace HotelAurora
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            CheckInPicker.MinimumDate = DateTime.Today;
            CheckInPicker.Date = DateTime.Today.AddDays(1);

            DateTime entrada =
                CheckInPicker.Date.GetValueOrDefault();

            CheckOutPicker.MinimumDate = entrada.AddDays(1);
            CheckOutPicker.Date = entrada.AddDays(2);
        }

        private void OnAdultosChanged(
            object sender, ValueChangedEventArgs e)
        {
            AdultosLabel.Text = e.NewValue.ToString();
        }

        private void OnCriancasChanged(
            object sender, ValueChangedEventArgs e)
        {
            CriancasLabel.Text = e.NewValue.ToString();
        }

        private void OnCheckInDateSelected(
            object sender, DateChangedEventArgs e)
        {
            DateTime novaData =
                e.NewDate.GetValueOrDefault();

            CheckOutPicker.MinimumDate = novaData.AddDays(1);

            DateTime saida =
                CheckOutPicker.Date.GetValueOrDefault();

            if (saida <= novaData)
            {
                CheckOutPicker.Date = novaData.AddDays(1);
            }
        }

        private async void OnReservarClicked(
            object sender, EventArgs e)
        {
            if (AccommodationPicker.SelectedIndex < 0)
            {
                await DisplayAlert(
                    "Atenção",
                    "Selecione uma acomodação.",
                    "OK");

                return;
            }

            decimal[] valores = { 280m, 420m, 520m };

            Reserva reserva = new Reserva
            {
                Hospede = HospedeEntry.Text?.Trim() ?? "",

                Adultos = (int)AdultosStepper.Value,

                Criancas = (int)CriancasStepper.Value,

                Acomodacao =
                    AccommodationPicker.SelectedItem.ToString()!,

                CheckIn =
                    CheckInPicker.Date.GetValueOrDefault(),

                CheckOut =
                    CheckOutPicker.Date.GetValueOrDefault(),

                ValorDiaria =
                    valores[AccommodationPicker.SelectedIndex]
            };

            if (!reserva.Validar(out string mensagem))
            {
                await DisplayAlert(
                    "Dados inválidos",
                    mensagem,
                    "Corrigir");

                return;
            }

            App.ServicoReservas.Adicionar(reserva);

            ResultadoLabel.Text =
                $"Reserva registrada! {reserva.Diarias} diária(s).";

            await DisplayAlert(
                "Reserva confirmada",
                $"Hóspede: {reserva.Hospede}\n" +
                $"Acomodação: {reserva.Acomodacao}\n" +
                $"Diárias: {reserva.Diarias}\n" +
                $"Valor total: {reserva.Total:C}",
                "OK");
        }

        private async void OnHistoricoClicked(
            object sender, EventArgs e)
        {
            await Navigation.PushAsync(
                new ReservationsPage());
        }
    }
}
