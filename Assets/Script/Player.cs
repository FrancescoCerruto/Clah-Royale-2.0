using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int xp = 0;
    int level;

    void Awake()
    {
        xp = Save.GetXP();
        level = Save.GetLevel();
        if (level == 0)
        {
            level = 1;
            Save.SetLevel(level);
        }
    }

    public void AddXP(int xpplus)
    {
        xp += xpplus;
        if (xp < 0)
        {
            xp = 0;
        }
        Save.SetXP(xp);
        //parto da livello 1
        if (xp < 1000)
        {
            if (level != 1)
            {
                level = 1;
                gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                Save.SetLevel(level);
            }
        }
        else
        {
            if (xp >= 1000 && xp < 1500)
            {
                //livello 2
                if (level != 2)
                {
                    level = 2;
                    gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                    Save.SetLevel(level);
                }
            }
            else
            {
                //livello 3
                if (xp >= 1500 && xp < 2000)
                {
                    if (level != 3)
                    {
                        level = 3;
                        gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                        Save.SetLevel(level);
                    }
                }
                else
                {
                    //livello 4
                    if (xp >= 2000 && xp < 2500)
                    {
                        if (level != 4)
                        {
                            level = 4;
                            gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                            Save.SetLevel(level);
                        }
                    }
                    else
                    {
                        //livello 5
                        if (xp >= 2500 && xp < 3000)
                        {
                            if (level != 5)
                            {
                                level = 5;
                                gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                                Save.SetLevel(level);
                            }
                        }
                        else
                        {
                            //livello 6
                            if (xp >= 3000)
                            {
                                if (level != 6)
                                {
                                    level = 6;
                                    gameObject.GetComponent<MazzoPlayer>().ChangeLivello(level);
                                    Save.SetLevel(level);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
