using avazquez_Test.Workflow;
using System;
using System.Linq;

namespace avazquez_Test.View
{
    public class GUI 
    {
        DNA_WorkFlow workflow;

        public GUI()
        {
           workflow = new DNA_WorkFlow(this);
        }

        public void Menu()
        {
            string line = String.Empty;
            bool IsRunning = true;
            string problemtype = String.Empty;
            string[] menuOptions = new string[] {
                " 0) ASCII Text to DNA",
                " 1) ASCII Text to RNA",
                " 2) DNA to ASCII Text",
                " 3) Find the Complementary strand DNA from ASCII Text",
                " 4) Longest Common Substring b/w two strand of DNA"
                " 5) Exit"};



            while (IsRunning)
            {
                line = String.Empty;
                problemtype = String.Empty;
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                Console.WriteLine("Welcome to DNA Encoder\n");
                foreach (string s in menuOptions)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("\nPlease enter correspondent number options");
                int option = 0;
                if (Int32.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            //Ascii to DNA
                            problemtype = "Ascii to DNA";
                            line = ReadCommands();
                            line = workflow.ConvertAsciiToBinary(line);
                            line = workflow.ConvertAsciiToDNAOrRNA(line, true);
                            break;
                        case 1:
                            //Ascii to RNA
                            problemtype = "Ascii to RNA";
                            line = ReadCommands();
                            line = workflow.ConvertAsciiToBinary(line);
                            line = workflow.ConvertAsciiToDNAOrRNA(line, false);
                            break;
                        case 2:
                            //Inverse of DNA
                            problemtype = "DNA to Ascii";
                            line = workflow.InverseDNA();
                            break;
                        case 3:
                            //Complementary DNA
                            problemtype = "Ascii Complementary Strand";
                            line = ReadCommands();
                            line = workflow.ConvertAsciiToBinary(line);
                            line = workflow.ConvertAsciiToDNAOrRNA(line, true);
                            line = workflow.ComplementaryDNAStrand(workflow.ListOfDNA.Last());
                            break;
                        case 4:
                            //LSC for 2 Single Strand DNA
                            problemtype = "LSC for 2 Single Strand DNA";
                            line = ReadTwoCommands();
                            break;
                        case 5:
                            IsRunning = false;
                            break;
                        default:
                            return;
                    }

                    PrintAnswer(problemtype, line);
                    
                }
            }

            Console.WriteLine("GoodBye!");
        }

        public string ReadCommands()
        {
            Console.WriteLine("\nPlease enter your string line. Or Enter !Exit to return to the menuoptions");
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("!Exit"))
                {
                    return null;
                }
                else
                {
                    return line;
                }
            }
        }

        public string ReadDNACommands()
        {
            Console.WriteLine("\nPlease enter your DNA Code as one whole line. Like so ATCGTAGC. Or Enter !Exit to return to the menuoptions");
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("!Exit"))
                {
                    return null;
                }
                else if (workflow.CheckIfStringIsAscii(line))
                {
                    return line;
                }
                else
                {
                    Console.WriteLine("\nPlease Enter a Valid DNA Code");
                }
            }
        }

        public string ReadTwoCommands()
        {
            string dna1 = ReadCommands();
            string dna2 = ReadCommands();

            return workflow.SolveLCS(dna1, dna2);
        }

        public void PrintAnswer(string problemtype, string answer)
        {
            Console.WriteLine(problemtype + " Answer : " + answer);
            Console.WriteLine("\n\nPlease press ENTER to continue");
            Console.ReadLine();
        }
    }
}
