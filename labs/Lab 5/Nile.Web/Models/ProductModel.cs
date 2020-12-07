/*Mita Ghimire
 * ITSE 1430
 * Lab 4
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nile.Web.Models
{
    public ProductModel ()
    { }
    public ProductModel ( Product product )
    {
        //transform from business object to model
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        IsDiscontinued = product.IsDiscontinued;
    }

    public class ProductModel //: IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, Int32.MaxValue)]
        public string Description { get; set; }

        [Range(100, 700)]
        public decimal Price { get; set; }      

        public bool IsDiscontinued { get; set; }

     
    }
}

