using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppAPI.Context;

namespace WebAppAPI.Feature.Book.Command
{
    public class DeleteBookCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteBookCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
            {
                var book = await _context.NewBooks.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (book == null) return default;
                _context.NewBooks.Remove(book);
                await _context.SaveChanges();
                return book.Id;
            }
        }
    }
}
