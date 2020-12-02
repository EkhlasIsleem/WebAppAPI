using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppAPI.Context;
using WebAppAPI.Models;


namespace WebAppAPI.Feature.Book.Command
{
    public class CreateBookCommand : IRequest<int>
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateBookCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBookCommand command, CancellationToken cancellationToken)
            {
                var book = new NewBook();
                book.Title = command.Title;
                book.Author = command.Author;
                book.Year = command.Year;
                book.Description = command.Description;
                _context.NewBooks.Add(book);
                await _context.SaveChanges();
                return book.Id;
            }
        }

    }
}

