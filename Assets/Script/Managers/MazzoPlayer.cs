using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazzoPlayer : MonoBehaviour
{
    public static MazzoPlayer instance;
    public GameObject[] mazzo;
    [SerializeField] GameObject[] prefabs;

    private void Awake()
    {
        instance = this;
        int level = Save.GetLevel();
        if (level == 0)
        {
            mazzo = new GameObject[GameData.lunghezzaMazzo[level]];
            level = 1;
        }
        else
        {
            mazzo = new GameObject[GameData.lunghezzaMazzo[level - 1]];
        }
        if (level == 1)
        {
            mazzo[0] = prefabs[8];
            mazzo[1] = prefabs[9];
            mazzo[2] = prefabs[10];
            mazzo[3] = prefabs[11];
        }
        else
        {
            if (level == 2)
            {
                mazzo[0] = prefabs[8];
                mazzo[1] = prefabs[9];
                mazzo[2] = prefabs[10];
                mazzo[3] = prefabs[11];
                mazzo[4] = prefabs[12];
                mazzo[5] = prefabs[13];
            }
            else
            {
                if (level == 3)
                {
                    mazzo[0] = prefabs[8];
                    mazzo[1] = prefabs[9];
                    mazzo[2] = prefabs[10];
                    mazzo[3] = prefabs[11];
                    mazzo[4] = prefabs[12];
                    mazzo[5] = prefabs[13];
                    mazzo[6] = prefabs[0];
                    mazzo[7] = prefabs[1];
                }
                else
                {
                    if (level == 4)
                    {
                        mazzo[0] = prefabs[8];
                        mazzo[1] = prefabs[9];
                        mazzo[2] = prefabs[10];
                        mazzo[3] = prefabs[11];
                        mazzo[4] = prefabs[12];
                        mazzo[5] = prefabs[13];
                        mazzo[6] = prefabs[0];
                        mazzo[7] = prefabs[1];
                        mazzo[8] = prefabs[2];
                        mazzo[9] = prefabs[3];
                    }
                    else
                    {
                        if (level == 5)
                        {
                            mazzo[0] = prefabs[8];
                            mazzo[1] = prefabs[9];
                            mazzo[2] = prefabs[10];
                            mazzo[3] = prefabs[11];
                            mazzo[4] = prefabs[12];
                            mazzo[5] = prefabs[13];
                            mazzo[6] = prefabs[0];
                            mazzo[7] = prefabs[1];
                            mazzo[8] = prefabs[2];
                            mazzo[9] = prefabs[3];
                            mazzo[10] = prefabs[4];
                            mazzo[11] = prefabs[7];
                        }
                        else
                        {
                            if (level == 6)
                            {
                                mazzo[0] = prefabs[8];
                                mazzo[1] = prefabs[9];
                                mazzo[2] = prefabs[10];
                                mazzo[3] = prefabs[11];
                                mazzo[4] = prefabs[12];
                                mazzo[5] = prefabs[13];
                                mazzo[6] = prefabs[0];
                                mazzo[7] = prefabs[1];
                                mazzo[8] = prefabs[2];
                                mazzo[9] = prefabs[3];
                                mazzo[10] = prefabs[4];
                                mazzo[11] = prefabs[7];
                                mazzo[12] = prefabs[5];
                                mazzo[13] = prefabs[6];
                            }
                        }
                    }
                }
            }
        }
    }

    public void ChangeLivello(int livello)
    {
        if (livello == 2)
        {
            mazzo = new GameObject[GameData.lunghezzaMazzo[livello - 1]];
            mazzo[0] = prefabs[8];
            mazzo[1] = prefabs[9];
            mazzo[2] = prefabs[10];
            mazzo[3] = prefabs[11];
            mazzo[4] = prefabs[12];
            mazzo[5] = prefabs[13];
        }
        else
        {
            if (livello == 3)
            {
                mazzo = new GameObject[GameData.lunghezzaMazzo[livello - 1]];
                mazzo[0] = prefabs[8];
                mazzo[1] = prefabs[9];
                mazzo[2] = prefabs[10];
                mazzo[3] = prefabs[11];
                mazzo[4] = prefabs[12];
                mazzo[5] = prefabs[13];
                mazzo[6] = prefabs[0];
                mazzo[7] = prefabs[1];
            }
            else
            {
                if (livello == 4)
                {
                    mazzo = new GameObject[GameData.lunghezzaMazzo[livello - 1]];
                    mazzo[0] = prefabs[8];
                    mazzo[1] = prefabs[9];
                    mazzo[2] = prefabs[10];
                    mazzo[3] = prefabs[11];
                    mazzo[4] = prefabs[12];
                    mazzo[5] = prefabs[13];
                    mazzo[6] = prefabs[0];
                    mazzo[7] = prefabs[1];
                    mazzo[8] = prefabs[2];
                    mazzo[9] = prefabs[3];
                }
                else
                {
                    if (livello == 5)
                    {
                        mazzo = new GameObject[GameData.lunghezzaMazzo[livello - 1]];
                        mazzo[0] = prefabs[8];
                        mazzo[1] = prefabs[9];
                        mazzo[2] = prefabs[10];
                        mazzo[3] = prefabs[11];
                        mazzo[4] = prefabs[12];
                        mazzo[5] = prefabs[13];
                        mazzo[6] = prefabs[0];
                        mazzo[7] = prefabs[1];
                        mazzo[8] = prefabs[2];
                        mazzo[9] = prefabs[3];
                        mazzo[10] = prefabs[4];
                        mazzo[11] = prefabs[7];
                    }
                    else
                    {
                        if (livello == 6)
                        {
                            mazzo = new GameObject[GameData.lunghezzaMazzo[livello - 1]];
                            mazzo[0] = prefabs[8];
                            mazzo[1] = prefabs[9];
                            mazzo[2] = prefabs[10];
                            mazzo[3] = prefabs[11];
                            mazzo[4] = prefabs[12];
                            mazzo[5] = prefabs[13];
                            mazzo[6] = prefabs[0];
                            mazzo[7] = prefabs[1];
                            mazzo[8] = prefabs[2];
                            mazzo[9] = prefabs[3];
                            mazzo[10] = prefabs[4];
                            mazzo[11] = prefabs[7];
                            mazzo[12] = prefabs[5];
                            mazzo[13] = prefabs[6];
                        }
                    }
                }
            }
        }
    }

}