using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    GameObject ball;

    public Transform[] transforms;

    [SerializeField]
    Button playButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonPressed()
    {
        StartCoroutine(RollRoulette());
    }

    IEnumerator RollRoulette()
    {
        ball.SetActive(true);
        for (int i = 0; i < Random.Range(i,10); i++)
        {
            ball.transform.position = transforms[i % transforms.Length].position;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
