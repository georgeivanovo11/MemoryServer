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
        public async Task<IEnumerable<EngWordResource>> GetAllEngWords()
        {
            var engwords = await context.EngWordSet.Include(w => w.PartOfSpeech).ToListAsync();

            return mapper.Map<List<EngWord>,List<EngWordResource>>(engwords);
        }

        [HttpGet("/api/engwords/find")]
        public async Task<IEnumerable<EngWordResource>> FindEngWordsBy(string partOfWord)
        {
            var allEngwords = await context.EngWordSet.Include(w => w.PartOfSpeech).ToListAsync();

            if(partOfWord==null)
                return null;

            if(partOfWord=="")
                return mapper.Map<List<EngWord>,List<EngWordResource>>(allEngwords);

            List <EngWord> engwords = new List<EngWord>();
            foreach(EngWord word in allEngwords)
            {
                if(word.Title.Contains(partOfWord))
                    engwords.Add(word);
            }
            return mapper.Map<List<EngWord>,List<EngWordResource>>(engwords);
        }
    }
}