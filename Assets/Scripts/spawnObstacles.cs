using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject cloud;
    public float spawnTime = 3f;
    public Camera mainCamera;
    public float minX, maxX, minY, maxY;
    public bool gameEnds = false;
    public float[] spawnY;

    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMax();
        StartCoroutine(Spawn());
        StartCoroutine(SpawnCloudT());
    }



    private IEnumerator Spawn()
    {
        while (!gameEnds)
        {
            // get a random number betwen 0 and 2
            int a = Random.Range(0, 3);
            // set the y position of the obstacle to the  randomly selected value 
            obstacle.GetComponent<Transform>().position = new Vector3(30.29f, spawnY[a], 0);
            SpawnObstacle(a);
            yield return new WaitForSeconds(spawnTime);

        }
    }
    private IEnumerator SpawnCloudT()
    {
        while (!gameEnds)
        {

            SpawnCloud();


            yield return new WaitForSeconds(7);

        }
    }



    public void SpawnObstacle(int a)
    {

        // instantiate the obstacle
        GameObject newObstacle = Instantiate(obstacle);
        Debug.Log("spawned");

    }
    public void SpawnCloud()
    {
        Vector3 randomPosition = new Vector3(minX + 5, Random.Range(minY, maxY), 2f);
        Vector3 random4 = new Vector3(minX + 5, randomPosition.y + 8, 2f);
        GameObject newCloud = Instantiate(cloud, randomPosition, Quaternion.identity);
        GameObject newCloud2 = Instantiate(cloud, random4, Quaternion.identity);
    }



      
        public void SetMinAndMax()
    {
        Vector2 Bounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        minX = -Bounds.x + 1;
        maxX = Bounds.x - 1;
        maxY = -Bounds.y + 1;
        minY = Bounds.y - 1;

    }
}
