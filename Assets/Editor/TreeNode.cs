using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TreeNode
{
    public Rect rect;
    public string title;
    public bool isDragged = false;

    public GUIStyle style;

    public NodeConnectionPoint inPoint;
    public NodeConnectionPoint outPoint;


    // BehaviourTree Component
    public Node node;

    public TreeNode(Vector2 a_position, float a_width, float a_height, GUIStyle a_nodeStyle, GUIStyle a_inPointStyle, GUIStyle a_outPointStyle, Action<NodeConnectionPoint> a_OnClickInPoint, Action<NodeConnectionPoint> a_OnClickOutPoint)
    {
        rect = new Rect(a_position.x, a_position.y, a_width, a_height);
        style = a_nodeStyle;
        inPoint = new NodeConnectionPoint(this, ConnectionType.IN, a_inPointStyle, a_OnClickInPoint);
        outPoint = new NodeConnectionPoint(this, ConnectionType.OUT, a_outPointStyle, a_OnClickOutPoint);
    }

    public void Drag(Vector2 a_delta)
    {
        rect.position += a_delta;
    }

    public void Draw()
    {
        inPoint.Draw();
        outPoint.Draw();
        GUI.Box(rect, title, style);
    }

    public bool ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if(e.button == 0)
                {
                    if (rect.Contains(e.mousePosition))
                    {
                        isDragged = true;
                        GUI.changed = true;
                    }
                    else
                    {
                        GUI.changed = true;
                    }
                }
                break;
            case EventType.MouseUp:
                if(e.button == 0)
                {
                    if (isDragged)
                        isDragged = false;
                }
                break;
            case EventType.MouseDrag:
                if(e.button == 0 && isDragged)
                {
                    Drag(e.delta);
                    e.Use();
                    return true;
                }
                break;
        }
        return false;
    }
}
