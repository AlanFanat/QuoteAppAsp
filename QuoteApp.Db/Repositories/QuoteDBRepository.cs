using Microsoft.EntityFrameworkCore;
using QuoteApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuoteApp.Db.Repositories
{
    public class QuoteDBRepository : IQuoteRepository
    {
        private readonly DatabaseContext context;

        public QuoteDBRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Add(Quote quote)
        {
            context.Quotes.Add(quote);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var quote = context.Quotes.Find(id);
            if (quote != null)
            {
                context.Quotes.Remove(quote);
                context.SaveChanges();
            }
        }

        public IEnumerable<Quote> GetAll()
        {
            return context.Quotes
                .Include(q => q.User)         // если нужно имя добавившего
                .Include(q => q.Favorites)    // если нужно количество избранных
                .OrderByDescending(q => q.CreatedAt)
                .ToList();
        }

        public Quote GetById(Guid id)
        {
            return context.Quotes
                .Include(q => q.User)
                .Include(q => q.Favorites)
                .FirstOrDefault(q => q.Id == id);
        }

        public void Update(Quote quote)
        {
            context.Quotes.Update(quote);
            context.SaveChanges();
        }
    }

}
