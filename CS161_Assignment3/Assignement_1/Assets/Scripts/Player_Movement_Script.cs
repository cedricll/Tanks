using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Script : MonoBehaviour
{
    //Key Codes for direction facing and PLAYER 1
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;

    //Key Codes for direction facing and PLAYER 2
    public KeyCode p2UP;
    public KeyCode p2DOWN;
    public KeyCode p2LEFT;
    public KeyCode p2RIGHT;

    //Determines is its player 1 or not
    public bool isPlayer1;

    //Movespeed for object
    public float speed = 10;


    //Game componet vars for clarity 
    Transform myTransfrom;
    Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myTransfrom = gameObject.GetComponent<Transform>();
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
        rotateDirection();
    }

    private void FixedUpdate()
    {
          moveObject();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
        }
    }

    //Stops tank from gaining a backwards velocity when running into the target 
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
            myRigidbody.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionStay(Collision collision)
    {   
        //To ensure that the player is not building up velocity while running into an object
        reset_velocity();
    }


    //Controls the direction of the tank, rotates by a editing it's rotation 
    //boolean isPlayer1 determines which controls are used
    void rotateDirection()
    {
        if (isPlayer1)
        {
            if (Input.GetKey(up))
                myTransfrom.eulerAngles = new Vector3(0, 0, 0);
            else if (Input.GetKey(down))
                myTransfrom.eulerAngles = new Vector3(0, 180, 0);
            else if (Input.GetKey(left))
                myTransfrom.eulerAngles = new Vector3(0, -90, 0);
            else if (Input.GetKey(right))
                myTransfrom.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            if (Input.GetKey(p2UP))
                myTransfrom.eulerAngles = new Vector3(0, 0, 0);
            else if (Input.GetKey(p2DOWN))
                myTransfrom.eulerAngles = new Vector3(0, 180, 0);
            else if (Input.GetKey(p2LEFT))
                myTransfrom.eulerAngles = new Vector3(0, -90, 0);
            else if (Input.GetKey(p2RIGHT))
                myTransfrom.eulerAngles = new Vector3(0, 90, 0);
        }
        
    }

    //Allows for movement of the tank
    //boolean isPlayer1 determines which controls are used
    void moveObject ()
    {
        if (isPlayer1)
        {
            if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
                myTransfrom.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey(p2UP) || Input.GetKey(p2DOWN) || Input.GetKey(p2LEFT) || Input.GetKey(p2RIGHT))
                myTransfrom.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        
    }

    void reset_velocity()
    {
        myRigidbody.velocity = new Vector3(0, 0, 0);
    }
}
