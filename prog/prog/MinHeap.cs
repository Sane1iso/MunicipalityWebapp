using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog
{
    // A simple MinHeap class to manage priority requests
    public class MinHeap
    {
        private List<ServiceRequest> heap;

        public MinHeap()
        {
            heap = new List<ServiceRequest>();
        }

        public void Insert(ServiceRequest request)
        {
            heap.Add(request);
            HeapifyUp(heap.Count - 1);
        }

        public ServiceRequest ExtractMin()
        {
            if (heap.Count == 0) return null;

            ServiceRequest min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return min;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && heap[index].Priority.CompareTo(heap[Parent(index)].Priority) < 0)
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void HeapifyDown(int index)
        {
            int left = LeftChild(index);
            int right = RightChild(index);
            int smallest = index;

            if (left < heap.Count && heap[left].Priority.CompareTo(heap[smallest].Priority) < 0)
            {
                smallest = left;
            }

            if (right < heap.Count && heap[right].Priority.CompareTo(heap[smallest].Priority) < 0)
            {
                smallest = right;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private int Parent(int index) => (index - 1) / 2;
        private int LeftChild(int index) => 2 * index + 1;
        private int RightChild(int index) => 2 * index + 2;
        private void Swap(int index1, int index2)
        {
            var temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}