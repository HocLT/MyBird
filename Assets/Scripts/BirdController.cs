using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float boundForce;

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    private bool isAlive;
    private bool didFlap;

    private GameObject spawner;

    public int flag = 0;
    public int score = 0;

    public static BirdController instance;

    void GetInstance() 
    { 
        if (instance == null)
            instance = this; 
    }

    // use for initialization
    private void Awake()
    {
        isAlive = true;
        myBody= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        GetInstance();
        spawner = GameObject.Find("Spawner Pipe");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _BirdMovement();
    }

    void _BirdMovement() 
    { 
        if (isAlive)
        {
            if (didFlap)
            {
                didFlap= false;
                myBody.velocity = new Vector2(myBody.velocity.x, boundForce);
                audioSource.PlayOneShot(flyClip);
            }
        }

        //// left mouse click: 0, right mouse click: 1
        //if (Input.GetMouseButtonDown(0))
        //{
        //    myBody.velocity = new Vector2(myBody.velocity.x, boundForce);
        //    audioSource.PlayOneShot(flyClip);
        //}

        if (myBody.velocity.y > 0) 
        {
            float angle = 0;
            angle = Mathf.Lerp(0, 90, myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        } 
        else if (myBody.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } 
        else if (myBody.velocity.y < 0)
        {
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -myBody.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void FlapButton()
    {
        didFlap = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PipeHolder")
        {
            score++;
            if (GamePlayController.Instance != null)
            {
                GamePlayController.Instance.SetScore(score); 
            }
            audioSource.PlayOneShot(pingClip);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Ground")
        {
            flag = 1;
            if (isAlive)
            {
                isAlive = false;
                Destroy(spawner);
                audioSource.PlayOneShot(diedClip);
                anim.SetTrigger("Died");
            }
            if (GamePlayController.Instance != null)
            {
                GamePlayController.Instance.BirdDiedShowPanel();
            }
        }
    }
}
