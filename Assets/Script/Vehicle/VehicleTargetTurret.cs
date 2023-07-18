using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TORRETTA VEICOLO CHE SPARA

public class VehicleTargetTurret : MonoBehaviour
{
    GameObject target;  //a chi devo sparare
    bool targetSet = false;
    [SerializeField] GameObject turret;     //canna mitraglietta
    
    private void Update()
    {
        if (targetSet != false)
        {
            if (target.activeInHierarchy)
            {
                turret.transform.LookAt(target.transform);
                //devo controllare se smettere di sparare
                //torre --> vita del target (aspetto animazione ralph per disattivare la torre ma smetto di sparare subito)
                //veicolo --> presenza del target in scena
                if (target.layer == 12)
                {
                    if (target.gameObject.GetComponent<Health>().GetHealth() <= 0)   //se il mio target non è più attivo in scena
                    {
                        target = null;
                        targetSet = false;
                        StopAllCoroutines();
                    }
                }
            }
            else
            {
                target = null;
                targetSet = false;
                StopAllCoroutines();
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        if (targetSet == false)
        {
            this.target = target;
            targetSet = true;
            //inizio a sparare (in tutti gli shoot point che ho)
            MachineGun[] machineGuns = GetComponents<MachineGun>();
            for (int i = 0; i < machineGuns.Length; i++)
            {
                if (gameObject.activeInHierarchy)
                {
                    StartCoroutine(machineGuns[i].Shoot());
                }
            }
        }
    }
}
