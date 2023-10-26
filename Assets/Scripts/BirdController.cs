using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField]
    float boundForce = 3f;

    Rigidbody2D myBody;
    Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BirdMovement();
    }

    void BirdMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myBody.velocity = new Vector2(myBody.velocity.x, boundForce);
        }
    }
}
