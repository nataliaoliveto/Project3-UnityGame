using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public Vector2 ScreenLimit { get; private set; }

    public int Score { get; private set; }

    public bool IsGameRunning { get; private set; }

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
        Score += amount;
        scoreText.text = $"Score: {Score}";
    }

    public void OnCharacterDie()
    {
        if (!IsGameRunning) return;

        IsGameRunning = false;

    }

}
