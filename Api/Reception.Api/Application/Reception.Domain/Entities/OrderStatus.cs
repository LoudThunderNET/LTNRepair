﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reception.Domain.Entities
{
    /// <summary>
    /// Статус заказ на ремонт.
    /// </summary>
    public class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        /// <summary>
        /// Идентификатор записи.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование статуса.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Заказы.
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}
