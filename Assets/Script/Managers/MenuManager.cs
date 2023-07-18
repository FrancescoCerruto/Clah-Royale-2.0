using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider menu;
    [SerializeField] Slider game;
    [SerializeField] Slider effects;
    [SerializeField] GameObject container;
    [SerializeField] Text titolo;
    [SerializeField] GameObject credits;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Transform loadGame;
    [SerializeField] Transform salvataggioEsistente;
    [SerializeField] Transform scegliDifficolta;
    [SerializeField] List<int> widthScreen = new List<int>();
    [SerializeField] List<int> heightScreen = new List<int>();

    private void Start()
    {
        menu.value = Save.GetMenuVolume();
        game.value = Save.GetGameVolume();
        effects.value = Save.GetEffectsVolume();
        if (menu.value <= 0.001f)
        {
            mixer.SetFloat("MenuVolume", -80);
        }
        else
        {
            mixer.SetFloat("MenuVolume", Save.GetMixerMenu());
        }
        if (game.value <= 0.001f)
        {
            mixer.SetFloat("GameVolume", -80);
        }
        else
        {
            mixer.SetFloat("GameVolume", Save.GetMixerGame());
        }
        if (effects.value <= 0.001f)
        {
            mixer.SetFloat("EffectsVolume", -80);
        }
        else
        {
            mixer.SetFloat("EffectsVolume", Save.GetMixerEffects());
        }
        Screen.SetResolution(Screen.width, Screen.height, Screen.fullScreen);
    }

    public void SetResolution(int resolutionIndex)
    {
        int height = heightScreen[resolutionIndex];
        int width = widthScreen[resolutionIndex];
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void PlayNewGame()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        Save.LoadData();
    }

    public void LoadGame()
    {
        if (Save.GetSaved() == 1)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(2);
        }
        else
        {
            loadGame.GetComponent<CanvasGroup>().alpha = 1f;
            loadGame.GetComponent<CanvasGroup>().blocksRaycasts = true;
            loadGame.GetComponent<CanvasGroup>().interactable = true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SaveOptions()
    {
        Save.SaveMenuVolume(menu.value);
        Save.SaveEffectsVolume(effects.value);
        Save.SaveGameVolume(game.value);
        Debug.Log("Opzioni salvate");
    }

    public void SetLevelMenu(float sliderValue)
    {
        mixer.SetFloat("MenuVolume", Mathf.Log10(sliderValue) * 20);
        Save.SaveMixerMenu(Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelGame(float sliderValue)
    {
        mixer.SetFloat("GameVolume", Mathf.Log10(sliderValue) * 20);
        Save.SaveMixerGame(Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelEffect(float sliderValue)
    {
        mixer.SetFloat("EffectsVolume", Mathf.Log10(sliderValue) * 20);
        Save.SaveMixerEffects(Mathf.Log10(sliderValue) * 20);
    }

    public void ExitCredits()
    {
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
        credits.GetComponent<CanvasGroup>().interactable = false;
        container.GetComponent<CanvasGroup>().alpha = 1;
        container.GetComponent<CanvasGroup>().blocksRaycasts = true;
        container.GetComponent<CanvasGroup>().interactable = true;
        titolo.enabled = true;
    }

    public void SetDifficoltaPc(int difficolta)
    {
        Save.SaveDifficoltaPc(difficolta);
    }

    public void AskNewGame()
    {
        if (Save.GetSaved() == 1)
        {
            salvataggioEsistente.GetComponent<CanvasGroup>().alpha = 1;
            salvataggioEsistente.GetComponent<CanvasGroup>().blocksRaycasts = true;
            salvataggioEsistente.GetComponent<CanvasGroup>().interactable = true;
        }
        else
        {
            scegliDifficolta.GetComponent<CanvasGroup>().alpha = 1;
            scegliDifficolta.GetComponent<CanvasGroup>().blocksRaycasts = true;
            scegliDifficolta.GetComponent<CanvasGroup>().interactable = true;
            container.GetComponent<CanvasGroup>().alpha = 0;
            container.GetComponent<CanvasGroup>().blocksRaycasts = false;
            container.GetComponent<CanvasGroup>().interactable = false;
        }
    }

    public void ResetSaveData()
    {
        Save.Reset();
    }
}
