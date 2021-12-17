using MySalonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CartRepository : ICartRepository
    {
        private readonly MySalonDbContext _salondbcontext;
        public CartRepository(MySalonDbContext dbContext)
        {
            _salondbcontext = dbContext;
        }

        public Cart AddItemToCart(Cart cart)
        {
            _salondbcontext.Carts.Add(cart);
            _salondbcontext.SaveChanges();
            return cart;
        }

        public bool DeleteACartItem(int id)
        {
            var cart = _salondbcontext.Carts.Find(id);
            if (cart == null)
            {
                return false;
            }
            _salondbcontext.Carts.Remove(cart);
            _salondbcontext.SaveChanges();
            return true;
        }

        public List<Cart> GetAllCartItemByUserId(int userId)
        {
            return _salondbcontext.Carts.Where(s => s.UserId == userId).ToList();

        }
    }
}
