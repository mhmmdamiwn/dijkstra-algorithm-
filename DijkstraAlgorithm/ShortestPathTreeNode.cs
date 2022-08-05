using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class ShortestPathTreeNode
    {
        public string Name { get; set; }
        public List<ShortestPathTreeNode> Children { get; set; }
        public string Parent { get; set; }
        public int DistanceFromSource { get; set; }
        public int DistanceFromParent { get; set; }
    }
}
