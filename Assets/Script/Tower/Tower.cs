using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int coin;
    List<GameObject> collision = new List<GameObject>();

    public void AddCollisionObject(GameObject obj)
    {
        collision.Add(obj);
    }

    public void ClearCollisionObject()
    {
        for (int i = 0; i < collision.Count; i++)
        {
            if (collision[i].layer == 8 || collision[i].layer == 9)
            {
                if (collision[i].activeInHierarchy)
                {
                    //riparto
                    collision[i].GetComponent<GroundVehicle>().RestartVehicle();
                    collision[i].GetComponent<AgentMovement>().RestoreSpeed();
                }
            }
            else
            {
                if (collision[i].activeInHierarchy)
                {
                    //riparto
                    collision[i].GetComponent<Movement>().StartCoroutine(collision[i].GetComponent<Movement>().Translate());
                    collision[i].GetComponent<FlyingVehicle>().RestartVehicle();
                }
            }
        }
    }

    public int GetCoin()
    {
        return coin;
    }
}
