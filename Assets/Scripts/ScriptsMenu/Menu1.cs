using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Menu1 : MonoBehaviour
{
    //esc menu
    PauseMenuEnabler enabler;

    private void Start()
    {
        enabler = GetComponent<PauseMenuEnabler>();
    }
 
    // Exits the game
    public void Exit()
	{
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Starts the game
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    // Loads the Menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Resume()
    {
        enabler.Resume();
    }
}
