using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVehicle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //il meccanismo di shoot dei veicoli è già inserito all'interno della classe GroundVehicle
        if (gameObject.layer == 10)
        {
            if (other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 12)
            {
                if (tag == "PC")
                {
                    if (other.tag == "Player")
                    {
                        //mi fermo
                        gameObject.GetComponent<FlyingVehicle>().StopVehicle(); //audio
                        gameObject.GetComponent<Movement>().StopAllCoroutines();    //velocità
                        gameObject.GetComponent<FlyingVehicle>().StopAllCoroutines();   //target
                        if (other.gameObject.layer == 12)
                        {
                            //memorizzo collisione
                            other.gameObject.GetComponent<Tower>().AddCollisionObject(gameObject);
                        }
                        else
                        {
                            //memorizzo sulla classe del veicolo solo le collisioni con i veicoli;
                            gameObject.GetComponent<FlyingVehicle>().AddCollisionObject(other.gameObject); ;
                        }
                        //setto il target a tutte le mie torrette e comincio a sparare (metodo SetTarget) - il target non � la torre ma la sua torretta
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            if (transform.GetChild(i).gameObject.layer == 10)
                            {
                                transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(other.gameObject);
                            }
                        }
                    }
                }
                else
                {
                    if (tag == "Player")
                    {
                        if (other.tag == "PC")
                        {
                            //mi fermo
                            gameObject.GetComponent<FlyingVehicle>().StopVehicle(); //audio
                            gameObject.GetComponent<Movement>().StopAllCoroutines();    //velocità
                            gameObject.GetComponent<FlyingVehicle>().StopAllCoroutines();   //target
                            if (other.gameObject.layer == 12)
                            {
                                //memorizzo collisione
                                other.gameObject.GetComponent<Tower>().AddCollisionObject(gameObject);
                            }
                            else
                            {
                                //memorizzo sulla classe del veicolo solo le collisioni con i veicoli;
                                gameObject.GetComponent<FlyingVehicle>().AddCollisionObject(other.gameObject); ;
                            }
                            //setto il target a tutte le mie torrette e comincio a sparare (metodo SetTarget) - il target non � la torre ma la sua torretta
                            for (int i = 0; i < transform.childCount; i++)
                            {
                                if (transform.GetChild(i).gameObject.layer == 10)
                                {
                                    transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(other.gameObject);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
