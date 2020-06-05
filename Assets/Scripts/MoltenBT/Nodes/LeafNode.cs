using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LeafNode : Node
{
    Func<NodeResult> leafAction = null;

    public LeafNode(Func<NodeResult> a_action)
    {
        leafAction = a_action;
    }

    public override NodeResult Execute()
    {
        return leafAction.Invoke();
    }
}
