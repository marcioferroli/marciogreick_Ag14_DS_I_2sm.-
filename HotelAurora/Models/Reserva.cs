
namespace HotelAurora.Models
{
    public class Reserva
    {
        public string Hospede { get; set; } = "";

        public int Adultos { get; set; }

        public int Criancas { get; set; }

        public string Acomodacao { get; set; } = "";

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal ValorDiaria { get; set; }

        public int Diarias =>
            (CheckOut.Date - CheckIn.Date).Days;

        public decimal Total =>
            Diarias * ValorDiaria;

        public bool Validar(out string mensagem)
        {
            if (string.IsNullOrWhiteSpace(Hospede))
            {
                mensagem = "Informe o nome do hóspede.";
                return false;
            }

            if (Adultos < 1)
            {
                mensagem = "Informe pelo menos um adulto.";
                return false;
            }

            if (CheckOut.Date <= CheckIn.Date)
            {
                mensagem = "O check-out deve ser posterior ao check-in.";
                return false;
            }

            mensagem = "";
            return true;
        }
    }
}
