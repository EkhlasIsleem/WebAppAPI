using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAppAPI.Context;
using WebAppAPI.Models;

namespace WebAppAPI.Feature.Book.Queries
{
    public class GetAllBook : IRequest<IEnumerable<NewBook>>
    {
        
        public class GetAllBookHandler : IRequestHandler<GetAllBook, IEnumerable<NewBook>>
        {
            private readonly IApplicationContext _context;
            public GetAllBookHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<NewBook>> Handle(GetAllBook query, CancellationToken cancellationToken)
            {
                var bookList = await _context.NewBooks.ToListAsync();
                if (bookList == null)
                {
                    return null;
                }
                return bookList.AsReadOnly();
            }
            
        }
    }
}
