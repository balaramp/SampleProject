using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities
{
    public class Order : IdObject
    {

        private readonly List<OrderItem> _items = new List<OrderItem>();

        public IEnumerable<OrderItem> Items => _items.AsReadOnly();
        //public decimal TotalAmount => _items.Sum(item => item.TotalPrice);

        private Guid _userId;
        private decimal _totalAmount;
        private DateTime _createdAt;
        private DateTime _updated;
        private string _status = "Pending";
        private int _totalAMount;

        public Guid UserId 
        { 
            get => _userId;
            set => _userId = value; 
        }

        public void SetItems(IEnumerable<OrderItem> items)
        {
            _items.AddRange(items);
        }

        public DateTime CreatedAt 
        { 
            get => _createdAt; 
            set => _createdAt = value; 
        }
        public DateTime UpdatedAt 
        {
            get => _updated;
            set => _updated = value;
        }
        public string Status 
        { 
            get => _status; 
            set => _status = value; 
        }

        public int TotalAmount
        {
            get => _totalAMount;
            set => _totalAMount = value;
        }
    }
}
