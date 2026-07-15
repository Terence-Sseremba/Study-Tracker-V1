namespace Track
{
    class StudyTracker
    {
        static void Main(string[] args)
        {
            bool running=true;
            while (running)
        {   
            Console.WriteLine("YOUR MOST WELCOME!!! TO  YOUR TRACKLIST!");
            Console.WriteLine("Choose your desired option below to track your study sessions");
            Console.WriteLine("1.Log into new study session");
            Console.WriteLine("2.View completed sessions");
            Console.WriteLine("3.View sessions to review");
            Console.WriteLine("4.View sessions to revisit");
            Console.WriteLine("5.Exit");
             
            string choice = Console.ReadLine()!;
            if(int.TryParse(choice, out int option))
            {
                switch(option)
                {
                        case 1:
                        Console.WriteLine("You have chosen to log into a new study session lets begin !.");
                        
                    
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
                        break;
                        

                        
                    case 2:
                        Console.WriteLine("You have chosen to view completed sessions lets begin!.");
                        if (File.Exists("completed_sessions.txt"))
                        {
                            string completedSessions = File.ReadAllText("completed_sessions.txt");
                            Console.WriteLine("Completed Sessions:");
                            Console.WriteLine(completedSessions);
                        }
                        else
                        {
                            Console.WriteLine("No completed sessions found.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("You have chosen to view sessions to review lets begin!.");
                        if (File.Exists("review_sessions.txt"))
                        {
                            string reviewSessions = File.ReadAllText("review_sessions.txt");
                            Console.WriteLine("Sessions to Review:");
                            Console.WriteLine(reviewSessions);
                        }
                        else
                        {
                            Console.WriteLine("No sessions to review found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("You have chosen to view sessions to revisit.");
                        if (File.Exists("revist_sessions.txt"))
                        {
                            string revisitSessions = File.ReadAllText("revist_sessions.txt");
                            Console.WriteLine("Sessions to Revisit:");
                            Console.WriteLine(revisitSessions);
                        }
                        else
                        {
                            Console.WriteLine("No sessions to revisit found.");
                        }
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                        break;
                }
            }
            
        
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
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
}
    
    


