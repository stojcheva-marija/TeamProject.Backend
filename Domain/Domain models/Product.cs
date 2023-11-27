using Domain.Enums;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Domain_models
{
    public class Product : BaseEntity
    {
        public string ProductDescription { get; set; }
        [Required]
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string ProductMeasurements { get; set; }
        public string ProductBrand { get; set; }
        public string ProductMaterial { get; set; }
        public Condition Condition { get; set; }
        public string ProductColor { get; set; }
        public ClothingSubcategory? ProductSubcategory { get; set; }
        public Size? ProductSize { get; set; } 
        public int? ProductSizeNumber { get; set; } 
        public float ProductPrice { get; set; }
        public bool ProductAvailablity { get; set; }
        //public IFormFileCollection ProductImages { get; set; }

        public string ProductImage { get; set; }
        public Sex ProductSex { get; set; }
        [ForeignKey("ShopApplicationUserId")]
        public ShopApplicationUser ShopApplicationUser { get; set; }
        public virtual List<ProductInShoppingCart> ProductsInShoppingCart { get; set; }
    }
}
