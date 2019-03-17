using System.Linq;

namespace Practice.Common
{
    /// <summary>
    ///     Скрытая реализация представления об имени человека.
    /// </summary>
    internal struct Name : IName
    {
        /// <summary>
        ///     Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Фамилия.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        ///     Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        public string FullName => $"{Surname} {FirstName} {Patronymic}";
        public string ShortName => $"{Surname} {FirstName.First()}. {Patronymic.First()}.";
    }
}