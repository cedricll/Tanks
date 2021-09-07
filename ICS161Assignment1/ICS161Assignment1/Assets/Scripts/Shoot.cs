using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject m_Bullet;
    public GameObject m_BulletSpawn;

    private Transform _bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
            _bullet = Instantiate(m_Bullet.transform, m_BulletSpawn.transform.position, Quaternion.identity);
        }
    }
}
