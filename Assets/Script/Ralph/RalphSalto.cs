using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalphSalto : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(Disappear());
    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}