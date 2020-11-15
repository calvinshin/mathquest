using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // array of all obstacles
    public GameObject[] objectPrefabs;
    // how many objects spanwed
    public int poolSize = 20;
    // List of all spanwed objects
    // (List lets you do any number of objects, rather than an array)
    private List<GameObject> pooledObjects = new List<GameObject>();

    void Start ()
    {
        // Create the pool's objects
        CreatePool();
    }


// Instantiates all pool objects
    void CreatePool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            // Looks at the prefabs array and loops through the objects
            // Remainder sets the amount in the array (0-3, for example)
            GameObject objectToSpawn = Instantiate(objectPrefabs[i % objectPrefabs.Length]);

            // set the object as inactive
            objectToSpawn.SetActive(false);

            // add this to the list
            pooledObjects.Add(objectToSpawn);       
        }
    }

    // returns a pooled object for use
    public GameObject GetPooledObject ()
    {
        // rather than iterate, we can use a list function to check for an active one
        // Goes through pooledObjects list and finds a (temporarily called x) object that is not activeInHierarchy
        GameObject objectToSend = pooledObjects.Find(x => !x.activeInHierarchy);

        // Is there no object to send? (as in Find failed to find one);
        if(!objectToSend)
        {
            Debug.LogError("No more objects in pool, need to icnrease the size");
        }
        else
        {
             objectToSend.SetActive(true);
        }
        
        return objectToSend;
    }
}
