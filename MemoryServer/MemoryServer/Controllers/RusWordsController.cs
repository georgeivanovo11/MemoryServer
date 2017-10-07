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
    public class RusWordsController: Controller
    {
        private readonly MemoryDbContext context;
        private readonly IMapper mapper;

        public RusWordsController(MemoryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/ruswords")]
        public async Task<IEnumerable<RusWordResource>> GetRusWords()
        {
            var ruswords = await context.RusWordSet.Include(w => w.PartOfSpeech).ToListAsync();

            return mapper.Map<List<RusWord>,List<RusWordResource>>(ruswords);
        }
    }
}