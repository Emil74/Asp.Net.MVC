﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.Entities
{
    public class OrderItem : Entity
    {
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        [Required]
        public Order Order { get; set; } = null!;

    }
}
