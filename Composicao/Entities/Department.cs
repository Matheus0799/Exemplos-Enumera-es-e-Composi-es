
namespace Composicao.Entities
{
    internal class Department
    {

        public string? Name { get; set; } // propriedade

        public Department() // construtor padrão
        {
        }

        public Department(string name)
        {
            Name = name;
        }

    }
}
