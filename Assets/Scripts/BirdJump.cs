using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BirdJump : MonoBehaviour
{
    public Transform Transform;
    public Rigidbody2D Rigidbody2D;
    public float jumpForce = 5f;
    // animator component
    public Animator animator;
    int score = 0;
    public GameObject obstacle;
    public moveObstacle mv;
    public new audioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        // change the rigid body mode from static to dynamic
        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

    }

    // Update is called once per frame
    void Update()
    {

        // if the space key is pressed add up velocity to the bird
        if (Input.GetKey(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            jump();

        }
        else
        {
            if (Rigidbody2D.velocity.y > 0)
            {
                // play the jump animation
                animator.SetBool("jumping", true);
            }
            else
            {
                // play the jump animation
                animator.SetBool("jumping", false);
            }
        }

    }

    public void jump()
    {
        audio.Play("jump");

        // Set the velocity to Vector2.up * jumpForce
        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpForce);

        // Disable any existing upward force by applying gravity immediately
        Rigidbody2D.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);

        // Play the jump animation
        animator.SetBool("jumping", true);
    }

    // check if the bird collides with the ground or the pipes
    private void OnCollisionEnter2D(Collision2D collision)
    {

        // if the bird collides with the ground or the pipes
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Pipe")
        {
            Debug.Log("game over !");
            // fix the bird's position
            Rigidbody2D.bodyType = RigidbodyType2D.Static;

            audio.Stop("gameMusic");
            audio.Play("death");
            backgroundMouvement.Stop();
            // find all game objects with the tag "obstacle" and set their gameEnds variable to true
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("obstacle");
            foreach (GameObject obstacle in obstacles)
            {
                obstacle.GetComponent<moveObstacle>().gameEnds = true;
            }

            // set the gameEnds variable to true
            obstacle.GetComponent<spawnObstacles>().gameEnds = true;

            int highScore = PlayerPrefs.GetInt("score");
            if (score > highScore)
            {
                GameObject.Find("scoreManager").GetComponent<ScoreManager>().changeHS(score);
            }

            StartCoroutine(ReloadSceneAfterDelay(3f));

        }
        if (collision.gameObject.tag == "line")
        {
            Debug.Log("score !");
            // increase the score by 1 every 1 second 
            score++;
            GameObject.Find("scoreManager").GetComponent<ScoreManager>().changeScore(score);

        }
    }

    private IEnumerator ReloadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // exit the game when the exit button is pressed
    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

}
