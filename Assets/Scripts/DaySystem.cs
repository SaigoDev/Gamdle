using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaySystem : MonoBehaviour
{
    Slider slider;
    public string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    public TextMeshProUGUI dayText;
    float initialValue = 0;
    int arrayVariable = 0;
    float speed = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();        
        dayText.text = days[arrayVariable];
    }

    // Update is called once per frame
    void Update()
    {
        initialValue += speed * Time.deltaTime;        
        slider.value = initialValue;
        CheckEndValue();        
    }

    void CheckEndValue()
    {
        if (slider.value == 1)
        {
            if(arrayVariable != days.Length - 1)
            {
                dayText.text = days[arrayVariable + 1];                
                initialValue = 0;
                arrayVariable++;
            }
            else
            {
                arrayVariable = 0;
                initialValue = 0;
                dayText.text = days[arrayVariable];
            }
            
        }
    }
}
