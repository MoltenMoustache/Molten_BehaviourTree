using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeaterNode : Node
{
    int repeaterCount;

    public RepeaterNode(int a_count)
    {
        childNodes = new List<Node>();
        repeaterCount = a_count;
    }

    public override bool Execute()
    {
        for (int i = 0; i < repeaterCount; i++)
        {
            if (!childNodes[0].Execute())
                return false;
        }

        return true;
    }
}
