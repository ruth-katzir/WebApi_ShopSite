using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO;

public partial class ProductDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string? Description { get; set; }

    public double Price { get; set; }

    public string? Img { get; set; }

}
