using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Casino : MonoBehaviour
{
    [SerializeField]
    GameObject MainButtons;
    [SerializeField]
    Button CasinoButton;
    [SerializeField]
    Button GoBackButton;
    [SerializeField]
    Button BuyChipsButton;


    [SerializeField]
    GameObject ChipsButton;
    [SerializeField]
    Button SumChipsButton;
    [SerializeField]
    Button RestChipsButton;
    [SerializeField]
    Button BuyNewChipsButton;

    [SerializeField]
    GameObject GamesButtons;
    [SerializeField]
    Button SlotsButton;
    [SerializeField]
    Button GuessTheNumberButton;
    [SerializeField]
    Button RouletteButton;

    [SerializeField]
    GameObject Games;
    [SerializeField]
    GameObject Slots;
    [SerializeField]
    GameObject GuessTheNumber;
    [SerializeField]
    GameObject Roulette;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void PressCasinoButton()
    {
        Games.SetActive(true);
    }
    
}
