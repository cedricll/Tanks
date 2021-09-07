using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bulletSpawn;
    public GameObject enemyTriggered;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.Find("Tank");
        this.transform.rotation = bulletSpawn.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            enemyTriggered = other.gameObject;
            Destroy(enemyTriggered);
            Destroy(this.gameObject);
        }

        else if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
