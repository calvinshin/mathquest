using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // List of all the problems
    public Problem[] problems;

    // current problem
    public int curProblem;

    // time limit for problem
    public float timePerProblem;

    // time remaining
    public float remainingTime;

    // Need the controller to stun the player!
    public PlayerController player;

    // Instance
    // Allows you to call GameManager.instance
    // overrides every instance of the script
    public static GameManager instance;

    void Awake ()
    {
        // set instance
        instance = this;
    }

    void Start ()
    {
        // set the first problem
        SetProblem(0);
    }

    void Update ()
    {
        remainingTime -= Time.deltaTime;

        // Has remainingTime run out?
        if(remainingTime <= 0)
        {
            Lose();
        }
    }

// Other functions
    void SetProblem (int problemNumber)
    {
        curProblem = problemNumber;

        // Set the UI text !!!!!!!!
        // Does this by sending the current problem. 
        UI.instance.SetProblemText(problems[curProblem]);

        remainingTime = timePerProblem;
    }

    // When winning, call this function
    void Win ()
    {
        Time.timeScale = 0.0f;

        // SET THE UI SCREEN !!!!!!
        UI.instance.SendEndText(true);
    }

    // When losing, call this function
    void Lose ()
    {
        Time.timeScale = 0.0f;

        // then set the lose screen !!!!!!
        UI.instance.SendEndText(false);
    }

    // When a tube is entered
    public void OnPlayerEnterTube (int tube)
    {
        if(tube == problems[curProblem].correctTube)
        {
            CorrectAnswer();
        }
        else
        {
            IncorrectAnswer();
        }
    }

    void CorrectAnswer()
    {
        if(problems.Length - 1 == curProblem)
        {
            Win();
        }
        else
        {
            SetProblem(curProblem + 1);
        }
    }

    void IncorrectAnswer()
    {
        player.Stun();
    }
}
