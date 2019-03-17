using System;
using Practice.Common;
using Practice.HR;
using Practice.HR.Events;

namespace Practice
{
    /// <summary>
    ///     Цели работы:
    ///     1. на практике познакомиться с механизмом наследования;
    ///     2. научиться использовать полиморфизм;
    ///     3. научиться разделять контексты;
    ///     4. научиться использовать инкапсуляцию на уровне библиотеки;
    ///     5. научиться использовать абстрактные типы данных.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IClient client = Builders.ClientBuilder()
                .Name("Иван", "Иванов", "Иванович")
                .Discount(.1f)
                .Build();

            IEmployee employee = Builders.EmployeeBuilder()
                .Name("Григорий", "Сидоров", "Петрович")
                .Department("Бухгалтерия")
                .Build();

            Console.WriteLine(client.GetType());
            Console.WriteLine(employee.GetType());

            Console.WriteLine(client.Name.ShortName);
            Console.WriteLine(employee.Name.FullName);
        }
    }
}