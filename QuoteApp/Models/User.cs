using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace QuoteApp.Models
{
    public class User : IdentityUser<Guid>
    {
        public List<Quote> Quotes { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}