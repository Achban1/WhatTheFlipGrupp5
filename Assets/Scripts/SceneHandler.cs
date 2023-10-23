using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public float moveSpeed = 3f;
    public static float lerpDuration = 0.2f;
    private Vector3 startPosition;
    private Vector3 centerPosition;
    private Vector3 endPosition;
    private float timer;
    private bool changingScene = false;
    private bool openingThisScene = true;

    private void Start()
    {
        timer = 0f;
        startPosition = new Vector3(0, 13, 0);
        centerPosition = new Vector3(0, 0, 0);
        endPosition = new Vector3(0, -13, 0);

        transform.position = startPosition;
    }

    private void Update()
    {
        SceneOpening();
        ChangeScene();
        if (Input.GetKeyDown(KeyCode.N))
        {
            changingScene = true;
            timer = 0f;
            Invoke(nameof(LoadNextScene), lerpDuration);
            //PlayerMovement.Instance.DisableAllMovement();
        }
        
    }
    private void SceneOpening()
    {
        if (openingThisScene)
        {
            transform.position = Vector3.Lerp(startPosition, centerPosition, timer / lerpDuration);
            timer += Time.deltaTime;
            if (transform.position == centerPosition)
            {
                openingThisScene = false;
            }
        }
    }
    private void ChangeScene()
    {
        if (changingScene)
        {
            transform.position = Vector3.Lerp(centerPosition, endPosition, timer / lerpDuration);
            timer += Time.deltaTime;
        }
    }
    private void LoadNextScene()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene;

        do
        {
            nextScene = Random.Range(1, sceneCount);
        } while (nextScene == currentSceneIndex);

        SceneManager.LoadScene(nextScene);
        changingScene = false;
    }
}
