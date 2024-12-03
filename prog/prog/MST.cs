using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog
{
    namespace prog
    {
        public class MST
        {
            // Kruskal's algorithm for MST
            public List<Edge> KruskalMST(List<Edge> edges, int numRequests)
            {
                List<Edge> mst = new List<Edge>();
                edges.Sort((x, y) => x.Weight.CompareTo(y.Weight)); // Sort edges by weight
                DisjointSet ds = new DisjointSet(numRequests);

                foreach (var edge in edges)
                {
                    if (ds.Find(edge.RequestID1) != ds.Find(edge.RequestID2))
                    {
                        mst.Add(edge);
                        ds.Union(edge.RequestID1, edge.RequestID2);
                    }
                }

                return mst;
            }
        }
    }
}