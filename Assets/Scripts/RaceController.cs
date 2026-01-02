using UnityEngine;

public class RaceController : MonoBehaviour
{
    public HorseRun[] horses;
    void Start()
    {
        foreach (HorseRun horse in horses)
        {
            horse.StartRunning();
        }
    }
    
    void Update()
    {
        
    }
}
