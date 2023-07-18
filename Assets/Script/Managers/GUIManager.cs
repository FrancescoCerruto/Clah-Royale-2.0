using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    [SerializeField] GameObject buttons;    //pulsanti veicoli previsti
    [SerializeField] string[] namePrefabs = new string[14]; //nomi dei veicoli
    Dictionary<string, Button> associations = new Dictionary<string, Button>(); //associazione tra nome del veicolo e pulsante
    [SerializeField] GameObject cards;  //pulsanti presenti in scena
    Button c1;
    Button c2;
    Button c3;
    Button c4;
    string[] buttonsName = new string[4];   //nomi dei veicoli dei rispettivi pulsanti

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < namePrefabs.Length; i++)
        {
            associations.Add(namePrefabs[i], buttons.transform.GetChild(i).gameObject.GetComponent<Button>());
        }
        for (int i = 0; i < buttonsName.Length; i++)
        {
            buttonsName[i] = "";
        }
    }

    //inizializzazione prime 4 "carte"
    private void Start()
    {
        string nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
        c1 = Instantiate(associations[nameMazzo]);
        c1.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(0).transform);
        c1.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c1.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        c1.gameObject.SetActive(true);
        c1.tag = "Card1";
        c1.onClick.AddListener(TaskOnClickc1);
        buttonsName[0] = nameMazzo;

        //evito di mettere 2 volte la stessa carta
        bool uguale = true;
        while (uguale)
        {
            nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
            for (int i = 0; i < buttonsName.Length; i++)
            {
                if (buttonsName[i].Equals(nameMazzo))
                {
                    uguale = true;
                    break;
                }
                else
                {
                    uguale = false;
                    continue;
                }
            }
        }
        c2 = Instantiate(associations[nameMazzo]);
        c2.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(1).transform);
        c2.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        c2.gameObject.SetActive(true);
        c2.tag = "Card2";
        c2.onClick.AddListener(TaskOnClickc2);
        buttonsName[1] = nameMazzo;

        uguale = true;
        while (uguale)
        {
            nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
            for (int i = 0; i < buttonsName.Length; i++)
            {
                if (buttonsName[i].Equals(nameMazzo))
                {
                    uguale = true;
                    break;
                }
                else
                {
                    uguale = false;
                    continue;
                }
            }
        }
        c3 = Instantiate(associations[nameMazzo]);
        c3.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(2).transform);
        c3.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c3.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        c3.gameObject.SetActive(true);
        c3.tag = "Card3";
        c3.onClick.AddListener(TaskOnClickc3);
        buttonsName[2] = nameMazzo;

        uguale = true;
        while (uguale)
        {
            nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
            for (int i = 0; i < buttonsName.Length; i++)
            {
                if (buttonsName[i].Equals(nameMazzo))
                {
                    uguale = true;
                    break;
                }
                else
                {
                    uguale = false;
                    continue;
                }
            }
        }
        c4 = Instantiate(associations[nameMazzo]);
        c4.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(3).transform);
        c4.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        c4.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        c4.gameObject.SetActive(true);
        c4.tag = "Card4";
        c4.onClick.AddListener(TaskOnClickc4);
        buttonsName[3] = nameMazzo;
    }

    //OnClickListener - aggiunti a runtime in quanto non si sa il tag del pulsante a priori
    void TaskOnClickc1()
    {
        PlayerSpawnManager.instance.SetStringTag(c1.tag);
    }
    void TaskOnClickc2()
    {
        PlayerSpawnManager.instance.SetStringTag(c2.tag);
    }
    void TaskOnClickc3()
    {
        PlayerSpawnManager.instance.SetStringTag(c3.tag);
    }
    void TaskOnClickc4()
    {
        PlayerSpawnManager.instance.SetStringTag(c4.tag);
    }

    //metodo per la sotituzione della carta schierata
    public void DisableCard(string tagCard)
    {
        string nameMazzo = "";
        bool uguale = true;
        switch (tagCard)
        {
            case "Card1":
                buttonsName[0] = "";
                while (uguale)
                {
                    nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
                    for (int i = 0; i < buttonsName.Length; i++)
                    {
                        if (buttonsName[i].Equals(nameMazzo))
                        {
                            uguale = true;
                            break;
                        }
                        else
                        {
                            uguale = false;
                            continue;
                        }
                    }
                }
                c1.gameObject.SetActive(false);
                c1 = Instantiate(associations[nameMazzo]);
                c1.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(0).transform);
                c1.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                c1.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                c1.gameObject.SetActive(true);
                c1.tag = "Card1";
                c1.onClick.AddListener(TaskOnClickc1);
                buttonsName[0] = nameMazzo;
                break;
            case "Card2":
                buttonsName[1] = "";
                while (uguale)
                {
                    nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
                    for (int i = 0; i < buttonsName.Length; i++)
                    {
                        if (buttonsName[i].Equals(nameMazzo))
                        {
                            uguale = true;
                            break;
                        }
                        else
                        {
                            uguale = false;
                            continue;
                        }
                    }
                }
                c2.gameObject.SetActive(false);
                c2 = Instantiate(associations[nameMazzo]);
                c2.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(1).transform);
                c2.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                c2.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                c2.gameObject.SetActive(true);
                c2.tag = "Card2";
                c2.onClick.AddListener(TaskOnClickc2);
                buttonsName[1] = nameMazzo;
                break;
            case "Card3":
                buttonsName[2] = "";
                while (uguale)
                {
                    nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
                    for (int i = 0; i < buttonsName.Length; i++)
                    {
                        if (buttonsName[i].Equals(nameMazzo))
                        {
                            uguale = true;
                            break;
                        }
                        else
                        {
                            uguale = false;
                            continue;
                        }
                    }
                }
                c3.gameObject.SetActive(false);
                c3 = Instantiate(associations[nameMazzo]);
                c3.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(2).transform);
                c3.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                c3.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                c3.gameObject.SetActive(true);
                c3.tag = "Card3";
                c3.onClick.AddListener(TaskOnClickc3);
                buttonsName[2] = nameMazzo;
                break;
            case "Card4":
                buttonsName[3] = "";
                while (uguale)
                {
                    nameMazzo = MazzoPlayer.instance.mazzo[Random.Range(0, MazzoPlayer.instance.mazzo.Length)].name;
                    for (int i = 0; i < buttonsName.Length; i++)
                    {
                        if (buttonsName[i].Equals(nameMazzo))
                        {
                            uguale = true;
                            break;
                        }
                        else
                        {
                            uguale = false;
                            continue;
                        }
                    }
                }
                c4.gameObject.SetActive(false);
                c4 = Instantiate(associations[nameMazzo]);
                c4.GetComponent<RectTransform>().SetParent(cards.transform.GetChild(3).transform);
                c4.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                c4.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                c4.gameObject.SetActive(true);
                c4.tag = "Card4";
                c4.onClick.AddListener(TaskOnClickc4);
                buttonsName[3] = nameMazzo;
                break;
        }
    }

    //metodo per abilitare/disabilitare i pulsanti
    public void SetEnabledCard(bool state)
    {
        c1.interactable = state;
        c2.interactable = state;
        c3.interactable = state;
        c4.interactable = state;
    }
}