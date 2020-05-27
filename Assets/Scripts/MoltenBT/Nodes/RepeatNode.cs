using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatNode : Node
{
    public RepeatNode()
    {
        childNodes = new List<Node>();
    }
    public override bool Execute()
    {
        for (int i = 0; i < childNodes.Count; i++)
        {
            childNodes[i].Execute();
        }

        return true;
    }
}
