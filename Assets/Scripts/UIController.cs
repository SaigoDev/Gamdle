using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    GameObject MainButtons;
    [SerializeField]
    Button CasinoButton;
    [SerializeField]
    Button GoBackButton;
    [SerializeField]
    Button BuyChipsButton;
    
    public TextMeshProUGUI ChipsText;


    [SerializeField]
    GameObject ChipsButton;
    [SerializeField]
    Button SumChipsBuyButton;
    [SerializeField]
    Button RestChipsBuyButton;
    [SerializeField]
    Button BuyNewChipsBuyButton;
    [SerializeField]
    Button SumChipsRestButton;
    [SerializeField]
    Button RestChipsRestButton;
    [SerializeField]
    Button BuyNewChipsRestButton;

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

    [SerializeField]
    GameObject HorseRaces;
    [SerializeField]
    Button HorseRacesButton;

    bool casinoActive = false;
    bool chipsActive = false;

    public float playerChips;

    public enum GameState
    {
        MainMenu,
        Casino,
        Chips,
        Roulette,
        Slots,
        GuessTheNumber,
        HorseRaces
    }

    public GameState currentState = GameState.MainMenu;
    
    public void PressCasinoButton()
    {
        casinoActive = true;
        currentState = GameState.Casino;
        GamesButtons.SetActive(true);
        CasinoButton.gameObject.SetActive(false);
        GoBackButton.gameObject.SetActive(true);
        BuyChipsButton.gameObject.SetActive(true);
        ChipsText.gameObject.SetActive(true);        
    }

    public void PressBuyChipsButton()
    {
        currentState = GameState.Chips;
        GamesButtons.gameObject.SetActive(false);
        ChipsButton.gameObject.SetActive(true);
        BuyChipsButton.gameObject.SetActive(false);
        chipsActive = true;
    }

    public void PressRouletteButton()
    {
        currentState = GameState.Roulette;
        BuyChipsButton.gameObject.SetActive(false);
        GamesButtons.gameObject.SetActive(false);
        Games.SetActive(true);
        Slots.SetActive(false);
        GuessTheNumber.SetActive(false);
        Roulette.SetActive(true);
    }

    public void PressSlotsButton()
    {
        currentState = GameState.Slots;
        BuyChipsButton.gameObject.SetActive(false);
        GamesButtons.gameObject.SetActive(false);
        Games.SetActive(true);
        Slots.SetActive(true);
        GuessTheNumber.SetActive(false);
        Roulette.SetActive(false);
    }

    public void PressGuessTheNumberButton()
    {
        currentState = GameState.GuessTheNumber;
        BuyChipsButton.gameObject.SetActive(false);
        GamesButtons.gameObject.SetActive(false);
        Games.SetActive(true);
        Slots.SetActive(false);
        GuessTheNumber.SetActive(true);
        Roulette.SetActive(false);
    }

    public void PressHorseRacesButton()
    {
        currentState = GameState.HorseRaces;
        BuyChipsButton.gameObject.SetActive(false);
        GamesButtons.SetActive(false);
        Games.SetActive(false);
        HorseRaces.SetActive(true);
    }

    public void PressBackButton()
    {
        /*if (casinoActive)
        {
            CasinoButton.gameObject.SetActive(true);
            GoBackButton.gameObject.SetActive(false);
            BuyChipsButton.gameObject.SetActive(false);
            ChipsText.gameObject.SetActive(false);
            GamesButtons.SetActive(false);   
            MainButtons.SetActive(true);
            casinoActive = false;
        }
        if (chipsActive)
        {
            GamesButtons.gameObject.SetActive(true);
            ChipsButton.gameObject.SetActive(false);
            BuyChipsButton.gameObject.SetActive(true);
            GoBackButton.gameObject.SetActive(true);
            CasinoButton.gameObject.SetActive(false);
            chipsActive = false;
            casinoActive = true;
        }
        else if (Roulette || Slots || GuessTheNumber || HorseRaces)
        {
            BuyChipsButton.gameObject.SetActive(true);
            GamesButtons.gameObject.SetActive(true);            
            Slots.SetActive(false);
            GuessTheNumber.SetActive(false);
            Roulette.SetActive(false);
            Games.SetActive(false);
            HorseRaces.SetActive(false);
        }*/
        switch (currentState)
        {
            case GameState.Casino:                
                CasinoButton.gameObject.SetActive(true);
                GoBackButton.gameObject.SetActive(false);
                BuyChipsButton.gameObject.SetActive(false);
                ChipsText.gameObject.SetActive(false);
                GamesButtons.SetActive(false);
                MainButtons.SetActive(true);

                casinoActive = false;
                currentState = GameState.MainMenu;
                break;

            case GameState.Chips:                
                GamesButtons.SetActive(true);
                ChipsButton.gameObject.SetActive(false);
                BuyChipsButton.gameObject.SetActive(true);
                GoBackButton.gameObject.SetActive(true);
                CasinoButton.gameObject.SetActive(false);

                chipsActive = false;
                casinoActive = true;
                currentState = GameState.Casino;
                break;

            case GameState.Roulette:
            case GameState.Slots:
            case GameState.GuessTheNumber:
            case GameState.HorseRaces:                
                BuyChipsButton.gameObject.SetActive(true);
                GamesButtons.gameObject.SetActive(true);
                GoBackButton.gameObject.SetActive(true);

                Slots.SetActive(false);
                GuessTheNumber.SetActive(false);
                Roulette.SetActive(false);
                Games.SetActive(false);
                HorseRaces.SetActive(false);

                currentState = GameState.Casino;
                break;

            case GameState.MainMenu:                
                break;
        }
    }
}
