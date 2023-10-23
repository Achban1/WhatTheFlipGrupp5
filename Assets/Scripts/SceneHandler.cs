using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Vector2 targetPosition = new Vector2(0,-100);
    public bool changingScene = false;

    private void Start()
    {
        targetPosition = transform.position; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            changingScene = true;
            Invoke(nameof(ChangeSceneFalse), 2f);
        }
        if (changingScene)
        {
            targetPosition += new Vector2(0, -100) * moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    } 
    private void ChangeSceneFalse()
    {
        int nextScene = Random.Range(0, 2);
        SceneManager.LoadScene(nextScene);
        changingScene = false;
    }
}
