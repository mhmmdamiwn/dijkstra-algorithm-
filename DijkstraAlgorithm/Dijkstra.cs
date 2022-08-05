using System;
using System.Collections.Generic;
using System.Linq;

namespace DijkstraAlgorithm
{
    public class Dijkstra
    {
        private List<Node> Graph;
        public Dijkstra(List<Node> Graph)
        {
            this.Graph = Graph;
        }
        public List<Node> MainMethod(Node Source)
        {
            List<Node> MainTree = new List<Node>();
            if (Graph.Contains(Source))
            {
                int counter = Graph.Count;
                int index1 = Graph.FindIndex(x => x == Source);
                Graph[index1].DistanceFromSource = 0;
                while (counter > 0)
                {
                    int index = Graph.FindIndex(x => x == Source);
                    SetChildrenDistance(Graph[index]);
                    MainTree.Add(Graph[index]);
                    Source.IsRelaxed = true;
                    Source = SelectMinChild(Source);
                    counter--;
                }
            }
            return MainTree;
        }
        private void SetChildrenDistance(Node Parent)
        {
            //Node parent;
            if (Graph.Contains(Parent))
            {
                int index = Graph.FindIndex(x => x == Parent);
                foreach (Node item in Graph[index].Children)
                {
                    int index2 = Graph[index].Children.FindIndex(x => x == item);
                    if (item.DistanceFromSource >= this.Graph[index].DistanceFromSource + this.Graph[index].DistanceFromChildren[index2])
                    {
                        this.Graph[index].Children[index2].DistanceFromSource = this.Graph[index].DistanceFromSource + this.Graph[index].DistanceFromChildren[index2];
                        item.MinParent = Graph[index];
                    }
                }
            }
        }
        private Node SelectMinChild(Node Parent)
        {
            int Min = int.MaxValue;
            int MinNode = 0;
            int index = Graph.FindIndex(x => x == Parent);
            foreach (Node item in Graph[index].Children)
            {
                if (item.DistanceFromSource <= Min && item.IsRelaxed == false)
                {
                    Min = item.DistanceFromSource;
                    MinNode = Graph[index].Children.FindIndex(x => x== item);
                }
            }
            return Graph[index].Children[MinNode];
        }
        public List<ShortestPathTreeNode> ShhortestPathTree(List<Node> Edited)
        {
            List<ShortestPathTreeNode> tree = new List<ShortestPathTreeNode>();
            foreach (Node item in Edited)
            {
                tree.Add(new ShortestPathTreeNode()
                {
                    Name = item.Name,
                    Parent = item.MinParent.Name,
                    DistanceFromSource = item.DistanceFromSource
                });
            }
            foreach (ShortestPathTreeNode item in tree)
            {
                item.Children = tree.Where(t => t.Parent == item.Name).ToList();
            }
            foreach (ShortestPathTreeNode item in tree)
            {
                Node node = Graph.Where(x => x.Name == item.Name).First();

            }
                return tree;
        }
        public List<Node> gp()
        {
            return Graph;
        }

    }
}
