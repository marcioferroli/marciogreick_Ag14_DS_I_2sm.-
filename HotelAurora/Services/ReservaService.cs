
using HotelAurora.Models;

namespace HotelAurora.Services
{
    public class ReservaService
    {
        private readonly List<Reserva> reservas = new();

        public IReadOnlyList<Reserva> Reservas =>
            reservas.AsReadOnly();

        public void Adicionar(Reserva reserva)
        {
            reservas.Add(reserva);
        }
    }
}
