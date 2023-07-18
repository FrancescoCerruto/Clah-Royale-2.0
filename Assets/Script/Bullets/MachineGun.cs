using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//pool di proiettili - attivazione dei proiettili nella scena - tiro a segno del proiettile

//script sssegnato agli empty dei veicoli che sparano oppure al prefab mitraglietta

public class MachineGun : MonoBehaviour
{
    [SerializeField] GameObject bullet; //prefab proiettile
    [SerializeField] GameObject[] bulletList; //pool proiettili (coda circolare)
    [SerializeField] int bulletLength;  //dimensione pool proiettili
    int bulletCounter = 0;  //indice coda circolare
    [SerializeField] Transform shootPoint;  //punto di spawn
    [SerializeField] float timeToSpawn; //ogni quanto sparo

    [SerializeField] AudioMixerGroup audioMixerGroup;   //mixer suono (canale EffectsVolume)
    [SerializeField] AudioClip shoot;
    AudioSource bulletSource;


    //creazione pool
    private void Awake()
    {
        bulletList = new GameObject[bulletLength];
        for (int i = 0; i < bulletLength; i++)
        {
            bulletList[i] = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            bulletList[i].SetActive(false); //non lo mostro nella scena
            if (tag == "PC")
            {
                bulletList[i].tag = "PC";
            }
            else
            {
                bulletList[i].tag = "Player";
            }
            //devo settare il danno solo ai veicoli che sparano
            if (gameObject.layer == 8 || gameObject.layer == 10)
            {
                //recupero il danno fatto dai proiettili di questo veicolo
                string name = gameObject.transform.parent.name;
                bulletList[i].GetComponent<Bullet>().SetDamage(Save.GetDamageVehicle(name));
            }
        }
        bulletSource = gameObject.AddComponent<AudioSource>();
        bulletSource.outputAudioMixerGroup = audioMixerGroup;
        bulletSource.clip = shoot;
    }

    //coroutine di sparo (posizionamento in scena)
    public IEnumerator Shoot()
    {
        yield return 0; //aspetto il primo lookAt
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    //posizionamento in scena
    void SpawnBullet()
    {
        for (int i = bulletCounter; i < bulletLength; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                bulletList[i].GetComponent<Bullet>().Spawn(shootPoint);
                bulletCounter = i + 1;
                if (bulletCounter >= bulletLength)
                {
                    bulletCounter = 0;
                }
                bulletSource.Play();
                break;
            }
        }
    }
}
