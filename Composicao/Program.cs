using Composicao.Entities.Enums;
using Composicao.Entities;
using System.Globalization;
/*
Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar
do usuário um mês e mostrar qual foi o salário do funcionário nesse mês, conforme exemplo (página 9 do pdf)
file:///D:/projetos/ArquivosCursoC%23/EnumeracoesComposisoes/09-enumeracoes-composicao.pdf
*/


internal class Program
{
    private static void Main(string[] args)
    {

        Console.Write("Enter department's name: ");
        string deptName = Console.ReadLine()!;
        Console.WriteLine("Enter worker data:");
        Console.Write("Name: "); 
        string name = Console.ReadLine()!;
        Console.Write("Level (Junior/MidLevel/Senior): ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()!); // convertendo a reposta em string para o obj WorkerLevel
        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);        

        Department dept = new Department(deptName); // instanciei o obj Departamento, para fazer a ligação do Department com o Worker
        Worker worker = new Worker(name, level, baseSalary, dept); // obj Worker, coloquei como parametro os argumentos name, level, baseSalary e dept que instanciei acima

        Console.Write("How many contracts to this worker? ");
        int n = int.Parse(Console.ReadLine()!); // criei uma variavel n para percorrer os contratos

        for (int i = 1; i <= n; i++) // criei um for para executar n vezes
        {
            Console.WriteLine($"Enter #{i} contract data:"); // $ e {i} pois o valor do argumento é n
            Console.Write("Date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!); // criei um DateTime para receber a data
            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            Console.Write("Duration (hours): ");
            int hours = int.Parse(Console.ReadLine()!);
            HourContract contract = new HourContract(date, valuePerHour, hours); // obj HourContract, vou ter que add esse contrato aqui no contrato do worker
            worker.AddContract(contract); // adicionando o contrato
        }
        Console.WriteLine();
        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string monthAndYear = Console.ReadLine()!; // vou receber o mes e o ano em formato string "10/2024" mas vou ter que recortar isso aqui já que preciso do mes e ano separados
        int month = int.Parse(monthAndYear.Substring(0, 2)); // vou utilizar a substring para separar o mês ou seja a partir do 0 pegar 2 caracteres
        int year = int.Parse(monthAndYear.Substring(3)); // fiz a mesma coisa com o ano más a partir do 3 caracter, pegar todos a diante (nesse caso 4 caracteres YYYY)
        Console.WriteLine("Name: " + worker.Name);
        Console.WriteLine("Department: " + worker.Department?.Name);
        Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
    }
}