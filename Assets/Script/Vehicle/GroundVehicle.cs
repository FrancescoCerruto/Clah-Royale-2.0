using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVehicle : Vehicle
{
    private IEnumerator WaitToExplosion(GameObject other)
    {
        yield return new WaitForSeconds(0.1f);
        //esplodo
        other.GetComponent<HealthVehicle>().Hit(gameObject.GetComponent<Health>().GetHealth());
        //scompaio
        gameObject.GetComponent<HealthVehicle>().Hit(gameObject.GetComponent<Health>().GetHealth());
    }

    //mi serve per rilevare collisioni con altri veicoli e con target navmesh e cominciare a sparare (e cambiare target navmesh)
    private void OnTriggerEnter(Collider other)
    {
        //io sono una macchina
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9) //collisione con altre macchine
        {
            if (other.tag == "PC" && tag == "Player")
            {
                //sto collidendo con un veicolo nemico --> devo limitarmi a fermari e a "sparare"
                //mi fermo
                gameObject.GetComponent<GroundVehicle>().StopVehicle(); //audio
                gameObject.GetComponent<AgentMovement>().StopSpeed();    //velocità
                //memorizzo collisione;
                gameObject.GetComponent<GroundVehicle>().AddCollisionObject(other.gameObject);
                //sparo
                if (gameObject.layer == 8)
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        if (transform.GetChild(i).gameObject.layer == 8)
                        {
                            transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(other.gameObject);
                        }
                    }
                }
                else
                {
                    //devo aspettare per evitare errori nella memorizzazione della collisione per l'altro veicolo
                    StartCoroutine(WaitToExplosion(other.gameObject));
                }
            }
            else
            {
                if (other.tag == "Player" && tag == "PC")
                {
                    //sto collidendo con un veicolo --> devo limitarmi a fermari e a "sparare"
                    //mi fermo
                    gameObject.GetComponent<GroundVehicle>().StopVehicle(); //audio
                    gameObject.GetComponent<AgentMovement>().StopSpeed();    //velocità
                    //memorizzo collisione;
                    gameObject.GetComponent<GroundVehicle>().AddCollisionObject(other.gameObject);
                    //sparo
                    if (gameObject.layer == 8)
                    {
                        for (int i = 0; i < transform.childCount; i++)
                        {
                            if (transform.GetChild(i).gameObject.layer == 8)
                            {
                                transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(other.gameObject);
                            }
                        }
                    }
                    else
                    {
                        StartCoroutine(WaitToExplosion(other.gameObject));
                    }
                }
            }
        }
        else
        {
            if (other.gameObject.layer == 14)   //ho raggiunto il target della navmesh --> devo passare al target successivo, fermari e sparare
            {
                if (tag == "PC")
                {
                    if (other.tag == "PC")
                    {
                        //mi fermo
                        gameObject.GetComponent<GroundVehicle>().StopVehicle(); //audio
                        //prossimo target
                        gameObject.GetComponent<AgentMovement>().ChangeTarget();    //passo al target successivo
                        //torre da danneggiare
                        GameObject tower = gameObject.GetComponent<AgentMovement>().GetTowerTarget();
                        //memorizzo collisione con la torre
                        tower.GetComponent<Tower>().AddCollisionObject(gameObject);
                        if (tower.activeInHierarchy && tower.GetComponent<HealthTower>().GetHealth() > 0) //controllo necessario dal momento in cui ho distrutto la prima torre;
                        {
                            gameObject.GetComponent<AgentMovement>().StopSpeed();    //velocità
                            if (gameObject.layer == 8)
                            {
                                //sparo
                                for (int i = 0; i < transform.childCount; i++)
                                {
                                    if (transform.GetChild(i).gameObject.layer == 8)
                                    {
                                        transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(tower);
                                    }
                                }
                            }
                            else
                            {
                                //esplodo
                                tower.GetComponent<HealthTower>().Hit(gameObject.GetComponent<HealthVehicle>().GetHealth());
                                //scompaio
                                gameObject.GetComponent<HealthVehicle>().Hit(gameObject.GetComponent<HealthVehicle>().GetHealth());
                            }
                        }
                    }
                }
                else //script agganciato a veicolo del player --> scontro con pc
                {
                    if (tag == "Player")
                    {
                        if (other.tag == "Player")
                        {
                            //mi fermo
                            gameObject.GetComponent<GroundVehicle>().StopVehicle(); //audio
                            //prossimo target
                            gameObject.GetComponent<AgentMovement>().ChangeTarget();    //passo al target successivo
                            //target da danneggiare
                            GameObject tower = gameObject.GetComponent<AgentMovement>().GetTowerTarget();
                            //memorizzo collisione con la torre
                            tower.GetComponent<Tower>().AddCollisionObject(gameObject);
                            if (tower.activeInHierarchy && tower.GetComponent<HealthTower>().GetHealth() > 0) //controllo necessario dal momento in cui ho distrutto la prima torre;
                            {
                                gameObject.GetComponent<AgentMovement>().StopSpeed();    //velocità
                                if (gameObject.layer == 8)
                                {
                                    //sparo
                                    for (int i = 0; i < transform.childCount; i++)
                                    {
                                        if (transform.GetChild(i).gameObject.layer == 8)
                                        {
                                            transform.GetChild(i).gameObject.GetComponent<VehicleTargetTurret>().SetTarget(tower);
                                        }
                                    }
                                }
                                else
                                {
                                    //esplodo
                                    tower.GetComponent<HealthTower>().Hit(gameObject.GetComponent<HealthVehicle>().GetHealth());
                                    //scompaio
                                    gameObject.GetComponent<HealthVehicle>().Hit(gameObject.GetComponent<HealthVehicle>().GetHealth());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
