using Microsoft.AspNetCore.Mvc;
using QuoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.Controllers
{
    public class QuoteController : Controller
    {
        private static List<Quote> _quotes = new List<Quote>
        {
            new Quote
            {
                Id = Guid.NewGuid(),
                Title = "О мужестве",
                Author = "Аристотель",
                Text = "Мужество — это середина между трусостью и безрассудством.",
                Description = "Цитата о балансе в человеческих качествах.",
                CreatedAt = DateTime.Now.AddDays(-5),
                UserId = Guid.NewGuid(),
                User = new User { Id = Guid.NewGuid(), UserName = "philosopher123" },
                Likes = new List<Like>(),
                Dislikes = new List<Dislike>(),
                Favorites = new List<Favorite>()
            },
            new Quote
            {
                Id = Guid.NewGuid(),
                Title = "О свободе",
                Author = "Жан-Жак Руссо",
                Text = "Человек рожден свободным, но везде он в цепях.",
                Description = "Известное размышление о свободе и обществе.",
                CreatedAt = DateTime.Now.AddDays(-10),
                UserId = Guid.NewGuid(),
                User = new User { Id = Guid.NewGuid(), UserName = "thinker88" },
                Likes = new List<Like>
                {
                    new Like
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        QuoteId = Guid.NewGuid(),
                        User = new User { Id = Guid.NewGuid(), UserName = "reader01" }
                    }
                },
                Dislikes = new List<Dislike>(),
                Favorites = new List<Favorite>()
            },
            new Quote
            {
                Id = Guid.NewGuid(),
                Title = "О знаниях",
                Author = "Сократ",
                Text = "Я знаю только то, что ничего не знаю.",
                Description = "Парадоксальная цитата о мудрости и незнании.",
                CreatedAt = DateTime.Now.AddDays(-2),
                UserId = Guid.NewGuid(),
                User = new User { Id = Guid.NewGuid(), UserName = "socratist" },
                Likes = new List<Like>(),
                Dislikes = new List<Dislike>
                {
                    new Dislike
                    {
                        Id = Guid.NewGuid(),
                        UserId = Guid.NewGuid(),
                        QuoteId = Guid.NewGuid(),
                        User = new User { Id = Guid.NewGuid(), UserName = "critic42" }
                    }
                },
                Favorites = new List<Favorite>()
            }
        };
        public IActionResult Index()
        {
            return View(_quotes);
        }
    }
}
