using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalphCamminata : MonoBehaviour
{
    [SerializeField] GameObject pugno;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            Instantiate(pugno, gameObject.transform.position, gameObject.transform.rotation);
            gameObject.SetActive(false);
        }
    }
}