using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Transform targets;
    float speedDefault;
    GameObject[] towersPCLeft = new GameObject[2];
    GameObject[] towersPCRight = new GameObject[2];
    GameObject[] towersPlayerLeft = new GameObject[2];
    GameObject[] towersPlayerRight = new GameObject[2];
    int towerIndex = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        speedDefault = agent.speed;
        //target player sx
        towersPlayerLeft[0] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        towersPlayerLeft[1] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        //target player dx
        towersPlayerRight[0] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(0).GetChild(2).gameObject;
        towersPlayerRight[1] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
        //target pc sx
        towersPCLeft[0] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        towersPCLeft[1] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        //target pc dx
        towersPCRight[0] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(1).GetChild(2).gameObject;
        towersPCRight[1] = GameObject.Find("PianoDiGioco").transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void RestoreSpeed()
    {
        agent.speed = speedDefault;
    }

    public void StopSpeed()
    {
        agent.GetComponent<NavMeshAgent>().speed = 0f;
    }

    public void SetTargets(Transform targets)
    {
        this.targets = targets;
        target = targets.GetChild(0);
        MoveToTarget();
    }

    public void ChangeTarget()
    {
        target = targets.GetChild(1);
        MoveToTarget();
    }

    public GameObject GetTowerTarget()
    {
        if (tag == "Player")
        {
            if (targets.tag == "Sx")
            {
                return towersPlayerLeft[towerIndex++];
            }
            else
            {
                return towersPlayerRight[towerIndex++];
            }
        }
        else
        {
            if (targets.tag == "Sx")
            {
                return towersPCLeft[towerIndex++];
            }
            else
            {
                return towersPCRight[towerIndex++];
            }
        }
    }
}
