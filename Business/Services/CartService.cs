﻿using DAL;
using Exceptions;
using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repo)
        {
            _repository = repo;
        }

        public Cart AddItemToCart(Cart cart)
        {
            var cartItem = _repository.AddItemToCart(cart);
            if(cartItem == null)
            {
                throw new Exception("Item is not added to the cart");
            }
            else
            {
                return cartItem;
            }
        }

        public bool DeleteACartItem(int id)
        {
            if (_repository.DeleteACartItem(id))
            {
                return true;
            }
            else
            {
                throw new CartItemNotFoundException($"Cart with id: {id} does not exist");
            }
        }

        public List<Cart> GetAllCartItemByUserId(int userId)
        {
            if (_repository.GetAllCartItemByUserId(userId) != null)
            {
                return _repository.GetAllCartItemByUserId(userId);
            }
            else
            {
                throw new UserNotFoundException($"User with id: {userId} does not exist");
            }
        }
    }
}
