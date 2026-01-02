using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DiceFaceUI : MonoBehaviour
{
    public DiceThrow diceThrow; 
    public RectTransform canvasTransform; 
    public TextMeshProUGUI resultText; 
    public Camera mainCamera; 
    public GameObject diceObject; 

    private bool isShown = false; 
    private bool canThrowDice = true; 

    public Rect ClickZone;

    private void Start()
    {
        ClickZone = new Rect(400, 100, 1125, 500);
    }
    void Update()
    {       
        if (!isShown && diceThrow.result > 0)
        {
            ShowTextAboveWinningFace();
            isShown = true;
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && canThrowDice)
        {
            Vector2 mousePos = Input.mousePosition;

            mousePos.y = Screen.height - mousePos.y;

            if (ClickZone.Contains(mousePos))
            {
                ResetAndThrowDice();
            }            
        }
    }

    void ShowTextAboveWinningFace()
    {
        int index = Mathf.RoundToInt(diceThrow.result) - 1;
        if (index < 0 || index >= diceThrow.faces.Length) return;

        Transform winningFace = diceThrow.faces[index];
        
        canvasTransform.position = winningFace.position + winningFace.up * 0.5f;
        canvasTransform.rotation = Quaternion.LookRotation(canvasTransform.position - mainCamera.transform.position);
        resultText.text = diceThrow.result.ToString();
        
        canvasTransform.gameObject.SetActive(true);
        
        StartCoroutine(HideEverythingAfterDelay(0.2f));
    }

    IEnumerator HideEverythingAfterDelay(float delay)    {
        
        yield return new WaitForSeconds(delay);
        
        canvasTransform.gameObject.SetActive(false);
       
        diceObject.SetActive(false);
        
        canThrowDice = true;
    }

    void ResetAndThrowDice()
    {        
        canThrowDice = false;
        
        diceObject.SetActive(true); 
        
        diceThrow.ResetDice();
        
        canvasTransform.gameObject.SetActive(false);  
        
        isShown = false;
        
        StartCoroutine(ThrowDiceAfterDelay());
    }
    
    IEnumerator ThrowDiceAfterDelay()
    {
        yield return new WaitForSeconds(0.1f); 

        diceThrow.ThrowDice(); 
    }
}
