using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTower : Health, Killed<float>
{
    [SerializeField] Image lifeBar; //UI

    protected override void OnEnable()
    {
        base.OnEnable();
        lifeBar.fillAmount = 1;
    }

    //con questa coroutine aspetto l'animazione di ralph prima di sparire - logica di sparizione
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1.2f);
        AudioManager.instance.PlayTowerDisappear();
        yield return new WaitForSeconds(0.4f);
        if (transform.GetChild(transform.childCount - 3).tag == "Laterale")
        {
            ParticleManager.instance.SpawnParticleTower(transform.GetChild(transform.childCount - 3).transform);
        }
        else
        {
            ParticleManager.instance.SpawnParticleCentraltower(transform.GetChild(transform.childCount - 3).transform);
        }
        if (gameObject.tag == "PC")
        {
            PartitaManager.instance.DistruggiTorrePC(gameObject);
        }
        else
        {
            PartitaManager.instance.DistruggiTorrePlayer(gameObject);
        }
        //faccio ripartire gli oggetti che io bloccavo (sempre se ci sono)
        gameObject.GetComponent<Tower>().ClearCollisionObject();
        gameObject.SetActive(false);
    }

    public override void Hit(float damage)
    {
        base.Hit(damage);
    }

    public override void Kill()
    {
        float fill = health / maxHealth;
        lifeBar.fillAmount = fill;
        lifeBar.color = Color.Lerp(Color.yellow, Color.red, 1 - fill);
        if (health <= 0 && dead == false)
        {
            dead = true;
            if (tag == "PC")    //controllo necessario per sapere se tra i figli della torre c'è il gameobject TurretDefenceSpawn
            {
                for (int i = 0; i < transform.childCount - 5; i++)
                {
                    transform.GetChild(i).GetComponent<TowerTargetTurret>().StopAllCoroutines();
                }
                if (transform.GetChild(transform.childCount - 4).tag == "Laterale")
                {
                    RalphManager.instance.SpawnLaterale(transform.GetChild(transform.childCount - 4).transform);
                }
                else
                {
                    RalphManager.instance.SpawnCentrale(transform.GetChild(transform.childCount - 3).transform);
                }
                StartCoroutine(Disappear());
            }
            else
            {
                for (int i = 0; i < transform.childCount - 3; i++)
                {
                    transform.GetChild(i).GetComponent<TowerTargetTurret>().StopAllCoroutines();
                }
                if (transform.GetChild(transform.childCount - 3).tag == "Laterale")
                {
                    RalphManager.instance.SpawnLaterale(transform.GetChild(transform.childCount - 3).transform);
                }
                else
                {
                    RalphManager.instance.SpawnCentrale(transform.GetChild(transform.childCount - 3).transform);
                }
                StartCoroutine(Disappear());
            }
        }
    }
}