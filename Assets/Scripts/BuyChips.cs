using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyChips : MonoBehaviour
{
    public Button sumChipsButton;
    public Button restChipsButton;
    public Button buyChipsButton;
    public TextMeshProUGUI buyChipsButtonText;
    public TextMeshProUGUI numberChipsText;

    public TextMeshProUGUI totalNumberOfChips;

    float numberOfChips = 0;
    float buyChipsTotal = 0;   

    float chipsValue = 1;   //Valor de les fitxes en punts

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
        buyChipsTotal = numberOfChips * chipsValue;
        buyChipsButtonText.text = buyChipsTotal.ToString();       
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

    public void BuyChipsButton()
    {
        if(diceScript.GetPointsNumber() >= buyChipsTotal)
        {
            diceScript.RestPointsNumber(buyChipsTotal);
            casino.playerChips += numberOfChips;
            casino.ChipsText.text = casino.playerChips.ToString();
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
    }        
}
