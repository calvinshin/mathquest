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
        Stunned = 3
    }

//    current state
    public PlayerState curState;

//    horizontal speed
    public float moveSpeed;

//    flying speed
    public float flyingForce;

//    how long Stun state is
    public float stunDuration;
    public float stunStartTime;

//   is grounded?
    private bool grounded;

//    components
    public Rigidbody2D rig;
    public Animator anim;
    public ParticleSystem jetpackParticle;

//    calls regardless of frames per second; works for things like velocity/gravity/forces
    void FixedUpdate ()
    {
//        Checking if grounded
        grounded = isGrounded();
        
//        Listening for inptus
        CheckInputs();
        
//        condition if the character is stunned to disable inputs
//        REVIEWLATER: can this be set as a single if statement?
        if(curState == PlayerState.Stunned) {
            if(Time.time - stunStartTime >= stunDuration)
            {
                curState = PlayerState.Idle;
            }
        }
    }

//    checks for user input
    void CheckInputs ()
    {
//        When not stunned, these things can happen from the inputs
        
        if(curState != PlayerState.Stunned)
        {
//            Move will check horiztonal movement
            Move();
            
            if(Input.GetKey(KeyCode.UpArrow)) {
                Fly();
            }
            else {
//                Stops the particle effect when KeyCode.UpArrow is not pressed
                jetpackParticle.Stop();
            }
        }
        
//        Then, update the state
        SetState();
    }

//    setting state
    void SetState ()
    {
//        Check if a certain state should be active or not
        
//        Don't do anything if the player is stunned
        if(curState != PlayerState.Stunned)
        {
//            idle
            if(rig.velocity.magnitude == 0 && grounded)
            {
                curState = PlayerState.Idle;
            }
            
            if(rig.velcity.x != 0 && grounded)
            {
                curState = PlayerState.Walking;
            }
            
            if(rig.velocity.magnitude != 0 && !grounded)
            {
                curState = PlayerState.Flying;
            }
        }
        
//        Tell the animator that states have been changed
//        In C#, can convert enum to int through this.
//        In Java, can get value from Enum.ordinal();
        anim.SetInteger("State", (int)curState);
    }

//    move horizontally
    void Move ()
    {
//        Get horizontal input, a value of -1 to 1 either through A/D or Left/Right
        float dir = Input.GetAxis("Horizontal");
        
//        Want to flip the character when moving to the left
        if(dir > 0)
        {
            transform.localScale = newVector3(1, 1, 1);
        }
        else if(dir < 0)
        {
            transform.localScale = newVector3(-1, 1, 1);
        }
        
//        set the rigidbody velocity
        rig.velocity = new Vector2(dir * moveSpeed, rig.velocity.y);
        
    }

//    force upwards
    void Fly ()
    {
//        add force upwards
        rig.AddForce(Vector2.up * flyingForce, ForceMode2D.Impulse);
//        ForceMode2D has Impulse and Force
//          Force = Smooth, from slow to fast
//          Impulse = Sudden shift/change
        
//        Enable jetpack particle
        if(!jetpackParticle.isPlaying)
        {
            jetpackParticle.Play();
        }
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
