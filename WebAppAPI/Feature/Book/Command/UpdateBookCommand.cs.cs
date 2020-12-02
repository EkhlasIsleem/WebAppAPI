using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppAPI.Context;

namespace WebAppAPI.Feature.Book.Command
{
    public class UpdateBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }

        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateBookCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
            {
                var book = _context.NewBooks.Where(a => a.Id == command.Id).FirstOrDefault();

                if (book == null)
                {
                    return default;
                }
                else
                {
                    book.Title = command.Title;
                    book.Author = command.Author;
                    book.Year = command.Year;
                    book.Description = command.Description;
                    await _context.SaveChanges();
                    return book.Id;
                }
            }
        }
    }

}
