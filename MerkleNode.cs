namespace VscodeTest
{
    public class MerkleNode
    {
        public MerkleNode LeftChild {get; private set;}
        public MerkleNode RightChild {get; private set;}

        public MerkleHash Hash {get; private set;}

        public MerkleNode(string data)
        {
            Hash = new MerkleHash(data);
        }

        public MerkleNode(MerkleNode leftChild, MerkleNode rightChild)
        {
            this.LeftChild = leftChild;
            this.RightChild = rightChild;

            Hash = new MerkleHash(leftChild.Hash, rightChild.Hash);
        }
    }
}