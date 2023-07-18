using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    int health = 50;
    int damage = 75;
    int healthDamage = 100;
    [SerializeField] Text coin;
    [SerializeField] Text xp;
    [SerializeField] Text level;
    [SerializeField] Transform shopAcquistato;
    [SerializeField] Transform coinsInsufficienti;
    
    [SerializeField] Button[] buttons;


    private IEnumerator ShopDisappear()
    {
        yield return new WaitForSeconds(3f);
        shopAcquistato.GetComponent<CanvasGroup>().alpha = 0f;
        shopAcquistato.GetComponent<CanvasGroup>().blocksRaycasts = false;
        shopAcquistato.GetComponent<CanvasGroup>().interactable = false;
    }

    private IEnumerator CoinsDisappear()
    {
        yield return new WaitForSeconds(3f);
        coinsInsufficienti.GetComponent<CanvasGroup>().alpha = 0f;
        coinsInsufficienti.GetComponent<CanvasGroup>().blocksRaycasts = false;
        coinsInsufficienti.GetComponent<CanvasGroup>().interactable = false;
    }

    void Start()
    {
        coin.text += Save.GetCoin().ToString();
        xp.text += Save.GetXP().ToString();
        level.text += Save.GetLevel().ToString();

      
        for(int i=GameData.lunghezzaMazzo[Save.GetLevel()-1]; i<buttons.Length; i++){
            buttons[i].interactable=false;
            Save.DeleteShopVehicle(i);
        }
    }

    public void ShopVita(int i)
    {
        if (Save.GetCoin() >= health && Save.GetShopHealth(i)==0)
        {
            Save.SetShopHealth(i);
            Save.SetHealthVehicle(i);
            Save.SetCoin(Save.GetCoin() - health);
            coin.text = "Coins: " + Save.GetCoin().ToString();
        }
        else
        {
            if (Save.GetShopHealth(i)==1)
            {
                shopAcquistato.GetComponent<CanvasGroup>().alpha = 1f;
                shopAcquistato.GetComponent<CanvasGroup>().blocksRaycasts = true;
                shopAcquistato.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(ShopDisappear());
            }
            else
            {
                coinsInsufficienti.GetComponent<CanvasGroup>().alpha = 1f;
                coinsInsufficienti.GetComponent<CanvasGroup>().blocksRaycasts = true;
                coinsInsufficienti.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(CoinsDisappear());
            }
        }
    }
    public void ShopDanno(int i)
    {
        if (Save.GetCoin() >= damage && Save.GetShopDamage(i)==0)
        {
            if(GameData.layer[i]==8 || GameData.layer[i]==11)
            {
                Save.SetDamageVehicle(i);
            }
            else
            {
                Save.SetHealthVehicle(i);
            }
            Save.SetShopDamage(i);
            Save.SetCoin(Save.GetCoin() - damage);
            coin.text = "Coins: " + Save.GetCoin().ToString();
        }
        else
        {
            if (Save.GetShopDamage(i)==1)
            {
                shopAcquistato.GetComponent<CanvasGroup>().alpha = 1f;
                shopAcquistato.GetComponent<CanvasGroup>().blocksRaycasts = true;
                shopAcquistato.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(ShopDisappear());
            }
            else
            {
                coinsInsufficienti.GetComponent<CanvasGroup>().alpha = 1f;
                coinsInsufficienti.GetComponent<CanvasGroup>().blocksRaycasts = true;
                coinsInsufficienti.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(CoinsDisappear());
            }
        }
    }
    public void ShopVitaEDanno(int i)
    {
        if (Save.GetCoin() >= healthDamage && Save.GetShopHealthDamage(i)==0)
        {
            Save.SetShopHealthDamage(i);
            Save.SetHealthVehicle(i);
            if(GameData.layer[i]==8 || GameData.layer[i]==11)
            {
                Save.SetDamageVehicle(i);
            }
            else
            {
                Save.SetHealthVehicle(i);
            }
            Save.SetCoin(Save.GetCoin() - healthDamage);
            coin.text = "Coins: " + Save.GetCoin().ToString();
        }
        else
        {
            if (Save.GetShopHealthDamage(i)==1)
            {
                shopAcquistato.GetComponent<CanvasGroup>().alpha = 1f;
                shopAcquistato.GetComponent<CanvasGroup>().blocksRaycasts = true;
                shopAcquistato.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(ShopDisappear());
            }
            else
            {
                coinsInsufficienti.GetComponent<CanvasGroup>().alpha = 1f;
                coinsInsufficienti.GetComponent<CanvasGroup>().blocksRaycasts = true;
                coinsInsufficienti.GetComponent<CanvasGroup>().interactable = true;
                StartCoroutine(CoinsDisappear());
            }
        }
    }
    public void NewPartita()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
    }

    public void MainMenu()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(0);
    }
}
