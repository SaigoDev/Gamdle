using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DiceScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public Button buyNewDiceButton;
    public Button autoPointsButton;
    public Button randomDiceSpawn;
    public Button randomDiceMultiSpawnButton;
    public TextMeshProUGUI buyDiceButtonText;
    float pointsNumber = 0;
    public RealDiceScript realDiceScript;
    public GameObject dicePrefab;


    public Transform parentCanvas;

    float timeForEachPoint = 1f;
    float timerForPoints = 0f;

    bool activateAutoButton = false;
    bool deactivateAutoButton = false;

    bool deactivateMultiButton = false;
    bool deactivateBonusPointsButton = false;

    float pointsToBuyDice = 50;

    public RectTransform randomDiceAppear;    
    bool randomDiceAppearTimerBool = false;
    bool randomDiceAlreadyAppeared = false;

    public RectTransform randomDiceMultiAppear;
    bool randomDiceAppearMultiBool = false;
    bool randomDiceMultiAlreadyAppeared = false;

    float timeLeft = 5f;
    bool cuentaAtrasActiva = false;

    public DiceThrow diceThrow;
    
    void Start()
    {
        pointsText.text = "0";        
    }
    
    void Update()
    {
        SpawnButtons();
        AutoPoints();
        AutoSpawnRandomDice();
        RandomButtonMultiSpawn();
        if (cuentaAtrasActiva)
        {
            CuentaAtrasMulti();
        }        
        buyDiceButtonText.text = "Buy 6 faces Dice  " + pointsToBuyDice;
        UpdatePointsText();
    }
    
    public void SumPoints()
    {
        pointsNumber += diceThrow.result;
        pointsText.text = pointsNumber.ToString();
    }
    
    void SpawnButtons()
    {
        if(pointsNumber >= 50)
        {
            buyNewDiceButton.gameObject.SetActive(true);
            //buyDiceButtonText.text = "Buy 6 faces Dice  " + pointsToBuyDice;
        }
        if (pointsNumber >= 70 && !deactivateAutoButton)
        {
            autoPointsButton.gameObject.SetActive(true);
        }
        if(pointsNumber >= 100 && !deactivateBonusPointsButton)
        {
            randomDiceSpawn.gameObject.SetActive(true);
        }  
        if(pointsNumber >= 200 && !deactivateMultiButton)
        {
            randomDiceMultiSpawnButton.gameObject.SetActive(true);
        }
    }

    public void GetNewDice()
    {
        if(pointsNumber >= pointsToBuyDice) 
        {
            GameObject instancia = Instantiate(dicePrefab);            

            pointsNumber -= pointsToBuyDice;
            pointsText.text = pointsNumber.ToString();
            pointsToBuyDice *= 4;
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
    }

    public void AutoPointsActivate()
    {
        if(pointsNumber >= 20)
        {
            activateAutoButton = true;
            autoPointsButton.gameObject.SetActive(false);
            deactivateAutoButton = true;
            pointsNumber -= 20;
            pointsText.text = pointsNumber.ToString();
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
        
    }       

    void AutoPoints()
    {
        if (activateAutoButton)
        {
            timerForPoints += Time.deltaTime * 0.5f;            
            if (timerForPoints >= timeForEachPoint)
            {
                pointsNumber++;
                timerForPoints = 0f;
                pointsText.text = pointsNumber.ToString();
            }
        }        
    }

    void AutoSpawnRandomDice()
    {
        if (randomDiceAppearTimerBool && !randomDiceAlreadyAppeared)
        {
            timerForPoints += Time.deltaTime * 0.5f;
            
            if (timerForPoints >= timeForEachPoint)
            {
                float randomChanceToAppear = Random.Range(0, 100);
                if (randomChanceToAppear >= 90)
                {
                    RandomDiceAppear();
                }
                timerForPoints = 0;
                randomDiceAlreadyAppeared = true;
            }
        }        
    }

    public void ClickedRandomDiceAppear()
    {
        randomDiceAlreadyAppeared = false;
        float randomSumPoints =  Random.Range(0, 20);
        pointsNumber += randomSumPoints;
        randomDiceAppear.gameObject.SetActive(false);
        pointsText.text = pointsNumber.ToString();
    }

    public void RandomDiceAppearBool()
    {
        if(pointsNumber >= 100)
        {
            randomDiceAppearTimerBool = true;
            deactivateBonusPointsButton = true;
            pointsNumber -= 100;
            pointsText.text = pointsNumber.ToString();
            randomDiceSpawn.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
        
    }

    void RandomDiceAppear()
    {
        Vector2 rangoX = new Vector2(-240, 440);
        Vector2 rangoY = new Vector2(-240, 240);

        float x = Random.Range(rangoX.x, rangoX.y);
        float y = Random.Range(rangoY.x, rangoY.y);
        randomDiceAppear.anchoredPosition = new Vector2(x,y);
        randomDiceAppear.gameObject.SetActive(true);        
    }

    public void RandomButtonMultiBool()
    {
        if(pointsNumber >= 200)
        {
            randomDiceAppearMultiBool = true;
            deactivateMultiButton = true;
            pointsNumber -= 200;
            pointsText.text = pointsNumber.ToString();
            randomDiceMultiSpawnButton.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You dont have enough points");
        }
    }

    void RandomButtonMultiSpawn()
    {
        if (randomDiceAppearMultiBool && !randomDiceMultiAlreadyAppeared)
        {
            timerForPoints += Time.deltaTime * 0.5f;

            if (timerForPoints >= timeForEachPoint)
            {
                float randomChanceToAppear = Random.Range(0, 100);
                if (randomChanceToAppear >= 90)
                {
                    RandomDiceMultiAppear();
                }
                timerForPoints = 0;
                randomDiceMultiAlreadyAppeared = true;
            }
        }
    }

    void RandomDiceMultiAppear()
    {
        Vector2 rangoX = new Vector2(-240, 440);
        Vector2 rangoY = new Vector2(-240, 240);

        float x = Random.Range(rangoX.x, rangoX.y);
        float y = Random.Range(rangoY.x, rangoY.y);
        randomDiceMultiAppear.anchoredPosition = new Vector2(x, y);
        randomDiceMultiAppear.gameObject.SetActive(true);
    }

    public void ClickedRandomMultiDiceAppeared()
    {
        randomDiceMultiAlreadyAppeared = false;
        cuentaAtrasActiva = true;
        timeLeft = 5f;
        randomDiceMultiAppear.gameObject.SetActive(false);
    }

    void CuentaAtrasMulti()
    {
        timeLeft -= Time.deltaTime;

        if(timeLeft > 0)
        {
            int seconds = Mathf.CeilToInt(timeLeft);
            realDiceScript.multi = 2;
        }
        else
        {
            cuentaAtrasActiva = false;
            realDiceScript.multi = 1;
        }
    }

    public float GetPointsNumber()
    {
        return pointsNumber;
    }

    public void SetPointsNumber(float number)
    {
        pointsNumber = number;
    }

    public void RestPointsNumber(float number)
    {
        pointsNumber -= number;
    }

    public void SumPointsNumber(float number)
    {
        pointsNumber += number;
    }

    void UpdatePointsText()
    {
        pointsText.text = pointsNumber.ToString();
    }
}