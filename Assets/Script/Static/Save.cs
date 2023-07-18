using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Save
{
    //Valori slider
    private static string menuKey = "MENU";
    private static string effectsKey = "EFFECTS";
    private static string gameKey = "GAME";

    private static string[] veicoliKey = new string[] { "ArmyTruckPlayer", "Ural4320_1Player", "4_4futuristePlayer", "AlienCarPlayer", "ArmyVehiclePlayer", "humveePlayer", "Fishbed1Player", "Fishbed2Player", "Fishbed3Player", "i-16Player", "Jet_FighterPlayer", "single_rafalePlayer", "spitfirev6Player", "STUKAPlayer" };

    //Valori esecuzione gioco
    private static string difficoltaKey = "DIFFICOLTA";
    private static string coinKey = "COIN";
    private static string xpKey = "XP";
    private static string levelKey = "LEVEL";
    private static string savedKey = "SAVED";

    //Valori mixer Audio
    private static string menuMixerKey = "MenuVolume";
    private static string gameMixerKey = "GameVolume";
    private static string effectsMixerKey = "EffectsVolume";

    //Valori shop
    private static string shopHealth = "SHOPHEALTH";
    private static string shopDamage = "SHOPDAMAGE";
    private static string shopHealthDamage = "SHOPHEALTHDAMAGE";

    //Audio Menù
    public static void SaveMenuVolume(float volume)
    {
        PlayerPrefs.SetFloat(menuKey, volume);
        PlayerPrefs.Save();
    }

    public static float GetMenuVolume()
    {
        return PlayerPrefs.GetFloat(menuKey);
    }

    //Audio Effects
    public static void SaveEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat(effectsKey, volume);
        PlayerPrefs.Save();
    }

    public static float GetEffectsVolume()
    {
        return PlayerPrefs.GetFloat(effectsKey);
    }

    //Audio Game
    public static void SaveGameVolume(float volume)
    {
        PlayerPrefs.SetFloat(gameKey, volume);
        PlayerPrefs.Save();
    }

    public static float GetGameVolume()
    {
        return PlayerPrefs.GetFloat(gameKey);
    }


    //Mixer menu
    public static void SaveMixerMenu(float value)
    {
        PlayerPrefs.SetFloat(menuMixerKey, value);
        PlayerPrefs.Save();

    }

    public static float GetMixerGame()
    {
        return PlayerPrefs.GetFloat(gameMixerKey);
    }

    //Mixer effects
    public static void SaveMixerEffects(float value)
    {
        PlayerPrefs.SetFloat(effectsMixerKey, value);
        PlayerPrefs.Save();

    }

    public static float GetMixerEffects()
    {
        return PlayerPrefs.GetFloat(effectsMixerKey);
    }

    //Mixer game
    public static void SaveMixerGame(float value)
    {
        PlayerPrefs.SetFloat(gameMixerKey, value);
        PlayerPrefs.Save();

    }

    public static float GetMixerMenu()
    {
        return PlayerPrefs.GetFloat(menuMixerKey);
    }

    //difficoltà pc
    public static void SaveDifficoltaPc(int difficolta)
    {
        PlayerPrefs.SetInt(difficoltaKey, difficolta);
        PlayerPrefs.Save();
        SetSaved(1);
    }

    public static int GetDifficolaPc()
    {
        return PlayerPrefs.GetInt(difficoltaKey);
    }

    //parametri veicoli (vita e danno)
    //overload - metodo con indice per lo shop, metodo con il nome per il recupero dei dati
    public static int GetHealthVehicle(int i)
    {
        return PlayerPrefs.GetInt(veicoliKey[i] + "Health");
    }

    public static int GetHealthVehicle(string name)
    {
        return PlayerPrefs.GetInt(name + "Health");
    }

    public static int GetDamageVehicle(int i)
    {
        return PlayerPrefs.GetInt(veicoliKey[i] + "Damage");
    }

    public static int GetDamageVehicle(string name)
    {
        return PlayerPrefs.GetInt(name + "Damage");
    }

    public static void SetHealthVehicle(int i)
    {
        int health = GetHealthVehicle(i);
        PlayerPrefs.SetInt(veicoliKey[i] + "Health", health * 2);
        PlayerPrefs.Save();
    }

    public static void SetDamageVehicle(int i)
    {
        int damage = GetDamageVehicle(i);
        PlayerPrefs.SetInt(veicoliKey[i] + "Damage", damage * 2);
        PlayerPrefs.Save();
    }

    //coin
    public static int GetCoin()
    {
        return PlayerPrefs.GetInt(coinKey);
    }

    public static void SetCoin(int coin)
    {
        PlayerPrefs.SetInt(coinKey, coin);
        PlayerPrefs.Save();
    }

    //xp
    public static void SetXP(int xp)
    {
        PlayerPrefs.SetInt(xpKey, xp);
        PlayerPrefs.Save();
    }

    public static int GetXP()
    {
        return PlayerPrefs.GetInt(xpKey);
    }

    //livello
    public static void SetLevel(int level)
    {
        PlayerPrefs.SetInt(levelKey, level);
        PlayerPrefs.Save();
    }

    public static int GetLevel()
    {
        return PlayerPrefs.GetInt(levelKey);
    }

    //salvataggio
    public static int GetSaved()
    {
        return PlayerPrefs.GetInt(savedKey);
    }

    public static void SetSaved(int saved)
    {
        PlayerPrefs.SetInt(savedKey, saved);
        PlayerPrefs.Save();
    }

    public static void Reset()
    {
        SetLevel(0);
        SetXP(0);
        SetCoin(0);
        SetSaved(0);
        for (int i = 0; i < GameData.veicoliName.Length; i++)
        {
            PlayerPrefs.SetInt(veicoliKey[i]+shopHealth,0);
            PlayerPrefs.SetInt(veicoliKey[i]+shopDamage,0);
            PlayerPrefs.SetInt(veicoliKey[i]+shopHealthDamage,0);
        }
        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        for (int i = 0; i < GameData.veicoliName.Length; i++)
        {
            //setto la vita e il damage dei veicoli del player
            PlayerPrefs.SetInt(veicoliKey[i] + "Health", GameData.health[i]);
            PlayerPrefs.SetInt(veicoliKey[i] + "Damage", GameData.damage);
            //setto la vita e il damage dei veicoli del pc
            PlayerPrefs.SetInt(GameData.veicoliName[i] + "Health", GameData.health[i]);
            PlayerPrefs.SetInt(GameData.veicoliName[i] + "Damage", GameData.damage);
        }
    }

    //bool di shop
    public static void SetShopHealth(int i)
    {
        PlayerPrefs.SetInt(veicoliKey[i] + shopHealth, 1);
        PlayerPrefs.Save();
    }

    public static void SetShopDamage(int i)
    {
        PlayerPrefs.SetInt(veicoliKey[i] + shopDamage, 1);
        PlayerPrefs.Save();
    }

    public static void SetShopHealthDamage(int i)
    {
        PlayerPrefs.SetInt(veicoliKey[i] + shopHealthDamage, 1);
        PlayerPrefs.Save();
    }

    public static int GetShopHealth(int i)
    {
        return PlayerPrefs.GetInt(veicoliKey[i] + shopHealth);
    }

    public static int GetShopDamage(int i)
    {
        return PlayerPrefs.GetInt(veicoliKey[i] + shopDamage);
    }

    public static int GetShopHealthDamage(int i)
    {
        return PlayerPrefs.GetInt(veicoliKey[i] + shopHealthDamage);
    }

    public static void DeleteShopVehicle(int i)
    {
        PlayerPrefs.SetInt(veicoliKey[i] + "Health", GameData.health[i]);
        PlayerPrefs.SetInt(veicoliKey[i] + "Damage", GameData.damage);
        PlayerPrefs.SetInt(veicoliKey[i]+shopHealth,0);
        PlayerPrefs.SetInt(veicoliKey[i]+shopDamage,0);
        PlayerPrefs.SetInt(veicoliKey[i]+shopHealthDamage,0);
        PlayerPrefs.Save();
    }
}