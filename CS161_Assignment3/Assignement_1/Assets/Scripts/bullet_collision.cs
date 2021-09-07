using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_collision : MonoBehaviour
{
    public bool isPlayer1Bullet;
    [SerializeField]
    private Respawn_Manager myRespawnManager;
    // Start is called before the first frame update
    void Start()
    {
        myRespawnManager = GameObject.FindObjectOfType<Respawn_Manager>();
    }

   

    //When the bullet enters an object tagged as "Wall" or "Target" the bullet will destroy itself
    //When the bullet hits an Object tagged as "Player" the Respawn Manager will be used to respawn them with a delay
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Target" || collision.gameObject.tag == "player_bullet")
            Destroy(this.gameObject);
        else if (collision.gameObject.tag == "Player")
        {
            myRespawnManager.StartDelay(isPlayer1Bullet);
            myRespawnManager.CheckAllRespawns(collision.gameObject);
            Destroy(collision.gameObject); 
            Destroy(this.gameObject);
        }
            

    }

}
