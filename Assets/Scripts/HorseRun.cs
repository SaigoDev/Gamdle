using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HorseRun : MonoBehaviour
{
    Slider horseSlider;
    float initialValue = 0;
    float speed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horseSlider = GetComponent<Slider>();
        //StartCoroutine(SpeedChanger());
    }

    // Update is called once per frame
    void Update()
    {        
        HorseRace();
        Debug.Log(speed);
    }

    void HorseRace()
    {
        initialValue += speed * Time.deltaTime;
        horseSlider.value = initialValue;
    }

    void RandomSpeedEachSeconds()
    {

    }

    IEnumerator SpeedChanger()
    {
        while (true)
        {
            speed = Random.Range(0.001f, 0.1f);
            yield return new WaitForSeconds(0.2f);
        }
    }
    public void StartRunning()
    {
        StartCoroutine(SpeedChanger());
    }
}
