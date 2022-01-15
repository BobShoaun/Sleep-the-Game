using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    private Transform _pauseMenu;
    private Transform _gameOverMenu;

    [SerializeField] private List<string> _enoughSleepPhrases;
    [SerializeField] private Color _enoughSleepColor;

    [SerializeField] private List<string> _notEnoughSleepPhrases;
    [SerializeField] private Color _notEnoughSleepColor;

    private TMP_Text _gameEndText;
    private TMP_Text _youSleptForText;
    private TMP_Text _yourBestSleepText;

    private void Awake()
    {
        #region Singleton

        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
        #endregion

        _pauseMenu = transform.Find("PauseMenu");
        _gameOverMenu = transform.Find("GameEndMenu");

        _gameEndText = _gameOverMenu.Find("GameEndText").GetComponent<TMP_Text>();
        _youSleptForText = _gameOverMenu.Find("YouSleptForText").GetComponent<TMP_Text>();
        _yourBestSleepText = _gameOverMenu.Find("YourBestSleepText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (!IsGameOver() && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    #region Pause Menu

    public void TogglePause()
    {
        if (IsPaused())
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
    }

    public void UnpauseGame()
    {
        _pauseMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    #endregion

    #region Game Over Menu

    public void GameEnd()
    {
        UnpauseGame();

        // Set game end text
        if (GameManager.Instance.DidBeatThreshold())
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }

        _yourBestSleepText.text = $"Your best sleep was {GameManager.Instance.GetHighScore()} minutes.";
        _gameOverMenu.gameObject.SetActive(true);
    }

    private void LoseGame()
    {
        _gameEndText.text = GetRandomPhrase(_notEnoughSleepPhrases);
        _gameEndText.color = _notEnoughSleepColor;
        _youSleptForText.text = $"You only slept for {GameManager.Instance.SleepMeter} minutes...";
    }

    private void WinGame()
    {
        _gameEndText.text = GetRandomPhrase(_enoughSleepPhrases);
        _gameEndText.color = _enoughSleepColor;
        _youSleptForText.text = $"You slept for {GameManager.Instance.SleepMeter} minutes!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion

    #region Utilities

    private bool IsGameOver()
    {
        return _gameOverMenu.gameObject.activeInHierarchy;
    }

    private bool IsPaused()
    {
        return _pauseMenu.gameObject.activeInHierarchy;
    }

    private string GetRandomPhrase(List<string> phrases)
    {
        int randomPhraseIndex = Random.Range(0, phrases.Count);
        return phrases[randomPhraseIndex];
    }

    #endregion
}
