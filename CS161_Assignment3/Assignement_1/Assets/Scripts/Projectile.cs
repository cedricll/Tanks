using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // public float speed;

    // private Transform player;
    // private Vector3 target;

    public string enemy;

    public string enemy2;

    /*[SerializeField]
    private Respawn_Manager myRespawnManager;

    public float delayTime;*/

    public GameObject tank;

    public GameObject tank2;

    // Start is called before the first frame update
    void Start()
    {
        /*player = GameObject.FindGameObjectWithTag(enemy).transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);*/

        // myRespawnManager = GameObject.FindObjectOfType<Respawn_Manager>();
    }

    /*public void StartDelay(GameObject gameobj)
    {
        StartCoroutine(Respawn(gameobj));
    }*/

    // Update is called once per frame
    void Update()
    {
       /* transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyProjectile();

        }*/
    }

   /* void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collision on wall");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            // myRespawnManager.StartDelay(isPlayer1Bullet);
            myRespawnManager.CheckAllRespawns(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }


    }
*/
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        if ( collider.CompareTag("Wall") || collider.CompareTag("Projectile"))
        {
            Debug.Log("Hitting wall");
            DestroyProjectile();
            
        }

        else if (collider.CompareTag(enemy))
        {
            Debug.Log("Hitting enemy" + enemy);
            /*myRespawnManager.StartDelay(true);
            myRespawnManager.CheckAllRespawns(collider.gameObject);*/
            Destroy(collider.gameObject);
            DestroyProjectile();

            // StartDelay(collider.gameObject);
            var position = new Vector3(Random.Range(-85, 85), 0, Random.Range(-85, 85));
            Instantiate(tank, position, Quaternion.identity);
            // Instantiate(collider.gameObject, myRespawns[randNumber].transform.position, myRespawns[randNumber].transform.rotation);

        }

        else if (collider.CompareTag(enemy2))
        {
            Debug.Log("Hitting enemy" + enemy2);
            /*myRespawnManager.StartDelay(true);
            myRespawnManager.CheckAllRespawns(collider.gameObject);*/
            Destroy(collider.gameObject);
            DestroyProjectile();

            // StartDelay(collider.gameObject);
            var position = new Vector3(Random.Range(-85, 85), 0, Random.Range(-85, 85));
            Instantiate(tank2, position, Quaternion.identity);
            // Instantiate(collider.gameObject, myRespawns[randNumber].transform.position, myRespawns[randNumber].transform.rotation);

        }
    }

    /*private IEnumerator Respawn(GameObject gameobj)
    {
        yield return new WaitForSeconds(2);
        var position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(gameobj, position, Quaternion.identity);
        // instantiate(player2Prefab, myRespawns[randNumber].transform.position, myRespawns[randNumber].transform.rotation);
               
            
    }*/
}
