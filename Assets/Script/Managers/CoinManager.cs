using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    [SerializeField] Text coinText;
    int coins;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RenderCoins();
    }

    public void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        Save.SetCoin(Save.GetCoin() + coinsToAdd);
        
        RenderCoins();
    }

    private void RenderCoins()
    {
        coinText.text = "Coins: " + coins.ToString();
    }
}
