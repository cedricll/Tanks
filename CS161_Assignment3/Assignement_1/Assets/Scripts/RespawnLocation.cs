using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLocation : MonoBehaviour
{
    //Determines if the respwn area is occupied list
    [SerializeField]
    private List<GameObject> myObjects;

    //Makes sure that the player that respawns won't respawn in here
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            myObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            myObjects.Remove(other.gameObject);
        }
    }

    //simply removes the player fromt he list if possible
    public void CheckAndRemovePlayer(GameObject gameObject)
    {
        myObjects.Remove(gameObject);
    }

    //Basic getter for the isOccupied bool
    public bool LocationOccupied()
    {
        return myObjects.Count > 0;
    }

    //checks if yhr player exists int he list or respawn area
    public bool CurrentPLayerExists(GameObject gameObject)
    {
        return myObjects.Contains(gameObject);
    }

}
