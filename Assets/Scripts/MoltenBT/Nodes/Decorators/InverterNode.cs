using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterNode : Node
{
    public InverterNode()
    {
        childNodes = new List<Node>();
    }

    public override NodeResult Execute()
    {
        // Simply returns the opposite result of the child node
        switch (childNodes[0].Execute())
        {
            case NodeResult.SUCCESS:
                return NodeResult.FAILURE;
            case NodeResult.RUNNING:
                return NodeResult.RUNNING;
            case NodeResult.FAILURE:
                return NodeResult.SUCCESS;
            default:
                return NodeResult.FAILURE;
        }
    }
}
