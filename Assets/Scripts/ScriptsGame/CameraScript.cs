using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        if (cameraTransform == null)
            cameraTransform = GetComponent<Transform>();
        originalPosition = transform.position;
    }
    public void Shake()
    {
        InvokeRepeating("StartShaking", 0f, 0.01f);
        Invoke("StopShaking", shakeDuration);
    }

    private void StartShaking()
    {
        float xOffset = Random.Range(-1f, 1f) * shakeMagnitude;
        float yOffest = Random.Range(-1f, 1f) * shakeMagnitude;

        Vector3 pos = originalPosition + new Vector3(xOffset, yOffest, 0f);
        cameraTransform.localPosition = pos;
    }

    private void StopShaking()
    {
        CancelInvoke("StartShaking");
        cameraTransform.localPosition = originalPosition;
    }
}
