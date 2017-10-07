using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MemoryServer.Models;
using MemoryServer.Persistence;
using MemoryServer.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemoryServer.Controllers
{
    public class EngWordsController: Controller
    {
        private readonly MemoryDbContext context;
        private readonly IMapper mapper;

        public EngWordsController(MemoryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/engwords")]
        public async Task<IEnumerable<EngWordResource>> GetEngWords()
        {
            var engwords = await context.EngWordSet.Include(w => w.PartOfSpeech).ToListAsync();

            return mapper.Map<List<EngWord>,List<EngWordResource>>(engwords);
        }
    }
}