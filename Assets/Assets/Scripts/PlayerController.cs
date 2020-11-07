using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerState
    {
        Idle = 0,
        Walking = 1,
        Flying = 2,
        Stunmed = 3
    }

//    current state
    public PlayerState curState

//    horizontal speed
    public float moveSpeed;

//    flying speed
    public float flyingForce

//    how long Stun state is
    public float stunDuration;
    private float stunStartTime;

//   is grounded?
    private bool grounded;

//    components
    public Rigidbody2D rig;
    public Animator anim;
    public ParticleSystem jetpackParticle;

//    calls regardless of frames per second; works for things like velocity/gravity/forces
    void FixedUpdate ()
    {

    }

//    checks for user input
    void CheckInputs ()
    {

    }

//    setting state
    void SetState ()
    {

    }

//    move horizontally
    void Move ()
    {

    }

//    force upwards
    void Fly ()
    {

    }

//    stuns the player
    public void Stun ()
    {

    }

//    returns if the character is grounded or not
    bool IsGrounded ()
    {
        return true;
    }

//    sends the 2D collider of the object that is collided with
//    if it's an obstacle, it will trigger a stun
    private void OnTriggerEnter2D (Collider2D collision)
    {

    }
}
