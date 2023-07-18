using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//difesa della torre

public class TowerTargetTurret : MonoBehaviour
{
    [SerializeField] GameObject turret;
    List<GameObject> targets = new List<GameObject>();
    GameObject target;

    private void Update()
    {
        if (target != null)
        {
            turret.transform.LookAt(target.transform);
            if (!target.activeInHierarchy)
            {
                RemoveTarget(target);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 10 || other.gameObject.layer == 11)
        {
            if (tag == "PC")
            {
                if (other.tag == "Player")
                {
                    targets.Add(other.gameObject);
                    if (target == null)
                    {
                        SetTarget();
                    }
                }
            }
            else
            {
                if (tag == "Player")
                {
                    if (other.tag == "PC")
                    {
                        targets.Add(other.gameObject);
                        if (target == null)
                        {
                            SetTarget();
                        }
                    }
                }
            }
        }
    }

    void SetTarget()
    {
        target = targets[0];
        StartCoroutine(GetComponent<MachineGun>().Shoot());
    }

    void RemoveTarget(GameObject obj)
    {
        targets.Remove(obj);
        CheckList();
    }

    void CheckList()
    {
        if (targets.Count == 0)
        {
            Deactivate();
        }
        else
        {
            target = targets[0];
        }
    }

    public void Deactivate()
    {
        target = null;
        StopAllCoroutines();
    }
}
