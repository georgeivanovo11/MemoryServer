using System.ComponentModel.DataAnnotations;

namespace MemoryServer.Models
{
    public class RusWord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech {get; set;}

        public int PartOfSpeechId { get; set; }
    }
}