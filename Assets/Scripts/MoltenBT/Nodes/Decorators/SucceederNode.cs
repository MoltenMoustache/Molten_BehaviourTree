using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucceederNode : Node
{
    public SucceederNode()
    {
        childNodes = new List<Node>();
    }

    public override bool Execute()
    {
        childNodes[0].Execute();
        return true;
    }
}
