using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spawn del bullet nella scena - movimento del bullet - collisione bullet con veicoli

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;   //velocità traslazione bullet
    public int damage;  //danno del bullet

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        //il proiettile collide con veicoli (8, 9, 10, 11) e con la torre (12)
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 11 || other.gameObject.layer == 12)
        {
            if (tag == "PC")    //devo colpire elementi del player
            {
                if (other.tag == "Player")
                {
                    other.gameObject.GetComponent<Health>().Hit(damage); //infliggo danno
                    gameObject.SetActive(false);    //orami il proiettile ha colpito e sparisce dalla scena
                }
            }
            else
            {
                if (tag == "Player")    //devo colpire elementi del pc
                {
                    if (other.tag == "PC")
                    {
                        other.gameObject.GetComponent<Health>().Hit(damage); //infliggo danno
                        gameObject.SetActive(false);    //orami il proiettile ha colpito e sparisce dalla scena
                    }
                }
            }
        }
    }

    //metodo di spawn del gameobject in scena
    public void Spawn(Transform shootPoint)
    {
        transform.Spawn(shootPoint);
    }

    //metodo settaggio danno a runtime
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
