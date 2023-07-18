using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RalphManager : MonoBehaviour
{
    public static RalphManager instance;
    [SerializeField] GameObject camminata;
    [SerializeField] GameObject salto;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnLaterale(Transform spawnPoint)
    {
        Instantiate(camminata, spawnPoint.position, spawnPoint.rotation);
    }

    public void SpawnCentrale(Transform spawnPoint)
    {
        GameObject ralph = Instantiate(salto, spawnPoint.position, spawnPoint.rotation);
    }
}
