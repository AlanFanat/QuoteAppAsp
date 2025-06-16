using Microsoft.EntityFrameworkCore;
using QuoteApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuoteApp.Db.Repositories
{
    public class FavoriteDBRepository : IFavoriteRepository
    {
        private readonly DatabaseContext context;

        public FavoriteDBRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void Add(Favorite favorite)
        {
            context.Favorites.Add(favorite);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var favorite = context.Favorites.Find(id);
            if (favorite != null)
            {
                context.Favorites.Remove(favorite);
                context.SaveChanges();
            }
        }

        public Favorite GetById(Guid id)
        {
            return context.Favorites
                .Include(q => q.User)
                .Include(q => q.Quote)
                .FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<Quote> GetFavoritesByUser(Guid userId)
        {
            return context.Favorites
            .Where(f => f.UserId == userId)
            .Include(f => f.Quote)
            .Select(f => f.Quote!)
            .ToList();
        }
    }
}
