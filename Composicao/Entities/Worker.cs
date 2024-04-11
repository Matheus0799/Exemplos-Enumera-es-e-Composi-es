using Composicao.Entities.Enums;
using System.Collections.Generic;

namespace Composicao.Entities
{
    internal class Worker
    {

        public string? Name { get; set; } // propriedades
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department? Department { get; set; } // associei a classe Department a classe Worker
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // como são varios * vou ter que instanciar uma lista

        public Worker()
        {
        }

        public Worker(string? name, WorkerLevel level, double baseSalary, Department? department) // não inicie uma lista em um construtor
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract) // aqui instancio a lista para adicionar um contrato
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) // e para remover contrato
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary; // a soma já vai começar com o salário base!
            foreach(HourContract contract in Contracts) // para cada HourContract na minha lista de contratos eu vo fazer..
            {
                if (contract.Date.Year == year && contract.Date.Month == month) // se esse contrato da minha lista for iqual ao ano e ao mês que eu recebi como argumento, faça...
                {
                    sum += contract.TotalValue(); // soma vai receber ela mesma += mais o total do tempo trabalhado no contrato
                }
            }
            return sum; // retorno a soma(salario base + salario por tempo de trabalho)
        }

    }
}
