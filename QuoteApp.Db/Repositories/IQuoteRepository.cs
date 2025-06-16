using QuoteApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteApp.Db.Repositories
{
    public interface IQuoteRepository
    {
        Quote GetById(Guid id);
        IEnumerable<Quote> GetAll();
        void Add(Quote quote);
        void Update(Quote quote);
        void Delete(Guid id);
    }
}
