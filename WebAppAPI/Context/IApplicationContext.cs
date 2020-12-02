using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAppAPI.Models;

namespace WebAppAPI.Context
{
    public interface IApplicationContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<NewBook> NewBooks { get; set; }

        Task<int> SaveChanges();
    }
}