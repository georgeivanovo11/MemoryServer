namespace MemoryServer.Resources
{
    public class RusWordResource
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public PartOfSpeechResource PartOfSpeech {get; set;}
    }
}