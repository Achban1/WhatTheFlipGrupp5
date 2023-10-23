using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    private void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int nextScene = Random.Range(0, 2);
            SceneManager.LoadScene(nextScene);
        }
    }
}
