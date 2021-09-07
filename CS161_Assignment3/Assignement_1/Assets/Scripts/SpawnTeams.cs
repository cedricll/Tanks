using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeams : MonoBehaviour
{

    public GameObject team1;
    public GameObject team2;
    public GameObject team3;

    public int teamSize = 3;

    public float timeRemaining = 30; // seconds

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < teamSize; i++)
        {
            var position1 = new Vector3(Random.Range(5, 85), 0, Random.Range(-5, -85));
            Instantiate(team1, position1, Quaternion.identity);

            var position2 = new Vector3(Random.Range(-5, -85), 0, Random.Range(-5, -85));
            Instantiate(team2, position2, Quaternion.identity);

            var position3 = new Vector3(Random.Range(-45, 45), 0, Random.Range(10, 85));
            Instantiate(team3, position3, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            Debug.Log("Time Remaining: " + timeRemaining);
            timeRemaining -= Time.deltaTime;
        }

        else
        {
            // Debug.Log("Time has run out!");
            Time.timeScale = 0;
        }
    }
}
