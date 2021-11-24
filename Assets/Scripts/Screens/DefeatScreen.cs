using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject defeatPanel;

    [SerializeField]
    private Text highscore;

    [SerializeField]
    private Text currentScore;

    void Start()
    {
        GameManager.Instance.OnGameEnd += OnGameEnd;
    }

    private void OnGameEnd()
    {
        int highScorePrefs = PlayerPrefs.GetInt(Constants.HIGHSCORE_PREF);
        int score = GameManager.Instance.Score;

        defeatPanel.SetActive(true);
        if (highScorePrefs == score)
        { 
            highscore.text = "NEW HIGHSCORE";
            currentScore.text = $"{score}";
        }
        else
        {
            highscore.text = $"HIGHSCORE\n{highScorePrefs}";
            currentScore.text = $"Your score\n{score}";
        }        
    }

    public void MainMenu()
    {
        SceneHandler.LoadMainMenu();
    }

    public void Restart()
    {
        SceneHandler.LoadGame();
    }

}
