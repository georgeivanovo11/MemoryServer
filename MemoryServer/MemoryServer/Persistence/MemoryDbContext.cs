using MemoryServer.Models;
using Microsoft.EntityFrameworkCore;

namespace MemoryServer.Persistence
{
    public class MemoryDbContext: DbContext
    {
        public MemoryDbContext(DbContextOptions<MemoryDbContext> options) : base(options)
        {

        }

        public DbSet<PartOfSpeech> PartOfSpeechSet {get; set;}
        public DbSet<EngWord> EngWordSet {get; set;}
        public DbSet<RusWord> RusWordSet {get; set;}
    }
}