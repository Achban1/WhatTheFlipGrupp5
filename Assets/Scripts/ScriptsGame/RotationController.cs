using System.Collections;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private Quaternion targetRotation;
    private Coroutine flipRoutine;

    void Start()
    {
        targetRotation = transform.rotation;
        flipRoutine = StartCoroutine(RandomFlip());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartFlip();
            PlayerMovement.Instance.DisableAllMovement();
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void StartFlip()
    {
        targetRotation *= Quaternion.Euler(0, 0, 180);
    }

    private IEnumerator RandomFlip()
    {
        while (true)
        {
            float randomTime = Random.Range(5f, 20f);
            yield return new WaitForSeconds(randomTime);

            StartFlip();
        }
    }
}
