using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rb;
    public float jumpTime;
    private float jumpTimeCounter;
    public float playerSpeed;
    public float jumpForce;
    bool isJumping;
    Vector3 playerPos;
    float killTimer;
    float endTimer;

    [SerializeField] AudioSource wingFlap;
    [SerializeField] AudioSource AnvilStrike;

    // Start is called before the first frame update
    void Start()
    {
        killTimer = 1.2f;
        isJumping = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;

        Vector2 velocity = rb.velocity;
        velocity.x = Input.GetAxis("Horizontal") * playerSpeed * (Time.deltaTime + 1);
        rb.velocity = velocity;

        if(Input.GetAxis("Horizontal") < -0.2f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            StartGame();
        }
        if(Input.GetAxis("Horizontal") > 0.2f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            StartGame();
        }

        if(Input.GetKeyDown("space") || Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
            jumpTimeCounter = jumpTime;

            velocity.y = 1 * jumpForce;
            rb.velocity = velocity;

            StartGame();

            //jump sound
            wingFlap.Play();
        }
        if(Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w") && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                velocity.y = 1 * jumpForce;
                rb.velocity = velocity;

                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp("space") || Input.GetKeyUp("up") || Input.GetKeyUp("w"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }

        if(playerPos.x >= 7.4f || playerPos.x <= -7.4f || playerPos.y >= 4.5f || playerPos.y <= -4.5f) {
            if(GameObject.Find("OOB").GetComponent<SpriteRenderer>().enabled == false) {
                GameObject.Find("OOB").GetComponent<SpriteRenderer>().enabled = true;
            }

            killTimer -= Time.deltaTime;
            if(killTimer <= 0) {
                //end game
                GameObject timer = GameObject.Find("Timer");
                timer.GetComponent<Timer>().enabled = false;
                GameObject.Find("Player").SetActive(false);
                GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
                GameObject.Find("Score").GetComponent<Text>().enabled = true;
                GameObject.Find("Highscore").GetComponent<Text>().enabled = true;
                GameObject.Find("Restart").GetComponent<Image>().enabled = true;
                GameObject.Find("Restart").GetComponent<SceneSwitchBtn>().enabled = true;
                GameObject.Find("Restart").GetComponent<BoxCollider2D>().enabled = true;
                GameObject.Find("Restart").transform.GetChild(0).GetComponent<Text>().enabled = true;

                //score
                GameObject.Find("Score").GetComponent<Text>().text = "Score:          " + (Mathf.Round(timer.GetComponent<Timer>().GetTime() * 100) / 100);
                CheckHighscore(timer.GetComponent<Timer>().GetTime());
                GameObject.Find("Highscore").GetComponent<Text>().text = "Highscore:   " + PlayerPrefs.GetFloat("Highscore");
            }
        } else {
            if(killTimer != 1.2f)
            {
                killTimer = 1.2f;
            }
            if(GameObject.Find("OOB").GetComponent<SpriteRenderer>().enabled == true) {
                GameObject.Find("OOB").GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    void StartGame()
    {
        if(rb.gravityScale == 0) {
            rb.gravityScale = 5;
            GameObject.Find("Spawner").GetComponent<Spawner>().enabled = true;
            GameObject.Find("Timer").GetComponent<Timer>().enabled = true;
        }
    }

    void CheckHighscore(float time)
    {
        if(time > PlayerPrefs.GetFloat("Highscore", 0)) {
            PlayerPrefs.SetFloat("Highscore", Mathf.Round(time * 100) / 100);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Anvil")) {
            AnvilStrike.Play();
        }
    }
}
