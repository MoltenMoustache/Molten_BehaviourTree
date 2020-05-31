using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BT_Agent : MonoBehaviour
{
    BehaviourTree tree = new BehaviourTree();
    bool hasKey = false;


    private void Start()
    {
        tree.AddNode(new RepeatNode());

        SelectorNode selector = new SelectorNode();
        tree.AddNode(selector, tree.GetStartNode());

        SequenceNode standardOpen = new SequenceNode();
        tree.AddNode(new LeafNode(FindDoor), standardOpen);
        tree.AddNode(new LeafNode(OpenDoor), standardOpen);
        tree.AddNode(standardOpen, selector);


        SequenceNode keyToDoorSequence = new SequenceNode();

        tree.AddNode(new LeafNode(FindDoor), keyToDoorSequence);
        tree.AddNode(new LeafNode(GetKey), keyToDoorSequence);
        tree.AddNode(new LeafNode(OpenDoor), keyToDoorSequence);
        tree.AddNode(keyToDoorSequence, selector);

        tree.Execute();
    }

    // Update is called once per frame
    void Update()
    {
        tree.Execute();
    }


    public bool CheckTag()
    {
        if (transform.tag == "Agent")
        {
            Debug.Log("=== Tag!");
            return true;
        }
        else
            return false;
    }

    public bool CheckName()
    {
        if (transform.name == "BT_Agent")
        {
            Debug.Log("=== Name!");
            return true;
        }
        else
            return false;
    }

    public bool CheckPosition()
    {
        if (transform.position == Vector3.zero)
        {
            Debug.Log("=== Position!");
            return true;
        }
        else
            return false;
    }

    public bool GetKey()
    {
        GameObject keyObject = null;

        if (GameObject.FindGameObjectWithTag("Key"))
        {
            keyObject = GameObject.FindGameObjectWithTag("Key");
            Debug.Log("Found Key");
        }
        else
        {
            return false;
        }

        if (keyObject != null)
        {
            transform.position = keyObject.transform.position;
            Destroy(keyObject);
            hasKey = true;
            Debug.Log("Got Key");
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool FindDoor()
    {
        if (GameObject.FindGameObjectWithTag("Door") != null)
        {
            Debug.Log("Found Door");
            return true;
        }
        else
            return false;
    }

    public bool OpenDoor()
    {
        GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
        if (doorObject != null)
        {
            if (MoveToDoor())
            {
                if (hasKey)
                {
                    doorObject.transform.Rotate(new Vector3(0, 90f, 0));
                    Debug.Log("Opened Door");
                    return true;
                }
                else
                    Debug.LogWarning("Can't open door -> no key!");
            }
            else
                return false;
        }

        return false;
    }

    public bool MoveToDoor()
    {
        GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
        if (doorObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorObject.transform.position, 10 * Time.deltaTime);
            if (transform.position == doorObject.transform.position)
                return true;
            else
                return false;
        }

        return false;
    }
}
