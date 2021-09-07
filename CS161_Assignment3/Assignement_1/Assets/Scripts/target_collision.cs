using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_collision : MonoBehaviour
{
    //variables 

    //amount of hits before target destroys
    public int targetHP = 1;

    private bool tookDMG = false;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    // Will check if the target HP is less than or equal to 0 and if so the target destroys itself
    // Also makes the bool tookDMG back to false
    void Update()
    {
        if (targetHP <= 0)
            Destroy(this.gameObject);
        
        tookDMG = false;
    }

    //On collision with an object tagged as "player_bullet" and when tookDMG is false, the targetHP will be 
    // reduced by 1 and tookDMG will be set to true. This is to ensure that HP is only reduced one time for each 
    // player bullet that collides with the target 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player_bullet" && !tookDMG ) 
        {
            tookDMG = true;
            targetHP--;
        }

    }
}
