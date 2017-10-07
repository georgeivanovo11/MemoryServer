using System.ComponentModel.DataAnnotations;

namespace MemoryServer.Models
{
    public class EngWord
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        [StringLength(25)]
        public string Transcription { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech {get; set;}

        public int PartOfSpeechId { get; set; }
    }
}