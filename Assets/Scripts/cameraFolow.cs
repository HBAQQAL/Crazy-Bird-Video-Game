using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cameraFolow : MonoBehaviour
{
    public GameObject bird;
    public Camera mainCamera;
    void Update()
    {
        mainCamera.transform.position = new Vector3(bird.transform.position.x + 9.82f, mainCamera.transform.position.y, -16.62f);
    }
}
