using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVehicle : Health, Killed<float>
{
    protected override void OnEnable()
    {
        string name = gameObject.name;
        maxHealth = Save.GetHealthVehicle(name);
        health = maxHealth;
    }

    public override void Hit(float damage)
    {
        base.Hit(damage);
    }

    public override void Kill(){
        if (health <= 0 && dead == false)
        {
            if (gameObject.layer == 10 || gameObject.layer == 11)
            {
                dead = true;
                ParticleManager.instance.SpawnParticleAirplane(transform);
                gameObject.GetComponent<FlyingVehicle>().ClearCollisionObject();
            }
            else
            {
                dead = true;
                ParticleManager.instance.SpawnParticleCar(transform);
                gameObject.GetComponent<GroundVehicle>().ClearCollisionObject();
            }
            gameObject.SetActive(false);
        }
    }
}