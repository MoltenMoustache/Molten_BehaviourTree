using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Patrol : MonoBehaviour
{
    // A.I
    BehaviourTree tree = new BehaviourTree();

    // Patrol
    [SerializeField] Transform[] patrolPoints = null;
    int currentPatrolPointIndex = 0;
    [SerializeField] float movementSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        SelectorNode selector = new SelectorNode();
        tree.AddNode(selector);

        SequenceNode playerFinderSequence = new SequenceNode();
        tree.AddNode(playerFinderSequence, selector);
        tree.AddNode(new LeafNode(CheckForPlayer), playerFinderSequence);
        tree.AddNode(new LeafNode(GoToPlayer), playerFinderSequence);

        tree.AddNode(new LeafNode(GoToNextPoint), selector);
    }

    // Update is called once per frame
    void Update()
    {
        tree.Execute();
    }

    public bool CheckForPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < 20.0f)
                return true;
        }

        Debug.Log("Player not found");
        return false;
    }

    public bool GoToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
            if (player.transform.position == transform.position)
            {
                Destroy(player);
                Debug.Log("Player caught!");
                return true;
            }
        }
        return false;
    }

    public bool GoToNextPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].position, movementSpeed * Time.deltaTime);
        if (patrolPoints[currentPatrolPointIndex].position == transform.position)
        {
            if (currentPatrolPointIndex == patrolPoints.Length - 1)
                currentPatrolPointIndex = 0;
            else
                currentPatrolPointIndex++;

            return true;
        }

        Debug.LogWarning("Not at next point");
        return false;
    }
}
