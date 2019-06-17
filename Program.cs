using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VscodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MerkleTree tree = new MerkleTree();
            tree.Build("jesuisadrien");

            tree.BreathFirstSearch();
        }
    }
}
