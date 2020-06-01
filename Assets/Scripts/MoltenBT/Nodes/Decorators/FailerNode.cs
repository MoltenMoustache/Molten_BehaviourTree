using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailerNode : Node
{
    public FailerNode()
    {
        childNodes = new List<Node>();
    }

    public override bool Execute()
    {
        childNodes[0].Execute();
        return false;
    }
}
