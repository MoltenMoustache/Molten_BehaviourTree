﻿using System.Collections;
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
    [SerializeField] float viewDistance = 10.0f;
    [SerializeField] float attackRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        SelectorNode selector = new SelectorNode();
        tree.AddNode(selector);

        SequenceNode playerFinderSequence = new SequenceNode();
        tree.AddNode(playerFinderSequence, selector);
        tree.AddNode(new LeafNode(CheckForPlayer), playerFinderSequence);
        tree.AddNode(new LeafNode(GoToPlayer), playerFinderSequence);

        SequenceNode patrolSequence = new SequenceNode();
        InverterNode inverter = new InverterNode();
        tree.AddNode(patrolSequence, selector);
        tree.AddNode(inverter, patrolSequence);
        tree.AddNode(new LeafNode(CheckForPlayer), inverter);
        tree.AddNode(new LeafNode(GoToNextPoint), patrolSequence);
    }

    // Update is called once per frame
    void Update()
    {
        tree.Execute();
    }

    public NodeResult CheckForPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, viewDistance))
                {
                    if(hit.transform.tag == "Player" && player.GetComponent<Renderer>().enabled)
                    {
                        return NodeResult.SUCCESS;
                    }
                }
            }
        }
        return NodeResult.FAILURE;
    }

    public NodeResult GoToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player)
        {
            Vector3 playerPos = player.transform.position;
            playerPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, movementSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                Destroy(player);
                return NodeResult.SUCCESS;
            }
        }
        return NodeResult.RUNNING;
    }

    public NodeResult GoToNextPoint()
    {
        Vector3 patrolPos = patrolPoints[currentPatrolPointIndex].transform.position;
        patrolPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, patrolPos, movementSpeed * Time.deltaTime);
        if (patrolPos == transform.position)
        {
            if (currentPatrolPointIndex == patrolPoints.Length - 1)
                currentPatrolPointIndex = 0;
            else
                currentPatrolPointIndex++;

            return NodeResult.SUCCESS;
        }

        return NodeResult.RUNNING;
    }
}
