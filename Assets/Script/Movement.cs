using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MOVIMENTO veicolo di aria e ralph

public class Movement : MonoBehaviour
{
    [SerializeField] int speed;

    private void Awake()
    {
        StartCoroutine(Translate());
    }

    public IEnumerator Translate()
    {
        while(true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            yield return 0;
        }
    }
}