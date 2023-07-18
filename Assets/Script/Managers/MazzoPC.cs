using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazzoPC : MonoBehaviour
{
    public static MazzoPC instance;
    public enum Difficolta { facile = 1, medio = 2, difficile = 3 };
    private enum LunghezzaMazzo { facile = 8, medio = 11, difficile = 14 };
    public Difficolta pcDifficolta;
    private GameObject[] mazzo;
    public GameObject[] groundShooting;
    public GameObject[] groundNoShooting;
    public GameObject[] flyingShooting;
    public GameObject[] flyingNoShooting;
    [SerializeField] GameObject[] prefabs;

    private void Awake()
    {
        instance = this;
        pcDifficolta = (Difficolta)Save.GetDifficolaPc();
        switch (pcDifficolta)
        {
            case Difficolta.difficile:
                mazzo = new GameObject[(int)LunghezzaMazzo.difficile];
                mazzo[0] = prefabs[0];
                mazzo[1] = prefabs[1];
                mazzo[2] = prefabs[2];
                mazzo[3] = prefabs[3];
                mazzo[4] = prefabs[4];
                mazzo[5] = prefabs[5];
                mazzo[6] = prefabs[6];
                mazzo[7] = prefabs[7];
                mazzo[8] = prefabs[8];
                mazzo[9] = prefabs[9];
                mazzo[10] = prefabs[10];
                mazzo[11] = prefabs[11];
                mazzo[12] = prefabs[12];
                mazzo[13] = prefabs[13];
                groundShooting = new GameObject[4];
                groundNoShooting = new GameObject[2];
                flyingShooting = new GameObject[2];
                flyingNoShooting = new GameObject[6];
                for (int i = 0; i < groundShooting.Length; i++)
                {
                    groundShooting[i] = mazzo[10 + i];
                }
                for (int i = 0; i < groundNoShooting.Length; i++)
                {
                    groundNoShooting[i] = mazzo[8 + i];
                }
                for (int i = 0; i < flyingShooting.Length; i++)
                {
                    flyingShooting[i] = mazzo[6 + i];
                }
                for (int i = 0; i < flyingNoShooting.Length; i++)
                {
                    flyingNoShooting[i] = mazzo[i];
                }
                break;
            case Difficolta.medio:
                mazzo = new GameObject[(int)LunghezzaMazzo.medio];
                mazzo[0] = prefabs[0];
                mazzo[1] = prefabs[1];
                mazzo[2] = prefabs[2];
                mazzo[3] = prefabs[3];
                mazzo[4] = prefabs[4];
                mazzo[5] = prefabs[5];
                mazzo[6] = prefabs[8];
                mazzo[7] = prefabs[9];
                mazzo[8] = prefabs[10];
                mazzo[9] = prefabs[12];
                mazzo[10] = prefabs[13];
                groundShooting = new GameObject[3];
                groundNoShooting = new GameObject[2];
                flyingNoShooting = new GameObject[6];
                for (int i = 0; i < groundShooting.Length; i++)
                {
                    groundShooting[i] = mazzo[8 + i];
                }
                for (int i = 0; i < groundNoShooting.Length; i++)
                {
                    groundNoShooting[i] = mazzo[6 + i];
                }
                for (int i = 0; i < flyingNoShooting.Length; i++)
                {
                    flyingNoShooting[i] = mazzo[i];
                }
                break;
            case Difficolta.facile:

                mazzo = new GameObject[(int)LunghezzaMazzo.facile];
                mazzo[0] = prefabs[0];
                mazzo[1] = prefabs[1];
                mazzo[2] = prefabs[3];
                mazzo[3] = prefabs[4];
                mazzo[4] = prefabs[5];
                mazzo[5] = prefabs[8];
                mazzo[6] = prefabs[10];
                mazzo[7] = prefabs[13];
                groundShooting = new GameObject[2];
                groundNoShooting = new GameObject[1];
                flyingNoShooting = new GameObject[5];
                for (int i = 0; i < groundShooting.Length; i++)
                {
                    groundShooting[i] = mazzo[6 + i];
                }
                for (int i = 0; i < groundNoShooting.Length; i++)
                {
                    groundNoShooting[i] = mazzo[5 + i];
                }
                for (int i = 0; i < flyingNoShooting.Length; i++)
                {
                    flyingNoShooting[i] = mazzo[i];
                }
                break;
        }
    }
}
