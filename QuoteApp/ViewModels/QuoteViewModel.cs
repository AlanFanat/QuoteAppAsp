using QuoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteApp.ViewModels
{
    public class QuoteViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int FavoritesCount { get; set; }

        public bool IsFavoritedByCurrentUser { get; set; }
        public static Quote ToModel(QuoteViewModel viewModel, Guid userId)
        {
            return new Quote
            {
                Id = viewModel.Id != Guid.Empty ? viewModel.Id : Guid.NewGuid(),
                Title = viewModel.Title,
                Author = viewModel.Author,
                Text = viewModel.Text,
                Description = viewModel.Description,
                CreatedAt = viewModel.CreatedAt == default ? DateTime.UtcNow : viewModel.CreatedAt,
                UserId = userId
            };
        }

        public static QuoteViewModel FromModel(Quote quote, Guid? currentUserId)
        {
            return new QuoteViewModel
            {
                Id = quote.Id,
                Title = quote.Title,
                Author = quote.Author,
                Text = quote.Text,
                Description = quote.Description,
                CreatedAt = quote.CreatedAt,

                UserId = quote.UserId,
                UserName = quote.User?.UserName ?? "Неизвестно",
                FavoritesCount = quote.Favorites?.Count ?? 0,


                IsFavoritedByCurrentUser = currentUserId.HasValue &&
                    quote.Favorites?.Any(f => f.UserId == currentUserId.Value) == true
            };
        }
    }

}
