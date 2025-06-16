using Microsoft.AspNetCore.Mvc;
using QuoteApp.Models;
using QuoteApp.ViewModels;
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
                Favorites = new List<Favorite>()
            }
        };
        public IActionResult Index()
        {
            return View(_quotes);
        }
        public IActionResult Details(Guid id)
        {
            var quote = _quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null) return NotFound();
            return View(quote);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuoteViewModel quoteViewModel)
        {
            var quote = QuoteViewModel.ToModel(quoteViewModel, Guid.NewGuid());
            _quotes.Add(quote);
            return RedirectToAction("Index");
        }
    }
}
