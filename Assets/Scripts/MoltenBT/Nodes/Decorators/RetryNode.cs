using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryNode : Node
{
    int tryCount;
    public RetryNode(int a_tryCount)
    {
        childNodes = new List<Node>();
        tryCount = a_tryCount;
    }

    public override bool Execute()
    {
        for (int i = 0; i < tryCount; i++)
        {
            if (childNodes[0].Execute())
                return true;
        }

        return false;
    }
}
