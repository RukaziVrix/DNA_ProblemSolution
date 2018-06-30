using avazquez_Test.Interfaces;
using avazquez_Test.Models;
using avazquez_Test.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace avazquez_Test.Workflow
{
    public class DNA_WorkFlow : IAscii
    {
        public List<DNA> ListOfDNA = new List<DNA>();
        public List<RNA> ListOfRNA = new List<RNA>();
        private GUI gui;

        public DNA_WorkFlow(GUI gui)
        {
            this.gui = gui;
        }


        public bool CheckIfStringIsAscii(string line)
        {
            foreach (char c in line.ToCharArray())
            {
                switch (c)
                {
                    case 'A':
                    case 'T':
                    case 'G':
                    case 'C':
                        continue;
                    default:
                        return false;
                }
            }
            return true;
        }

        public string ComplementaryDNAStrand(DNA dna)
        {
            IEnumerable<string> code = dna.ListOfSegments;
            StringBuilder bob = new StringBuilder();
            int count = 0;
            foreach (string s in code)
            {
                foreach (char c in s.ToCharArray())
                {
                    switch (c)
                    {
                        case 'A':
                            bob.Append('T');
                            break;
                        case 'T':
                            bob.Append('A');
                            break;
                        case 'G':
                            bob.Append('C');
                            break;
                        case 'C':
                            bob.Append('G');
                            break;
                    }

                }
                count += 1;
                if (count < code.Count())
                {
                    bob.Append(", ");
                }
            }

            return bob.ToString();
        }

        public string ConvertAsciiToBinary(string line)
        {
            string result = string.Empty;
            if (line != null)
            {
                foreach (char ch in line)
                {
                    result += Convert.ToString((int)ch, 2).PadLeft(8, '0');
                }
            }
            return result;
        }

        public string ConvertAsciiToDNAOrRNA(string line, bool isDNA)
        {
            IEnumerable<string> listofsegments = SplitInParts(line, 2);
            List<string> listofresult = new List<string>();
            StringBuilder bob = new StringBuilder();

            int num = 0;

            foreach (string s in listofsegments)
            {
                num += 1;
                switch (s)
                {
                    case "00":
                        bob.Append("A");
                        break;
                    case "01":
                        if (isDNA)
                            bob.Append("T");
                        else
                            bob.Append("U");
                        break;
                    case "10":
                        bob.Append("G");
                        break;
                    case "11":
                        bob.Append("C");
                        break;
                }

                if (num == 4)
                {
                    num = 0;
                    listofresult.Add(bob.ToString());
                    bob.Clear();
                }
            }

            if (isDNA)
            {
                DNA dna = new DNA(listofresult);
                ListOfDNA.Add(dna);
                return dna.ToString();
            }
            else
            {
                RNA rna = new RNA(listofresult);
                ListOfRNA.Add(rna);
                return rna.ToString();
            }
        }

        public string InverseDNA()
        {
            StringBuilder bob = new StringBuilder();
            string line = gui.ReadDNACommands();
            if (line.Equals(null))
            {
                return null;
            }

            IEnumerable<string> listofsegmenst = SplitInParts(line, 4);

            foreach (string s in listofsegmenst)
            {
                bob.Append(ConvertDNACodeToAscii(s));
            }
            return bob.ToString();
        }

        public string SolveLCS(string item1, string item2)
        {
            int max = 0;
            StringBuilder bob = new StringBuilder();
            char[] line1 = item1.ToCharArray(), line2 = item2.ToCharArray();
            int[,] matrix = new int[line1.Length + 1, line2.Length + 1];

            for (int i = 1; i <= line1.Length; i++)
            {
                for (int j = 1; j <= line2.Length; j++)
                {
                    if (line1[i - 1] == line2[j - 1])
                    {
                        matrix[i, j] = matrix[(i - 1), (j - 1)] + 1;
                        if (max < matrix[i, j])
                        {
                            max = matrix[i, j];
                            bob.Append(line1[i - 1]);
                        }
                    }
                }
            }
            return bob.ToString();
        }

        public IEnumerable<string> SplitInParts(string s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

        public string ConvertDNACodeToAscii(string dna)
        {
            char[] characters = dna.ToCharArray();
            StringBuilder bob = new StringBuilder();
            foreach (char c in characters)
            {
                switch (c)
                {
                    case 'A':
                        bob.Append("00");
                        break;
                    case 'T':
                        bob.Append("01");
                        break;
                    case 'G':
                        bob.Append("10");
                        break;
                    case 'C':
                        bob.Append("11");
                        break;
                }
            }
            string binary = bob.ToString();
            return BinaryToAscii(binary);
        }

        public string BinaryToAscii(string binary)
        {
            List<Byte> list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return Encoding.ASCII.GetString(list.ToArray());
        }
    }
}
