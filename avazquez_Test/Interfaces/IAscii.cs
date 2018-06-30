using avazquez_Test.Models;

namespace avazquez_Test.Interfaces
{
    public interface IAscii
    {
        bool CheckIfStringIsAscii(string line);
        string ConvertAsciiToDNAOrRNA(string line, bool isDNA);
        string ConvertAsciiToBinary(string line);
        string InverseDNA();
        string ComplementaryDNAStrand(DNA dna);
        string SolveLCS(string item1, string item2);
        string ConvertDNACodeToAscii(string dna);
        string BinaryToAscii(string binary);
    }
}
