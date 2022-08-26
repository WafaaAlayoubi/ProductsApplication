using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApplication.Models
{
    public class ProductModelDTO
    {
        public ProductModelDTO(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;

            PriceString = string.Format("{0:C}", price);
            ShortDescription = description.Length < 25 ? description : description.Substring(0, 25);

            Tax = price * 0.08M; 
        }

        public ProductModelDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", Price);
            ShortDescription = Description.Length < 25 ? Description : Description.Substring(0, 25);

            Tax = Price * 0.08M;
        }

        [DisplayName("Id Number")]
        public int Id { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

        [DisplayName("Product Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string PriceString { get; set; }

        [DisplayName("What you get ...")]
        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public decimal Tax { get; set; }

        
    }
}
