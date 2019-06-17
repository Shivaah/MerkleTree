using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace VscodeTest
{
    public class MerkleHash
    {
        public byte[] Hash {get; private set;}

        public MerkleHash(string data)
        {
            Hash = ComputeHash(data);
        }

        public MerkleHash(MerkleHash left, MerkleHash right)
        {
            Hash = ComputeHash(left.Hash.Concat(right.Hash).ToArray());
        }

        private byte[] ComputeHash(byte[] buffer)
        {
            byte[] hashValue;
            using (SHA256 mySha = SHA256.Create())
            {
                hashValue = mySha.ComputeHash(buffer);
            }

            return hashValue;
        }

        private byte[] ComputeHash(string data)
        {
             byte[] hashValue;
            using (SHA256 mySha = SHA256.Create())
            {
                hashValue = mySha.ComputeHash(Encoding.UTF8.GetBytes(data));
            }

            return hashValue;
        }

        public static bool operator ==(MerkleHash cand, MerkleHash other)
        {
            return cand.Equals(other);
        }

        public static bool operator !=(MerkleHash cand, MerkleHash other)
        {
            return !cand.Equals(other);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is MerkleHash))
                throw new System.Exception("test");

            return Equals((MerkleHash)obj);
        }

        public override string ToString()
        {
            var sBuilder = new StringBuilder();

            for (int i = 0; i < Hash.Length; i++)
            {
                sBuilder.Append(Hash[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            string hashString = sBuilder.ToString();
            return $"{hashString}";
        }

        public bool Equals(byte[] hash)
        {
            return this.Hash.SequenceEqual(hash);
        }

        public bool Equals(MerkleHash node)
        {
            bool ret = false;

            if(((object)Hash) != null && node != null)
            {
                ret = Hash.SequenceEqual(node.Hash);
            }

            return ret;
        }       
    }
}