using System;
using System.Collections.Generic;

namespace VscodeTest
{
    public class MerkleTree
    {     
        public MerkleNode Root {get; private set;}
        private int BlocLimit = 3;

        public void Build(string data)
        {
            var nodes = HasNodeQueueProvider(data);

            while(nodes.Count > 1)
            {
                var parent = CreateParent(nodes);

                nodes.Enqueue(parent);
            }

            Root = nodes.Dequeue();
        }

        public void AddLeaf(string data)
        {
            
        }

        private Queue<MerkleNode> HasNodeQueueProvider(string data)
        {
            var nodes = new Queue<MerkleNode>();

            string subData = "";
            int blocPt = 0;
            
            for(int i=0;i<data.Length;i++)
            {   
                subData += data[i];
                blocPt++;
                if(blocPt >= BlocLimit || i >= data.Length)
                {
                    nodes.Enqueue(new MerkleNode(subData));

                    subData = "";
                    blocPt = 0;
                }
            }

            return nodes;
        }

        private MerkleNode CreateParent(Queue<MerkleNode> nodes)
        {
            MerkleNode leftChild, rightChild;
                
            leftChild = nodes.Dequeue();

            if(nodes.Count > 0)
                rightChild = nodes.Dequeue();
            else
                rightChild = new MerkleNode("");

            return new MerkleNode(leftChild, rightChild);
        }

        public void BreathFirstSearch()
        {  
            Queue<MerkleNode> nodes = new Queue<MerkleNode>();
            nodes.Enqueue(Root);

            while(nodes.Count > 0)
            {
                MerkleNode node = nodes.Dequeue();
                Console.WriteLine($"Node : {node.Hash}");

                if(node.LeftChild != null && node.RightChild != null)
                {
                    nodes.Enqueue(node.LeftChild);
                    nodes.Enqueue(node.RightChild);
                }   
            }         
        }
    }
}