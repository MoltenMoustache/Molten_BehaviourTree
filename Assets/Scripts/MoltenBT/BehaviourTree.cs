using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    Node startNode = null;

    public BehaviourTree()
    {

    }

    public void AddNode(Node a_node, Node a_parentNode = null)
    {
        if(a_parentNode != null)
        {
            a_parentNode.AddNode(a_node);
        }

        else
        {
            startNode = a_node;
        }
    }

    public Node GetStartNode()
    {
        return startNode;
    }

    public void Execute()
    {
        startNode.Execute();
    }
}

public enum NodeResult
{
    SUCCESS,
    FAILURE,
    RUNNING
}
