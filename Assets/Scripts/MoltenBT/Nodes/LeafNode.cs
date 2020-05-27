using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeafNode : Node
{
    Func<bool> leafAction = null;

    public LeafNode(Func<bool> a_action)
    {
        leafAction = a_action;
    }

    public override bool Execute()
    {
        return leafAction.Invoke();
    }
}
