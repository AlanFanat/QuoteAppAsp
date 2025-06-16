using QuoteApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteApp.Db.Repositories
{
    public interface IFavoriteRepository
    {
        Favorite GetById(Guid id);
        IEnumerable<Quote> GetFavoritesByUser(Guid userId);
        void Add(Favorite favorite);
        void Delete(Guid id);
    }
}
