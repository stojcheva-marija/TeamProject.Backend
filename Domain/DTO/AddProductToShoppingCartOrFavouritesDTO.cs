using Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class AddProductToShoppingCartOrFavouritesDTO
    {   public Product Product { get; set; }
        public string Email { get; set; }
    }
}
