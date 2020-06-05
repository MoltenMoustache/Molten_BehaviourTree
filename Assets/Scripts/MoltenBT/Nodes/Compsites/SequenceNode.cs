using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public SequenceNode()
    {
        childNodes = new List<Node>();
    }

    public override NodeResult Execute()
    {
        nodeState = NodeResult.RUNNING;

        // Loops through and executes all child nodes, if a child evaluates as failed, this node evaluates as a fail.
        for (int i = 0; i < childNodes.Count; i++)
        {
            nodeState = childNodes[i].Execute();
            if(nodeState != NodeResult.SUCCESS)
            {
                return nodeState;
            }
        }

        Debug.Log("Sequence success");
        return NodeResult.SUCCESS;
    }
}
