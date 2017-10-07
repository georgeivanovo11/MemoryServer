namespace MemoryServer.Resources
{
    public class EngWordResource
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Transcription { get; set; }

        public PartOfSpeechResource PartOfSpeech {get; set;}

    }
}