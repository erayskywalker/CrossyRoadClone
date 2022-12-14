using kechigames.Singleton;

public class UiActions : Singleton<UiActions>
{
    public System.Action<bool> HandleHomeUi;
    public HomeUi homeUi;

    public System.Action<bool> HandleInGameUi;
    public InGameUI inGameUi;

    public System.Action<string, int> SetScoreHandler;

    public System.Action<bool> HandleLoseGameUi;
    public LoseGameUI loseGameUi;

    private void OnEnable()
    {
        HandleHomeUi += HomeUiHandler;
        HandleInGameUi += InGameUiHandler;
        SetScoreHandler += SetScoreToUi;
        HandleLoseGameUi += LoseGameUiHandler;
    }


    private void OnDisable()
    {
        HandleHomeUi -= HomeUiHandler;
        HandleInGameUi -= InGameUiHandler;
        SetScoreHandler -= SetScoreToUi;
        HandleLoseGameUi -= LoseGameUiHandler;
    }

    private void LoseGameUiHandler(bool active)
    {
        loseGameUi.gameObject.SetActive(active);
    }

    private void SetScoreToUi(string scoreType, int score)
    {
        switch (scoreType)
        {
            case "click":
                inGameUi.SetClick(score);
                break;

            case "coin":
                inGameUi.SetCoin(score);
                break;
        }
    }

    private void InGameUiHandler(bool active)
    {
        inGameUi.gameObject.SetActive(active);
    }

    private void HomeUiHandler(bool active)
    {
        homeUi.gameObject.SetActive(active);
    }
}