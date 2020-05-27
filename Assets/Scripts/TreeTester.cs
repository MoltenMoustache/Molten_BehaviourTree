using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTester : MonoBehaviour
{
    BehaviourTree tree;

    private void Start()
    {
        tree = new BehaviourTree();
        SelectorNode sequence = new SelectorNode();
        tree.AddNode(sequence);
        tree.AddNode(new LeafNode(LogGoodbye), sequence);
        tree.AddNode(new LeafNode(LogGoodbye), sequence);
        tree.AddNode(new LeafNode(LogHello), sequence);

        tree.Execute();
    }

    bool LogHello()
    {
        Debug.Log("Hello");
        return true;
    }

    bool LogGoodbye()
    {
        Debug.Log("Goodbye");
        return false;
    }
}
