using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Manager : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public float delayTime;

    [SerializeField]
    private RespawnLocation[] myRespawns;

    private bool foundLocation;


    //get three private variable values
    private void Start()
    {
        myRespawns = GameObject.FindObjectsOfType<RespawnLocation>();
    }

    //Is used to start the coroutine function
    public void StartDelay(bool player1)
    {
        StartCoroutine(Respawn(player1));
    }

    //checks all respawn points and if the player being destroyed exists then  we remove it formt he respawn point list.
    //this is so that no players will respawn on toop of each other
    public void CheckAllRespawns(GameObject gameObject)
    {
        foreach(RespawnLocation respawnLocation in myRespawns)
        {
            if (respawnLocation.LocationOccupied())
            {
                respawnLocation.CheckAndRemovePlayer(gameObject);
            }
            
        }
    }
    

    //Finds a random location from the list and places the plater there, while also re-enabling the movement and shooting scripts.After the delay Time.
    private IEnumerator Respawn(bool player1)
    {
        yield return new WaitForSeconds(delayTime);
        while (!foundLocation)
        {
            int randNumber = Random.Range(0, myRespawns.Length - 1);
            if (!myRespawns[randNumber].LocationOccupied())
            {
                if (player1)
                {
                    Instantiate(player2Prefab, myRespawns[randNumber].transform.position, myRespawns[randNumber].transform.rotation);
                }
                else
                {
                    Instantiate(player1Prefab, myRespawns[randNumber].transform.position, myRespawns[randNumber].transform.rotation);
                }
                
                foundLocation = true;
            }
        }
        foundLocation = false;
    }
}
