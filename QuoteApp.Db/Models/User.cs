using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace QuoteApp.Db.Models
{
    public class User : IdentityUser
    {
        public List<Quote> Quotes { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}