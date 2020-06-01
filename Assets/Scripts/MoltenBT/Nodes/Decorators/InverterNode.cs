using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterNode : Node
{
    public InverterNode()
    {
        childNodes = new List<Node>();
    }

    public override bool Execute()
    {
        // Simply returns the opposite result of the child node
        return !childNodes[0].Execute();
    }
}
