using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNode : Node
{

    public SelectorNode()
    {
        childNodes = new List<Node>();
    }

    public override NodeResult Execute()
    {
        nodeState = NodeResult.RUNNING;

        // Loops through all child nodes, if any return a success; child processing halts and the selector node returns successful.
        for (int i = 0; i < childNodes.Count; i++)
        {
            switch (childNodes[i].Execute())
            {
                case NodeResult.SUCCESS:
                    return NodeResult.SUCCESS;
                case NodeResult.RUNNING:
                    return NodeResult.RUNNING;
            }
        }

        return NodeResult.FAILURE;
    }
}
