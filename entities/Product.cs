using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public string? Img { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();
}
