using prog;

public class BinarySearchTree
{
    private Node root;

    public class Node
    {
        public int RequestID;
        public ServiceRequest Data;
        public Node Left, Right;

        public Node(ServiceRequest data)
        {
            RequestID = data.RequestID;
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public void Insert(ServiceRequest request)
    {
        root = Insert(root, request);
    }

    private Node Insert(Node node, ServiceRequest request)
    {
        if (node == null)
            return new Node(request);

        if (request.RequestID < node.RequestID)
            node.Left = Insert(node.Left, request);
        else if (request.RequestID > node.RequestID)
            node.Right = Insert(node.Right, request);

        return node;
    }

    public ServiceRequest Find(int requestId)
    {
        Node result = Find(root, requestId);
        return result?.Data;
    }

    private Node Find(Node node, int requestId)
    {
        if (node == null || node.RequestID == requestId)
            return node;

        if (requestId < node.RequestID)
            return Find(node.Left, requestId);
        else
            return Find(node.Right, requestId);
    }
}
