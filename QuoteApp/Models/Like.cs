using System;

namespace QuoteApp.Models
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid QuoteId { get; set; }

        public User User { get; set; }
        public Quote Quote { get; set; }
    }
}