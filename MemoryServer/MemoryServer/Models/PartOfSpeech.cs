using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MemoryServer.Models
{
    public class PartOfSpeech
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title {get; set;}

        public ICollection<EngWord> EngWords {get; set;}

        public ICollection<RusWord> RusWords {get; set;}

        public PartOfSpeech()
        {
            EngWords = new Collection<EngWord>();
            RusWords = new Collection<RusWord>();
        }

    }
}
