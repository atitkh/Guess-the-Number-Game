using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logic : MonoBehaviour
{
    public InputField userInput;
    public Text gameLabel;
    public Button guessButton;
    private bool isGameWon = false;
    private int randomNum;
    public int minValue = 1;
    public int maxValue = 101;
    
    // Start is called before the first frame update
    void Start()
    {
        gameLabel.text = "Guess a number between " + minValue + " and " + (maxValue - 1);
        randomNum = GetRandomNumber(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        if (isGameWon)
        {
            isGameWon = false;
            gameLabel.text = "You Won! Guess a number between " + minValue + " and " + (maxValue - 1);
            randomNum = GetRandomNumber(minValue, maxValue);
            userInput.text = "";
        }
        else
        {
            gameLabel.text = "Guess a number between " + minValue + " and " + (maxValue - 1);
            randomNum = GetRandomNumber(minValue, maxValue);
            userInput.text = "";
        }
        
        
    }

    public void OnButtonClick()
    {
        string userInputValue = userInput.text;
        if (userInputValue != "")
        {
            int answer = int.Parse(userInputValue);

            if (answer == randomNum)
            {
                gameLabel.text = "Correct!";
                //guessButton.interactable = false
                isGameWon = true;
                ResetGame();
                Debug.Log("Correct!");
            }
            else if (answer > randomNum)
            {
                gameLabel.text = "Try Lower!";
                Debug.Log("Try Lower");
            }
            else
            {
                gameLabel.text = "Try Higher!";
                Debug.Log("Try Higher");
            }

            Debug.Log("Input is " + userInput.text);
            Debug.Log("Random number is " + randomNum);
        }
        else
        {
            gameLabel.text = "Please input a number!";
            Debug.Log("Input a number");
        }
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        return random;
    }
}
