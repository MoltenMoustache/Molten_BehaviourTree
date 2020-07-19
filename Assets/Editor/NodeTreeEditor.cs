using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NodeTreeEditor : EditorWindow
{
    List<TreeNode> nodes;
    List<NodeConnection> connections;

    GUIStyle nodeStyle;
    GUIStyle inPointStyle;
    GUIStyle outPointStyle;

    NodeConnectionPoint selectedInPoint;
    NodeConnectionPoint selectedOutPoint;


    // Master Behaviour Tree
    BehaviourTree behaviourTree;

    [MenuItem("Window/Node Tree Editor")]
    static void OpenWindow()
    {
        NodeTreeEditor window = GetWindow<NodeTreeEditor>();
        window.titleContent = new GUIContent("Node Tree Editor");
    }

    private void OnGUI()
    {
        DrawNodes();
        DrawConnections();

        ProcessNodeEvents(Event.current);
        ProcessEvents(Event.current);
        if (GUI.changed) Repaint();
    }

    private void OnEnable()
    {
        nodeStyle = new GUIStyle();
        nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node0.png") as Texture2D;
        nodeStyle.border = new RectOffset(12, 12, 12, 12);

        // In Point Button
        inPointStyle = new GUIStyle();
        inPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left.png") as Texture2D;
        inPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn left on.png") as Texture2D;
        inPointStyle.border = new RectOffset(4, 4, 12, 12);

        // Out Point Button
        outPointStyle = new GUIStyle();
        outPointStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right.png") as Texture2D;
        outPointStyle.active.background = EditorGUIUtility.Load("builtin skins/darkskin/images/btn right on.png") as Texture2D;
        outPointStyle.border = new RectOffset(4, 4, 12, 12);

    }

    void DrawNodes()
    {
        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Draw();
            }
        }
    }

    void DrawConnections()
    {
        if (connections != null)
        {
            for (int i = 0; i < connections.Count; i++)
            {
                connections[i].Draw();
            }
        }
    }

    void ProcessEvents(Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                // if the pressed mouse button is the right mouse button
                if (e.button == 1)
                {
                    ProcessContextMenu(e.mousePosition);
                }
                break;
        }
    }

    void ProcessContextMenu(Vector2 a_mousePos)
    {
        GenericMenu genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Add Node"), false, () => OnClickAddNode(a_mousePos));
        genericMenu.ShowAsContext();
    }

    void OnClickAddNode(Vector2 a_mousePos)
    {
        if (nodes == null)
        {
            nodes = new List<TreeNode>();
        }

        nodes.Add(new TreeNode(a_mousePos, 200, 50, nodeStyle, inPointStyle, outPointStyle, OnClickInPoint, OnClickOutPoint));
    }

    void OnClickInPoint(NodeConnectionPoint a_inPoint)
    {
        selectedInPoint = a_inPoint;
        if (selectedOutPoint != null)
        {
            if (selectedOutPoint.treeNode != selectedInPoint.treeNode)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
                ClearConnectionSelection();
        }
    }

    void OnClickOutPoint(NodeConnectionPoint a_outPoint)
    {
        selectedOutPoint = a_outPoint;
        if (selectedInPoint != null)
        {
            if (selectedOutPoint.treeNode != selectedInPoint.treeNode)
            {
                CreateConnection();
                ClearConnectionSelection();
            }
            else
                ClearConnectionSelection();
        }
    }

    void OnClickRemoveConnection(NodeConnection a_connection)
    {
        connections.Remove(a_connection);
    }

    void CreateConnection()
    {
        if (connections == null)
            connections = new List<NodeConnection>();

        connections.Add(new NodeConnection(selectedInPoint, selectedOutPoint, OnClickRemoveConnection));
    }

    void ClearConnectionSelection()
    {
        selectedInPoint = null;
        selectedOutPoint = null;
    }

    void ProcessNodeEvents(Event e)
    {
        if (nodes != null)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                bool guiChanged = nodes[i].ProcessEvents(e);
                if (guiChanged)
                    GUI.changed = true;
            }
        }
    }

    void OnRemoveNode(TreeNode a_node)
    {
        if (nodes.Contains(a_node))
        {
            // destroy connections
            nodes.Remove(a_node);
        }
    }
}
