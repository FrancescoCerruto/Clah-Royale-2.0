using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PartitaManager : MonoBehaviour
{
    public static PartitaManager instance;
    int torriPc = 3;
    int torriPlayer = 3;
    float timer;

    int coins=0;
    [SerializeField] GameObject player;
    [SerializeField] Text timeText;
    [SerializeField] GameObject[] playerPosition;
    [SerializeField] GameObject[] pcPosition;
    [SerializeField] Transform[] esito;
    [SerializeField] Text text;
    [SerializeField] Text coinText;


    private void Awake()
    {
        instance = this;
        timer = 90;
        StartCoroutine(TempoManager());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(2);
        }
    }

    public void DistruggiTorrePlayer(GameObject torre)
    {
        torriPlayer--;
        if (Vector3.Distance(playerPosition[1].transform.position, torre.transform.position) < 0.001f )
        {
            esito[1].GetComponent<CanvasGroup>().alpha = 1;
            esito[1].GetComponent<CanvasGroup>().blocksRaycasts = true;
            esito[1].GetComponent<CanvasGroup>().interactable = true;
            player.GetComponent<Player>().AddXP(-30);
            StopAllCoroutines();
            Time.timeScale = 0f;
        }
    }
    public void DistruggiTorrePC(GameObject torre)
    {
        torriPc--;
        coins+=torre.GetComponent<Tower>().GetCoin();
        coinText.text="Coins: "+coins.ToString();
        if (Vector3.Distance(pcPosition[1].transform.position, torre.transform.position) < 0.001f)
        {
            CoinManager.instance.AddCoins(coins);
            esito[0].GetComponent<CanvasGroup>().alpha = 1;
            esito[0].GetComponent<CanvasGroup>().blocksRaycasts = true;
            esito[0].GetComponent<CanvasGroup>().interactable = true;
            player.GetComponent<Player>().AddXP(50);
            StopAllCoroutines();
            Time.timeScale = 0f;
        }
    }
    public void Shop()
    {
        Time.timeScale = 1f;
        AsyncOperation op = SceneManager.LoadSceneAsync(2);
    }

    IEnumerator TempoManager()
    {
        while(!timeText.text.Equals("00:00"))
        {
            timer -= Time.deltaTime;
            //calcolo minuti e secondi 
            timeText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
            yield return 0;
        }
         CoinManager.instance.AddCoins(coins);
        if (torriPc < torriPlayer)
        {
            esito[0].GetComponent<CanvasGroup>().alpha = 1;
            esito[0].GetComponent<CanvasGroup>().blocksRaycasts = true;
            esito[0].GetComponent<CanvasGroup>().interactable = true;
            player.GetComponent<Player>().AddXP(50);
            Time.timeScale = 0f;
        }
        else
        {
            if (torriPc > torriPlayer)
            {
                esito[1].GetComponent<CanvasGroup>().alpha = 1;
                esito[1].GetComponent<CanvasGroup>().blocksRaycasts = true;
                esito[1].GetComponent<CanvasGroup>().interactable = true;
                player.GetComponent<Player>().AddXP(-30);
                Time.timeScale = 0f;
            }
            else
            {
                esito[2].GetComponent<CanvasGroup>().alpha = 1;
                esito[2].GetComponent<CanvasGroup>().blocksRaycasts = true;
                esito[2].GetComponent<CanvasGroup>().interactable = true;
                player.GetComponent<Player>().AddXP(25);
                Time.timeScale = 0f;
            }
        }
    }

    public IEnumerator SpawnVehicleManager()
    {
        text.enabled = true;
        GUIManager.instance.SetEnabledCard(false);
        yield return new WaitForSeconds(2f);
        GUIManager.instance.SetEnabledCard(true);
        text.enabled = false;
    }
}
