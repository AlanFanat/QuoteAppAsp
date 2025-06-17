using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuoteApp.Db.Models;
using QuoteApp.Db.Repositories;
using QuoteApp.Models;
using QuoteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuoteApp.Controllers
{
    [Authorize]
    public class QuoteController : Controller
    {
        private readonly IQuoteRepository quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            this.quoteRepository = quoteRepository;
        }
        public IActionResult Index()
        {
            var quotes = quoteRepository.GetAll();
            var quotesViewModels = quotes.Select(model => QuoteViewModel.FromModel(model, Guid.NewGuid()));
            return View(quotesViewModels);
        }
        public IActionResult Details(Guid id)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var quote = quoteRepository.GetById(id);
            if (quote == null) return NotFound();
            var quoteViewModel = QuoteViewModel.FromModel(quote, userId);
            return View(quoteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(QuoteViewModel quoteViewModel)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var quote = QuoteViewModel.ToModel(quoteViewModel, userId);
            quoteRepository.Add(quote);
            return RedirectToAction("Index");
        }
        public IActionResult Mine()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var quotes = quoteRepository.GetAll().Where(q => q.UserId == userId);
            var quotesViewModels = quotes.Select(model => QuoteViewModel.FromModel(model, Guid.NewGuid()));
            return View(quotesViewModels);
        }
    }
}
