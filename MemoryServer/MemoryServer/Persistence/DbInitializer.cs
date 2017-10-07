using System.Linq;
using MemoryServer.Models;

namespace MemoryServer.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MemoryDbContext context)
        {
            context.Database.EnsureCreated(); // if db is not exist, it will create database 

            //if smth exists, do nothing 
            if(context.PartOfSpeechSet.Any())
            {
                return;
            }

            //part of speech
            PartOfSpeech part1 = new PartOfSpeech();
            part1.Title = "noun";

            PartOfSpeech part2 = new PartOfSpeech();
            part2.Title = "verb";

            PartOfSpeech part3 = new PartOfSpeech();
            part3.Title = "adjective";
            
            //english words 
            EngWord eWord1 = new EngWord();
            eWord1.Title = "home";
            eWord1.PartOfSpeech = part1;

            EngWord eWord2 = new EngWord();
            eWord2.Title = "buy";
            eWord2.PartOfSpeech = part2;

            EngWord eWord3 = new EngWord();
            eWord3.Title = "good";
            eWord3.PartOfSpeech = part3;

            context.EngWordSet.Add(eWord1);
            context.EngWordSet.Add(eWord2);
            context.EngWordSet.Add(eWord3);

            //russian words
            RusWord rWord1 = new RusWord();
            rWord1.Title = "дом";
            rWord1.PartOfSpeech = part1;

            RusWord rWord2 = new RusWord();
            rWord2.Title = "купить";
            rWord2.PartOfSpeech = part2;

            RusWord rWord3 = new RusWord();
            rWord3.Title = "хороший";
            rWord3.PartOfSpeech = part3;

            context.RusWordSet.Add(rWord1);
            context.RusWordSet.Add(rWord2);
            context.RusWordSet.Add(rWord3);

            context.SaveChanges();
        }
    }
}