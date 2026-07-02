using TMPro;
using UnityEngine;


namespace YeNaing
{
    public class InGameUIController : MonoBehaviour
    {
        public int coinAmount = 0;
        public int maxCoinAmount;

        // Show Signs of Game Progress
        public GameObject computerDisabled;
        public GameObject computerActive;
        public GameObject gameWinTrigger;

        // UI Panels
        public GameObject inGamePanel;
        public GameObject gamePausePanel;
        public GameObject gameWinPanel;
        public GameObject gameLostPanel;
        public GameObject gameHelpPanel;

        [SerializeField] TMP_Text coinAmountText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            maxCoinAmount = GameObject.FindGameObjectsWithTag("Coin").Length;
            inGamePanel.SetActive(true);
            computerDisabled.SetActive(true);
            computerActive.SetActive(false);
            gameWinTrigger.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            allCoinsCollected(); // run after all coins collected
        }

        public void allCoinsCollected()
        {
            coinAmountText.text = "Coin: " + coinAmount + " / " + maxCoinAmount;

            if (coinAmount >= maxCoinAmount)
            {
                computerDisabled.SetActive(false);
                computerActive.SetActive(true);
                gameWinTrigger.SetActive(true);
            }
        }

        // Game Paused Panel
        public void GamePaused()
        {
            Time.timeScale = 0;
            inGamePanel.SetActive(false);
            gamePausePanel.SetActive(true);
        }

        // Game Resumed
        public void GameResumed()
        {
            Time.timeScale = 1;
            inGamePanel.SetActive(true);
            gamePausePanel.SetActive(false);
        }

        // Game Restart Panel
        public void GameRestart()
        {
            GameManager.instance.Retry();
            Time.timeScale = 1;
        }

        // Game Tips Panel
        public void GameTips()
        {
            inGamePanel.SetActive(false);
            gameLostPanel.SetActive(false);
            gameHelpPanel.SetActive(true);
        }

        // Game Main Menu
        public void GameMainMenu()
        {
            Time.timeScale = 1;
            GameManager.instance.MainMenu();
        }

        public void NextLevel()
        {
            Time.timeScale = 1;
            GameManager.instance.NextLevel();
        }

        // Game Win Panel
        public void GameWin()
        {
            inGamePanel.SetActive(false);
            gameWinPanel.SetActive(true);
            // Play Sound
            // VFX
        }

        // Game Loss Panel
        public void GameLost()
        {
            inGamePanel.SetActive(false);
            gameHelpPanel.SetActive(false);
            gameLostPanel.SetActive(true);
            // Play Sound
            // VFX
        }
    }
}

