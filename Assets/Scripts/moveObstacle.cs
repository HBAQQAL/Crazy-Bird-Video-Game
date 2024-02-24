using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObstacle : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool gameEnds = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello wrold");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnds)
        {
            return;
        }
        gameObject.GetComponent<Transform>().position += Vector3.left * moveSpeed * Time.deltaTime;

    }
    // destroy the obstacle when it is out of the screen
    private void OnBecameInvisible()
    {
        Debug.Log("destroyed");
        Destroy(gameObject);
    }
}
