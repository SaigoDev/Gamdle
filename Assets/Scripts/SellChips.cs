using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SellChips : MonoBehaviour
{
    public Button sumChipsButton;
    public Button restChipsButton;
    public Button sellChipsButton;
    public TextMeshProUGUI sellChipsButtonText;
    public TextMeshProUGUI numberChipsText;

    public TextMeshProUGUI totalNumberOfChips;

    float numberOfChips = 0;
    float sellChipsTotal = 0;    

    float chipsValue = 1; //Valor de les fitxes en punts

    public DiceScript diceScript;

    public UIController casino;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        numberChipsText.text = numberOfChips.ToString();
        sellChipsTotal = numberOfChips * chipsValue;
        sellChipsButtonText.text = sellChipsTotal.ToString();        
    }

    public void MoreChips()
    {
        numberOfChips++;
    }

    public void LessChips()
    {
        if (numberOfChips >= 1)
        {
            numberOfChips--;
        }
        else
        {
            Debug.Log("Nice try");
        }
    }

    public void SellChipsButton()
    {
        if(float.Parse(casino.ChipsText.text) >= numberOfChips)
        {
            diceScript.SumPointsNumber(sellChipsTotal);
            casino.playerChips -= numberOfChips;
            casino.ChipsText.text = casino.playerChips.ToString();
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
    }
}
