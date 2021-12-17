using MySalonModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ICartService
    {
        List<Cart> GetAllCartItemByUserId(int userId);
        bool DeleteACartItem(int Id);
    }
}
