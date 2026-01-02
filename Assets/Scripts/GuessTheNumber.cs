using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;  

    [SerializeField]
    Button playButton;

    [SerializeField]
    TextMeshProUGUI randomNumberText;
        
    float randomNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomNumberText.text = randomNumber.ToString();
    }

    public void ButtonPressed()
    {
        string text = inputField.text;

        if (string.IsNullOrWhiteSpace(text))
        {
            Debug.Log("Write Something");
        }
        else if (!float.TryParse(text, out float number))
        {
            Debug.Log("Write a valid number");
        }
        else if (number >= 6)
        {
            Debug.Log("Write a lower number than 7");
        }
        else if (number <= 0)
        {
            Debug.Log("Write a positive number");
        }
        else
        {
            RollRandomNumber();

            if (number == randomNumber)
            {
                Debug.Log("You won");
            }
            else
            {
                Debug.Log("Number was " + randomNumber);
            }

            inputField.text = "";
        }
    }

    void RollRandomNumber()
    {
        randomNumber = Random.Range(1, 6);
    }
}
