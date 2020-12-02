using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppAPI.Context;
using WebAppAPI.Models;

namespace WebAppAPI.Feature.Book.Queries
{
    public class GetBookById : IRequest<NewBook>
    { 
        public int Id { get; set; }
        public class GetBookByIdHandler : IRequestHandler<GetBookById, NewBook>
        {
            private readonly IApplicationContext _context;
            public GetBookByIdHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<NewBook> Handle(GetBookById query, CancellationToken cancellationToken)
            {
                var book = _context.NewBooks.Where(a => a.Id == query.Id).FirstOrDefault();
                if (book == null)
                {
                    return null;
                }
                return book;
            }
        }
        
    }

}

