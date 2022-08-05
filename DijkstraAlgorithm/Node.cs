
using System.Collections.Generic;
namespace DijkstraAlgorithm
{
    public class Node
    {

        public int DistanceFromSource = int.MaxValue;
        public string Name { get; set; }
        public List<Node> Parents { get; set; }
        public List<Node> Children { get; set; }
        public List<int> DistanceFromChildren { get; set; }
        public bool IsRelaxed = false;
        public string ParentAndDistance { get; set; }
        public Node MinParent { get; set; }
        public Node()
        {
            Parents = new List<Node>();
            Children = new List<Node>();
            DistanceFromChildren = new List<int>();
        }
        public void AddChild(List<Node> Child, List<int> distance)
        {
            this.Children.AddRange(Child);
            this.DistanceFromChildren.AddRange(distance);
            foreach (Node child in Child)
            {
                child.Parents.Add(this);
            }
        }

    }
}
