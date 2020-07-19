using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConnectionType { IN, OUT }
public class NodeConnectionPoint
{
    public Rect rect;
    public ConnectionType connectionType;
    public TreeNode treeNode;
    public GUIStyle style;
    public Action<NodeConnectionPoint> OnClickConnectionPoint;

    public NodeConnectionPoint(TreeNode a_treeNode, ConnectionType a_type, GUIStyle a_style, Action<NodeConnectionPoint> a_onClick)
    {
        treeNode = a_treeNode;
        connectionType = a_type;
        style = a_style;
        OnClickConnectionPoint = a_onClick;
        rect = new Rect(0, 0, 10f, 20f);
    }

    public void Draw()
    {
        rect.y = treeNode.rect.y + (treeNode.rect.height * 0.5f) - rect.height * 0.5f;
        switch (connectionType)
        {
            case ConnectionType.IN:
                rect.x = treeNode.rect.x - rect.width + 8.0f;
                break;
            case ConnectionType.OUT:
                rect.x = treeNode.rect.x + rect.width - 8.0f;
                break;
        }

        if(GUI.Button(rect, "", style))
        {
            if(OnClickConnectionPoint != null)
            {
                OnClickConnectionPoint(this);
            }
        }

    }
}
