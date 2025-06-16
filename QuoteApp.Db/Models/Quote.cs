using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Db.Models
{
    public class Quote
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; } 
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();
    }

}
