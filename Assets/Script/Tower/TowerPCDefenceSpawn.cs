using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script difesa torre pc - quando entra un veicolo instanziato dal player dentro "l'area di questo script" il pc spawna nel punto preimpostato 

public class TowerPCDefenceSpawn : MonoBehaviour
{
    Transform spawnPoint;

    [SerializeField] Transform checkPointsFlying;

    [SerializeField] Transform targetNavMesh;

    private void OnEnable()
    {
        spawnPoint = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 11)
        {
            if (other.tag == "Player")   //sono sotto attacco
            {
                int tipo;
                GameObject defence = null;
                if (MazzoPC.instance.pcDifficolta == MazzoPC.Difficolta.difficile)
                {
                    tipo = Random.Range(0, 4);  //terra spara - terra no - aria spara - aria no
                    switch (tipo)
                    {
                        case 0:
                            defence = Instantiate(MazzoPC.instance.groundShooting[Random.Range(0, MazzoPC.instance.groundShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                        case 1:
                            defence = Instantiate(MazzoPC.instance.groundNoShooting[Random.Range(0, MazzoPC.instance.groundNoShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                        case 2:
                            defence = Instantiate(MazzoPC.instance.flyingShooting[Random.Range(0, MazzoPC.instance.flyingShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                        case 3:
                            defence = Instantiate(MazzoPC.instance.flyingNoShooting[Random.Range(0, MazzoPC.instance.flyingNoShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                    }
                }
                else
                {
                    tipo = Random.Range(0, 3);  //terra spara - terra no - aria no
                    switch (tipo)
                    {
                        case 0:
                            defence = Instantiate(MazzoPC.instance.groundShooting[Random.Range(0, MazzoPC.instance.groundShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                        case 1:
                            defence = Instantiate(MazzoPC.instance.groundNoShooting[Random.Range(0, MazzoPC.instance.groundNoShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                        case 2:
                            defence = Instantiate(MazzoPC.instance.flyingNoShooting[Random.Range(0, MazzoPC.instance.flyingNoShooting.Length)], spawnPoint.position, spawnPoint.rotation);
                            break;
                    }
                }

                //lo registro come veicolo del PC
                defence.tag = "PC";
                foreach (Transform t in defence.transform)  //setto il tag al primo livello di figli (ci sono gli empty con lo scritp machine gun)
                {
                    t.gameObject.tag = "PC";
                }
                defence.name = defence.name.Substring(0, defence.name.IndexOf('('));
                defence.SetActive(true);
                //spawn del veicolo nella scena
                if (tipo == 0 || tipo == 1)
                {
                    defence.GetComponent<GroundVehicle>().Spawn(spawnPoint);
                    defence.GetComponent<AgentMovement>().SetTargets(targetNavMesh);
                }
                else
                {
                    defence.GetComponent<FlyingVehicle>().TakeCheckPoints(checkPointsFlying);
                    if (tag == "Laterale")
                    {
                        defence.GetComponent<FlyingVehicle>().Spawn(spawnPoint, 1f);
                    }
                    else
                    {
                        defence.GetComponent<FlyingVehicle>().Spawn(spawnPoint, 1.5f);
                    }
                }
            }
        }
    }
}