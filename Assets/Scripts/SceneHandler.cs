using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneHandler
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(Constants.MAINMENU_SCENE);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(Constants.GAME_SCENE);
    }

}
