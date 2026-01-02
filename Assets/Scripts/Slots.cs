using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Slots : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI slot1;
    float slot1Text;
    [SerializeField]
    TextMeshProUGUI slot2;
    float slot2Text;
    [SerializeField]
    TextMeshProUGUI slot3;
    float slot3Text;

    [SerializeField]
    Button slotsButton;

    bool buttonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slot1.text = slot1Text.ToString();
        slot2.text = slot2Text.ToString(); 
        slot3.text = slot3Text.ToString();
    }

    public void ButtonPressed()
    {        
        StartCoroutine(SlotsTime());
    }

    IEnumerator SlotsTime()
    {
        for (int i = 0; i < 10; i++)
        {
            slot1Text = Random.Range(1, 6);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 10; i++)
        {
            slot2Text = Random.Range(1, 6);
            yield return new WaitForSeconds(0.2f);
        }
        for (int i = 0; i < 10; i++)
        {
            slot3Text = Random.Range(1, 6);
            yield return new WaitForSeconds(0.2f);
        }

    }
}
