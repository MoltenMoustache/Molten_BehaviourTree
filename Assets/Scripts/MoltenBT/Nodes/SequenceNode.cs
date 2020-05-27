using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : Node
{
    public SequenceNode()
    {
        childNodes = new List<Node>();
    }

    public override bool Execute()
    {
        nodeState = NodeResult.RUNNING;

        // Loops through and executes all child nodes, if a child evaluates as failed, this node evaluates as a fail.
        for (int i = 0; i < childNodes.Count; i++)
        {
            if (!childNodes[i].Execute())
            {
                nodeState = NodeResult.FAILURE;
                return false;
            }
        }

        nodeState = NodeResult.SUCCESS;
        return true;
    }
}
