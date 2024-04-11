
namespace Composicao.Entities
{
    internal class HourContract
    {

        public DateTime Date { get; set; } // propriedades
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract() // construtor padrão
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hours) // construtor com argumentos
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour; // multipliquei valor por hora por hora trabalhada
        }

    }
}
