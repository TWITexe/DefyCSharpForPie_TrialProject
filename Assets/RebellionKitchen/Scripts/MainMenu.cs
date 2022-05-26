using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolube = 1f;

    [SerializeField] GameObject settings;
    [SerializeField] GameObject mainMenuButton;


    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSrc.volume = musicVolube;
    }
    public void SetVolume(float vol)
    {
        musicVolube = vol;
    }
    public void StartGame()
    {
        FadeInOut.sceneEnd = true;
    }

    public void InSettings()
    {
        settings.SetActive(true);
        mainMenuButton.SetActive(false);
    }
    public void InMenu()
    {
        settings.SetActive(false);
        mainMenuButton.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
