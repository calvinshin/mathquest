using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Need to reference UI namespace
using UnityEngine.UI;
 
public class UI : MonoBehaviour
{
    public Text problemText;
    public Text[] answerText;

    public Image timeDial;
    private float timeDialRate;

    public Text endText;

    // instance
    public static UI instance;

    void Awake ()
    {
        instance = this;
    }

    void Start()
    {
        // This should convert the time per problem to less than 1
        timeDialRate = 1.0f / GameManager.instance.timePerProblem;
    }

    void Update ()
    {
        // Update the time dial;
        // will count down from 1 to 0 based on remainingTime.
        timeDial.fillAmount = timeDialRate * GameManager.instance.remainingTime;
    }

    // sets the UI to display
    public void SetProblemText (Problem problem)
    {
        string operatorText = "";

        // Use a switch statement to convert to a string
        switch(problem.operation)
        {
            case MathsOperation.Addition:
                operatorText = "+";
                break;

            case MathsOperation.Subtraction:
                operatorText = "-";
                break;

            case MathsOperation.Multiplication:
                operatorText = "*";
                break;

            case MathsOperation.Division:
                operatorText = "/";
                break;
        }

        // Set the complete problem text
        problemText.text = problem.firstNumber + " " + operatorText + " " + problem.secondNumber;

        // Set the answer texts to display
        for(int i = 0; i < answerText.Length; i++)
        {
            answerText[i].text = problem.answers[i].ToString();
        }
    }

    public void SendEndText (bool win)
    {
        endText.gameObject.SetActive(true);

        if(win)
        {
            endText.text = "YOU WIN!";
        }
        else
        {
            endText.text = "GAME OVER";
        }
    }
}
