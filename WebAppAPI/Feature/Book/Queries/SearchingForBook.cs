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
    public class SearchingForBook : IRequest<NewBook>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public class SearchingForBookHandler : IRequestHandler<SearchingForBook, NewBook>
        {
            private readonly IApplicationContext _context;
            public SearchingForBookHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<NewBook> Handle(SearchingForBook query, CancellationToken cancellationToken)
            {
                var book = _context.NewBooks.Where(a => a.Title == query.Title || a.Author == query.Author || a.Year == query.Year).FirstOrDefault();
                if (book == null)
                {
                    return null;
                }
                return book;
            }
        }

    }

}


