using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealDiceScript : MonoBehaviour
{   
    [SerializeField]
    TextMeshProUGUI diceText;
    float diceNumber = 0;
    public DiceScript diceScript;
    public float multi = 1;
    public float diceNumberMulti;
    public float dayMulti = 1;

    public DiceThrow diceThrow;

    public DaySystem daySystem;
    
    void Start()
    {
        diceText.text = "0";        
    }
    
    void Update()
    {
        DayMulti();
    }

    public void RandomNumber()
    {       
          diceNumber = diceThrow.result;        
          diceNumberMulti = diceNumber * multi * dayMulti;
          diceText.text = diceNumberMulti.ToString(); 
          //diceScript.SumPoints();        
    }
    public void DayMulti()
    {
        if (daySystem.days.Equals("Saturday"))
        {
            dayMulti = 2;
        }
        else
        {
            dayMulti = 1;
        }
    }
}
