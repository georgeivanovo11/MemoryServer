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
    public class PartOfSpeechController: Controller
    {
        private readonly MemoryDbContext context;
        private readonly IMapper mapper;

        public PartOfSpeechController(MemoryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/partsofspeech")]
        public async Task<IEnumerable<PartOfSpeechResource>> GetPartsOfSpeech()
        {
            var partsofspeech = await context.PartOfSpeechSet.ToListAsync();

            return mapper.Map<List<PartOfSpeech>,List<PartOfSpeechResource>>(partsofspeech);
        }
    }
}