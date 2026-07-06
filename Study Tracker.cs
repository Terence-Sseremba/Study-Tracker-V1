namespace Trak
{
    class StudyTracker
    {
        static void Main(string[] args)
        {
            Console.WriteLine("YOUR MOST WELCOME!!! TO  YOUR TRACKLIST!");
            
            bool running=true;
            while (running)
            {
                StudySession study=new StudySession();
                Console.WriteLine("Please enter the date of your study session: ");
                study.date=Console.ReadLine()!;
                Console.WriteLine("Please enter the topic of your study session: ");
                study.Topic=Console.ReadLine()!;
                Console.WriteLine("Please enter your level of understanding: ");
                 study.understanding = Console.ReadLine()!;

                Action<StudySession> action = (s) =>
            {
                if( s.understanding.ToLower() == "good")
                {
                    Console.WriteLine("Great job! Keep up the good work!");
                    Console.WriteLine("Any extra notes? (press Enter to skip): ");
                    study.notes = Console.ReadLine()!;
                    s.SaveToCompleted();
                }
                else if (s.understanding.ToLower() == "average")
                {

                    Console.WriteLine("Keep practicing and you'll improve!");
                    Console.WriteLine("  Write what you understood so far");
                    study.notes = Console.ReadLine()!;

                    s.SaveToReview();

                }
                else if (s.understanding.ToLower() == "poor"|| s.understanding.ToLower() == "confused")
                {
                    Console.WriteLine(" Don't worry, it's normal to feel confused sometimes. Keep studying and asking questions!");
                    Console.WriteLine(" Write what confused you specifically:");
                    study.notes = Console.ReadLine()!;
                    s.SaveToRevist();
                }
                else
                {
                    Console.WriteLine("Invalid understanding level!! Please use: good / average / poor / confused");
                };
                
            };
            action(study);
             Console.WriteLine("\nWould you like to log another session? (yes/no): ");
                string response = Console.ReadLine()!;
                if (response.ToLower() != "yes")
                {
                    running = false;
                }

            
            }
            
        }
    }
    class StudySession
    {
       public string date="";
        public string Topic="";
        public string understanding="";
        public string notes="";
        public void SaveToCompleted()
        {
            string filename = "completed_sessions.txt";
            using(StringWriter writer = new StringWriter())
            {
                writer.WriteLine($"Date: {date}");
                writer.WriteLine($"Topic: {Topic}");
                writer.WriteLine($"Understanding Level: {understanding}");
                writer.WriteLine($"Notes: {notes}");
                writer.WriteLine("------------------------");
                File.AppendAllText(filename, writer.ToString());
            }
            Console.WriteLine($"Study session on {date} about {Topic} has been saved to completed sessions.");
        }
        public void SaveToReview()
        {
            string filename = "review_sessions.txt";
            using(StringWriter writer = new StringWriter())
            {
                writer.WriteLine($"Date: {date}");
                writer.WriteLine($"Topic: {Topic}");
                writer.WriteLine($"Understanding Level: {understanding}");
                writer.WriteLine($"Notes: {notes}");
                writer.WriteLine("------------------------");
                File.AppendAllText(filename, writer.ToString());
                
            }
            Console.WriteLine($"Study session on {date} about {Topic} has been saved to review sessions.");
        }
        public void SaveToRevist()
        {
            string filename = "revist_sessions.txt";
            using(StringWriter writer = new StringWriter())
            {
                writer.WriteLine($"Date: {date}");
                writer.WriteLine($"Topic: {Topic}");
                writer.WriteLine($"Understanding Level: {understanding}");
                writer.WriteLine($"Notes: {notes}");
                writer.WriteLine("------------------------");
                File.AppendAllText(filename, writer.ToString());
            }
            Console.WriteLine($"Study session on {date} about {Topic} has been saved to revisit sessions.");
        }

    }
    
    }

