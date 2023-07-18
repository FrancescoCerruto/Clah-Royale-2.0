using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoShootingVehicle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer == 11)
        {
            if (other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 12)
            {
                if (tag == "PC")
                {
                    if (other.tag == "Player")
                    {
                        //non ho bisogno di memorizzare la collisione in quanto esplodo immediatamente
                        //mi fermo
                        gameObject.GetComponent<FlyingVehicle>().StopVehicle(); //audio
                        gameObject.GetComponent<FlyingVehicle>().StopAllCoroutines();   //target
                        other.gameObject.GetComponent<Health>().Hit(gameObject.GetComponent<Health>().GetHealth());
                        gameObject.GetComponent<Health>().Hit(gameObject.GetComponent<Health>().GetHealth());
                    }
                }
                else
                {
                    if (tag == "Player")
                    {
                        if (other.tag == "PC")
                        {
                            //non ho bisogno di memorizzare la collisione in quanto esplodo immediatamente
                            //mi fermo
                            gameObject.GetComponent<FlyingVehicle>().StopVehicle(); //audio
                            gameObject.GetComponent<FlyingVehicle>().StopAllCoroutines();   //target
                            other.gameObject.GetComponent<Health>().Hit(gameObject.GetComponent<Health>().GetHealth());
                            gameObject.GetComponent<Health>().Hit(gameObject.GetComponent<Health>().GetHealth());
                        }
                    }
                }
            }
        }
    }
}
