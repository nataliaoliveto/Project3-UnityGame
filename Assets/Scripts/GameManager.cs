using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Vector2 ScreenLimit { get; private set; }

    public int Score { get; private set; }

    public bool IsGameRunning { get; private set; }

    // suscribir a la action || el delegate hace que no sea nulo, declara una firma y asigna una función vacía para evitar errores de suscripción
    public event Action OnGameEnd = delegate { };

    [SerializeField]
    private Text scoreText;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
            //cumplir el "Singleton"
        }

        Instance = this;

        IsGameRunning = true;

        SetCamera();
    }

    private void SetCamera()
    {
        Camera mainCamera = Camera.main;

        //puntos de limite de la camara, punto derecha abajo y en negativo punto izquierda abajo
        //transforma los pixeles de la camara en unidades del mundo
        ScreenLimit = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        
    }

    public void AddScore(int amount)
    {
        if (!IsGameRunning) return;

        int newScore = Score + amount;

        if(newScore > 0)
        {
            Score = newScore;
        }
        else
        {
            Score = 0;
            OnDefeat();
        }

        scoreText.text = $"Score: {Score}";
        
    }

    public void OnCharacterDie()
    {
        OnDefeat();
    }

    private void OnDefeat()
    {
        if (!IsGameRunning) return;

        IsGameRunning = false;

        if (PlayerPrefs.GetInt(Constants.HIGHSCORE_PREF) < Score)
            PlayerPrefs.SetInt(Constants.HIGHSCORE_PREF, Score);

        OnGameEnd?.Invoke();
    }

}
