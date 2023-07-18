using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingVehicle : Vehicle
{
    Transform[] checkPoints;
    Transform target;
    int targetIndex = 0;
    bool look = false;

    private void Update()
    {
        if (look)
        {
            transform.LookAt(target.position);
        }
    }

    public void TakeCheckPoints(Transform spawnPoint)
    {
        checkPoints = new Transform[spawnPoint.childCount];
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i] = spawnPoint.GetChild(i);
        }
        target = checkPoints[targetIndex];
        look = true;
    }

    //mi serve per cambiare target del check point
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer == 10 || gameObject.layer == 11)
        {
            if (other.gameObject.layer == 15)
            {
                if (tag == "PC")
                {
                    if (other.tag == "PC")
                    {
                        target = checkPoints[++targetIndex];
                    }
                }
                else
                {   
                    if (other.tag == "Player")
                    {
                        target = checkPoints[++targetIndex];
                    }
                }
            }
        }
    }
}
