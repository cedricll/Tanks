using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Script : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    public string enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(enemy).transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, player.position.y, 0);
        }

        else if (Vector3.Distance(transform.position, player.position) > stoppingDistance && Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = this.transform.position;
        }

        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Hit");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}

/*if (Input.GetKey(up))
    myTransfrom.eulerAngles = new Vector3(0, 0, 0);
else if (Input.GetKey(down))
    myTransfrom.eulerAngles = new Vector3(0, 180, 0);
else if (Input.GetKey(left))
    myTransfrom.eulerAngles = new Vector3(0, -90, 0);
else if (Input.GetKey(right))
    myTransfrom.eulerAngles = new Vector3(0, 90, 0);*/