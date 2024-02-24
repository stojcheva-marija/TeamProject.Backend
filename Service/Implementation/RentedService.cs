﻿using Domain.Domain_models;
using Domain.DTO;
using Repository.Implementation;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Implementation
{
    public class RentedService : IRentedService
    {
        public readonly IRepository<Rented> _rentedRepository;
        public readonly IUserRepository _userRepository;


        public RentedService(
       IRepository<Rented> rentedRepository,
       IUserRepository userRepository,
       IRepository<ProductInRented> productInRentedRepository)
        {
            this._rentedRepository = rentedRepository;
            this._userRepository = userRepository;
        }
        public List<ProductInRented> getRentedInfo(string email)
        {
            var loggInUser = _userRepository.GetByEmail( email);
            var userRented = loggInUser.UserRented;
            //TO DO: da se naprai ova so lambda, mozhe da se renta i si go izrental
            DateTime CurrentDate = DateTime.Now;
            //filtrive posle sea testing  .Where(p => p.Product.ProductAvailablity == false && p.Product.ProductRent == true && p.EndDate<CurrentDate)
            var productsList = userRented.ProductsInRented.ToList();
            return productsList;
        }

        //returned -- toj shto stava items ZA rentanje 
        public bool deleteProductFromRented(string email, int productId)
        {
            if (!string.IsNullOrEmpty(email) && productId != null)
            {
                var loggInUser = _userRepository.GetByEmail(email);
                var userRented = loggInUser.UserRented;
                var itemToDelete = userRented.ProductsInRented.Where(z => z.ProductId.Equals(productId)).FirstOrDefault();
                userRented.ProductsInRented.Remove(itemToDelete);
                _rentedRepository.Update(userRented);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
