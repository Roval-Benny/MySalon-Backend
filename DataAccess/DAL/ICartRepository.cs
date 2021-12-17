using System;
using System.Collections.Generic;
using System.Text;
using MySalonModels;

namespace DAL
{
    public interface ICartRepository
    {
        List<Cart> GetAllCartItemByUserId(int userId);
        bool DeleteACartItem(int id);
        Cart AddItemToCart(Cart cart);
    }
}
