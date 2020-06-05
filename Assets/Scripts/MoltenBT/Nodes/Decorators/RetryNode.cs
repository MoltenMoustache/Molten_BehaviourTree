using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryNode : Node
{
    int tryCount;
    int currentIteration = 0;
    public RetryNode(int a_tryCount)
    {
        childNodes = new List<Node>();
        tryCount = a_tryCount;
    }

    public override NodeResult Execute()
    {
        for (int i = currentIteration; i < tryCount; i++)
        {
            switch (childNodes[0].Execute())
            {
                case NodeResult.SUCCESS:
                    return NodeResult.SUCCESS;
                case NodeResult.RUNNING:
                    return NodeResult.RUNNING;
            }
        }

        currentIteration = 0;
        return NodeResult.FAILURE;
    }
}
