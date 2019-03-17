using System;
using Practice.HR.Events;

namespace Practice.HR
{
    /// <summary>
    ///     Скрытая реализация представления о клиенте.
    /// </summary>
    internal class Client : AbstractPerson, IClient
    {
        private float _discount;
        public float Discount
        {
            get => _discount;
            set
            {
                var args = new ValueChangeEventArgs<float>(_discount);
                _discount = value;
                DiscountChange?.Invoke(this, args);
            }
        }

        public event EventHandler<ValueChangeEventArgs<float>> DiscountChange;
    }
}