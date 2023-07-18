using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalphPugno : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}