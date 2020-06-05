using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : Node
{
    int tryCount = 0;
    int currentIteration = 0;

    public RepeatNode(int a_tryCount)
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
                case NodeResult.RUNNING:
                    return NodeResult.RUNNING;
                case NodeResult.FAILURE:
                    return NodeResult.FAILURE;
            }
        }

        currentIteration = 0;

        return NodeResult.SUCCESS;
    }
}
