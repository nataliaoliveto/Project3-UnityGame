using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField]
    private Text highscore;

    private void Awake()
    {
        CalculateScreen();
        if (highscore != null)
        {
            highscore.text = $"HIGHSCORE\n{PlayerPrefs.GetInt(Constants.HIGHSCORE_PREF)}";
        }
    }

    private void CalculateScreen()
    {
        float finalHeight = Screen.currentResolution.height - 100;
        float finalWidth = finalHeight * ((float)Screen.currentResolution.height / (float)Screen.currentResolution.width);
        Screen.SetResolution((int)finalWidth, (int)finalHeight, false);
    }

    public void StartGame()
    {
        SceneHandler.LoadGame();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
