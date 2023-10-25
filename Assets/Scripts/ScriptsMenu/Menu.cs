using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //start menu
    public float musicSlider;
    public float fxSlider;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 2);
    }

    public void ControlsButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void MusicSlider(float volume)
    {
        musicSlider = volume*100f;
        PlayerPrefs.SetFloat("musicvolume", musicSlider);
    }
    public void FxSlider(float volume)
    {
        fxSlider = volume * 100f;
        PlayerPrefs.SetFloat("fxvolume", fxSlider);
    }
     
}
