namespace Track
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
                    s.SaveToCompleted();
                }
                else if (s.understanding.ToLower() == "average")
                {

                    Console.WriteLine("Keep practicing and you'll improve!");
                    Console.WriteLine("Below write specifically in detail specifically what made you understand the topic basing on your understanding in which you filled above!!");
                    study.notes = Console.ReadLine()!;

                    s.SaveToReview();

                }
                else if (s.understanding.ToLower() == "poor"|| s.understanding.ToLower() == "confused")
                {
                    Console.WriteLine("Don't worry, keep studying and you'll get better!");
                    Console.WriteLine("Below write specifically in detail specifically what made you not understand the topic basing on your understanding in which you filled above!!");
                    study.notes = Console.ReadLine()!;
                    s.SaveToRevist();
                }
                else
                {
                    Console.WriteLine("Invalid input for understanding level.");
                };
                
            };
            action(study);
            running = false;
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

