using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;
    [SerializeField] GameObject car;
    [SerializeField] GameObject tower;
    [SerializeField] GameObject centralTower;
    [SerializeField] GameObject airplane;
   
    private void Awake() {
    instance=this;
    }

    public void SpawnParticleCar(Transform Spawnpoint){
    Instantiate(car,Spawnpoint.position,Spawnpoint.rotation);
    }
    public void SpawnParticleTower(Transform Spawnpoint){
    Instantiate(tower,Spawnpoint.position,Spawnpoint.rotation);
    
    }
    public void SpawnParticleCentraltower(Transform Spawnpoint){
    Instantiate(centralTower,Spawnpoint.position,Spawnpoint.rotation);
    }

    public void SpawnParticleAirplane(Transform Spawnpoint){
    Instantiate(airplane,Spawnpoint.position,Spawnpoint.rotation);
    }

}
