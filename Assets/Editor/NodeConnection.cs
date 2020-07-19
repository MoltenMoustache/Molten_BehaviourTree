using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeConnection
{
    public NodeConnectionPoint connectionIn;
    public NodeConnectionPoint connectionOut;
    public Action<NodeConnection> OnClickRemoveConnection;

    public NodeConnection(NodeConnectionPoint a_inPoint, NodeConnectionPoint a_outPoint, Action<NodeConnection> a_onClickRemove)
    {
        connectionIn = a_inPoint;
        connectionOut = a_outPoint;
        OnClickRemoveConnection = a_onClickRemove;
    }

    public void Draw()
    {
        Handles.DrawBezier(connectionIn.rect.center, connectionOut.rect.center, connectionIn.rect.center + Vector2.left * 50.0f, connectionOut.rect.center - Vector2.left * 50.0f, Color.white, null, 2.0f);

        if(Handles.Button((connectionIn.rect.center + connectionOut.rect.center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap))
        {
            if (OnClickRemoveConnection != null)
            {
                OnClickRemoveConnection(this);
            }
        }
    }
}
