using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : Node
{

    public SelectorNode()
    {
        childNodes = new List<Node>();
    }

    public override bool Execute()
    {
        nodeState = NodeResult.RUNNING;

        // Loops through all child nodes, if any return a success; child processing halts and the selector node returns successful.
        for (int i = 0; i < childNodes.Count; i++)
        {
            if (childNodes[i].Execute())
            {
                nodeState = NodeResult.SUCCESS;
                return true;
            }
        }

        nodeState = NodeResult.FAILURE;
        return false;
    }
}
