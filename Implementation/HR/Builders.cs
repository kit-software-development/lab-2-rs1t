using System;
using Practice.Common;
using Practice.Organization;

namespace Practice.HR
{
    /// <summary>
    ///     Класс-фабрика, позволяющий получать экземпляры типов,
    ///     инкапсулированных на уровне библиотеки.
    /// </summary>
    public static class Builders
    {
        private static IClientBuilder _clientBuilder;
        private static IEmployeeBuilder _employeeBuilder;

        /// <summary>
        ///     Возвращает экземпляр "Строителя" клиентов.
        /// </summary>
        /// <returns>
        ///     Экземпляр типа IClientBuilder.
        /// </returns>
        public static IClientBuilder ClientBuilder()
        {
            return _clientBuilder ?? (_clientBuilder = new ClientBuilder());
        }

        /// <summary>
        ///     Возвращает экземпляр "Строителя" сотудников.
        /// </summary>
        /// <returns>
        ///     Возвращает экземпляр типа IEmployeeBuilder.
        /// </returns>
        public static IEmployeeBuilder EmployeeBuilder()
        {
            return _employeeBuilder ?? (_employeeBuilder = new EmployeeBuilder());
        }
    }

    internal class EmployeeBuilder : IEmployeeBuilder
    {
        private IName _name;
        private IDepartment _department;

        public IEmployee Build()
        {
            if (_name == null)
                throw new ArgumentNullException(nameof(_name), "Name is required");

            var employee = new Employee
            {
                Name = _name,
                Department = _department
            };

            _name = null;
            _department = null;

            return employee;
        }

        public IEmployeeBuilder Name(IName name)
        {
            _name = name;
            return this;
        }

        public IEmployeeBuilder Name(string name, string surname, string patronymic)
        {
            return Name(
                new Name
                {
                    FirstName = name,
                    Surname = surname,
                    Patronymic = patronymic,
                });
        }

        public IEmployeeBuilder Department(IDepartment department)
        {
            _department = department;
            return this;
        }

        public IEmployeeBuilder Department(string department)
        {
            return Department(
                new Department
                {
                    Name = department,
                });
        }
    }

    internal class ClientBuilder : IClientBuilder
    {
        private IName _name;
        private float _discount;

        public IClient Build()
        {
            if (_name == null)
                throw new ArgumentNullException(nameof(_name), "Name is required");

            var client = new Client
            {
                Name = _name,
                Discount = _discount
            };

            _name = null;
            _discount = default(float);

            return client;
        }

        public IClientBuilder Name(IName name)
        {
            _name = name;
            return this;
        }

        public IClientBuilder Name(string name, string surname, string patronymic)
        {
            return Name(
                new Name
                {
                    FirstName = name,
                    Surname = surname,
                    Patronymic = patronymic,
                });
        }

        public IClientBuilder Discount(float discount)
        {
            _discount = discount;
            return this;
        }
    }
}