using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    protected List<Node> childNodes;
    protected NodeResult nodeState = NodeResult.SUCCESS;

    public Node()
    {
        childNodes = new List<Node>();
    }

    public virtual void AddNode(Node a_node)
    {
        childNodes.Add(a_node);
    }

    public virtual List<Node> GetChildNodes()
    {
        return childNodes;
    }

    public virtual Node GetNode(int a_index)
    {
        return childNodes[a_index];
    }

    public virtual NodeResult Execute()
    {
        return NodeResult.SUCCESS;
    }

    public NodeResult GetNodeResult() { return nodeState; }
}
