using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTube : MonoBehaviour
{
    public int tubeId;
    // will correlate to the index of the problems

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // tell the game that the player has entered the tube
            GameManager.instance.OnPlayerEnterTube(tubeId);
        }
    }
}
