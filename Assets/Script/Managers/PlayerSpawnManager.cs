using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FARE TIPO GHOST TURRET --> METODI ESTESI DANNO PUNTI

public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager instance;
    [SerializeField] LayerMask layerMask;
    GameObject vehicle;    //prefab veicolo da spawnare
    RaycastHit hit;
    string tagCard; //tag identificativo della carta della gui
    //target navmesh
    [SerializeField] Transform targetsDx;
    [SerializeField] Transform targetsSx;
    List<GameObject> instantiatedVehicles = new List<GameObject>();

    private void Awake() {
        instance=this;   
    }

    void Update()
    {
        if (vehicle != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    GameObject vehicleSpawned = Instantiate(vehicle, hit.point, hit.transform.rotation);
                    vehicleSpawned.name = vehicle.name + "Player";
                    vehicleSpawned.SetActive(true);
                    if (hit.collider.gameObject.name == "PlayerSpawnLeft")
                    {
                        //devo settare i checkpoint
                        if (vehicle.layer == 10 || vehicle.layer == 11)   //veicolo di aria
                        {
                            //aria sx
                            vehicleSpawned.GetComponent<FlyingVehicle>().TakeCheckPoints(GameObject.Find("CheckPoints").transform.GetChild(0).GetChild(1));
                        }
                        else
                        {
                            //terra sx
                            vehicleSpawned.GetComponent<AgentMovement>().SetTargets(targetsSx);
                        }
                    }
                    else
                    {
                        //devo settare i checkpoint
                        if (vehicle.layer == 10 || vehicle.layer == 11)   //veicolo di aria
                        {
                            //aria dx
                            vehicleSpawned.GetComponent<FlyingVehicle>().TakeCheckPoints(GameObject.Find("CheckPoints").transform.GetChild(0).GetChild(0));
                        }
                        else
                        {
                            //terra dx
                            vehicleSpawned.GetComponent<AgentMovement>().SetTargets(targetsDx);
                        }
                    }
                    vehicleSpawned.tag = "Player";
                    for (int i = 0; i < vehicleSpawned.transform.childCount; i++)
                    {
                        vehicleSpawned.transform.GetChild(i).tag = "Player";
                    }
                    if (vehicleSpawned.layer == 8 || vehicleSpawned.layer == 9)
                    {
                        vehicleSpawned.GetComponent<GroundVehicle>().Spawn(vehicleSpawned.transform);
                    }
                    else
                    {
                        vehicleSpawned.GetComponent<FlyingVehicle>().Spawn(vehicleSpawned.transform, 1f);
                    }
                    GUIManager.instance.DisableCard(tagCard);
                    tagCard = "";
                    vehicle = null;
                    instantiatedVehicles.Add(vehicleSpawned);
                    PartitaManager.instance.StartCoroutine(PartitaManager.instance.SpawnVehicleManager());
                }
            }
        }
    }

    public void SetVehiclePrefab(GameObject vehicle)
    {
        this.vehicle = vehicle;
    }

    public void SetStringTag(string buttonTag){
        tagCard=buttonTag;
    }
}   