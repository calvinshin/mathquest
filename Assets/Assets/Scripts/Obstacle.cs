using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Initialize variables, most which will be modified by another script.
    public Vector3 moveDir;
    public float moveSpeed;
    public float aliveTime = 4.0f;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void OnEnable ()
    {
        CancelInvoke("Deactivate");
        // invokes deactivate in 4.0f (which is the aliveTime)
        // If you have the same object over and over, this is helpful.
        // We need to invoke this whenever it's enabled, not just when it starts. 
        Invoke("Deactivate", aliveTime);  
    }

    // Update is called once per frame
    void Update()
    {
        // move obstacle in the direction over time; this does constant movement over time
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        transform.Rotate(Vector3.back * moveDir.x * rotateSpeed * Time.deltaTime);
    }


    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
