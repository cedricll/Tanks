using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting_script : MonoBehaviour
{
    //variables 

    //An game object that denotes where the bullets should spawn from
    public GameObject bulletSpawner;

    //prefab 
    public GameObject bullet;

    //controls how fast the velocity of the bullet
    public float forwardForce;

    //Determines if the player is player 1
    public bool isPLayer1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //for player 1 shooting
        if (isPLayer1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                createBullet();
            }
        }
        //for player 2 movement
        else
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                createBullet();
            }
        }
        
    }

    //Instantiates bullet at the bulletSpawner postion and rotation, and gives a velocity to the bullet
    //the bullet will destroy itself at the end after 4 seconds 
    void createBullet()
    {
        GameObject tempBulletHandler;
        tempBulletHandler = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;
        
        Physics.IgnoreCollision(tempBulletHandler.GetComponent<Collider>(), GetComponent<Collider>(), true);
       
        Rigidbody tempRigidBody;
        tempRigidBody = tempBulletHandler.GetComponent<Rigidbody>();

        tempRigidBody.velocity = (transform.forward * forwardForce);

        Destroy(tempBulletHandler, 4.0f);
    }
}
