using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//METODO DI SPAWN COMUNE TRA VEICOLO E BULLET

public static class Extension
{
    //metodo scritto più volte da varie classi
    //il primo parametro indica la classe che stiamo estendendo
    //this dice chi sta invocando
    public static void Spawn(this Transform trans, Transform spawnPoint)
    {
        //non è più agganciato a nulla --> "ci vuola una sua istanza" (quella dell'oggetto in scena che invoca il metodo)
        trans.position = spawnPoint.position;
        trans.rotation = spawnPoint.rotation;
        //ho ancora un oggetto non presente in scena (disattivato da prefab o da codice)
        trans.gameObject.SetActive(true);
    }
}
