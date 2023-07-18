using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Vehicle : MonoBehaviour
{
    protected AudioSource vehicleSource;
    [SerializeField] protected AudioClip vehicleMove;
    [SerializeField] protected AudioClip vehicleStop;
    [SerializeField] protected AudioMixerGroup vehicleMixerGroup;
    protected List<GameObject> collision = new List<GameObject>();

    protected virtual void OnEnable()
    {
        vehicleSource = gameObject.AddComponent<AudioSource>();
        vehicleSource.outputAudioMixerGroup = vehicleMixerGroup;
        vehicleSource.clip = vehicleMove;
        vehicleSource.Play();
    }

    public virtual void StopVehicle()
    {
        vehicleSource.clip = vehicleStop;
        vehicleSource.Play();
    }

    public virtual void RestartVehicle()
    {
        vehicleSource.clip = vehicleMove;
        vehicleSource.Play();
    }

    public virtual void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    public virtual void Spawn(Transform spawnPoint, float deltay)
    {
        transform.Spawn(spawnPoint);
        transform.Translate(Vector3.up * deltay);
    }

    public virtual void AddCollisionObject(GameObject obj)
    {
        collision.Add(obj);
    }

    public virtual void ClearCollisionObject()
    {
        for (int i = 0; i < collision.Count; i++)
        {
            if (collision[i].layer == 8 || collision[i].layer == 9)
            {
                if (collision[i].activeInHierarchy)
                {
                    //riparto
                    collision[i].GetComponent<AgentMovement>().RestoreSpeed();
                    collision[i].GetComponent<GroundVehicle>().RestartVehicle();
                }
            }
            else
            {

                if (collision[i].activeInHierarchy)
                {
                    //riparto
                    collision[i].GetComponent<Movement>().StartCoroutine(collision[i].GetComponent<Movement>().Translate());
                    collision[i].GetComponent<FlyingVehicle>().RestartVehicle(); //audio
                }
            }
        }
    }
}
