using System;
using UnityEngine;

public class LevelPhaseManager : MonoBehaviour
{
    [Header("Force Data Managers")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float obstacleSpeed = 5f;

    private bool isAvailableChangeSpeed;
    private GameData gameData;

    void OnEnable()
    {
        Subscribe();
    }

    void OnDisable()
    {
        Unsubscribe();
    }

    public GameData CurrentGameData
    {
        get
        {
            return new GameData
            {
                PlayerSpeed = playerSpeed,
                ObstacleSpeed = obstacleSpeed
            };
        }
    }

    private void Subscribe()
    {
        GameManagerState.Instance.onGameSpeedChanged += OnGameSpeedChanged;
        GameManagerState.Instance.onGameSpeedUp += OnGameSpeedUp;
        GameManagerState.Instance.onGameSpeedDown += OnGameSpeedDown;
        GameManagerState.Instance.onGameSpeedReset += OnGameSpeedReset;
        GameManagerState.Instance.onGamePassTime += OnGamePassTime;
    }

    private void Unsubscribe()
    {
        GameManagerState.Instance.onGameSpeedUp -= OnGameSpeedUp;
        GameManagerState.Instance.onGameSpeedDown -= OnGameSpeedDown;
        GameManagerState.Instance.onGameSpeedReset -= OnGameSpeedReset;
        GameManagerState.Instance.onGamePassTime -= OnGamePassTime;
    }

    private void OnGameSpeedChanged(bool arg0)
    {
        // Implement logic if needed
    }

    private void OnGamePassTime(float _playerSpeed, float _obstacleSpeed)
    {
        // Implement logic if needed
    }

    private void OnGameSpeedReset()
    {
        throw new NotImplementedException();
    }

    private void OnGameSpeedDown()
    {
        throw new NotImplementedException();
    }

    private void OnGameSpeedUp()
    {
        playerSpeed += 1f;
        obstacleSpeed += 1f;
        UpdateGameData();
        Debug.Log($"Game Speed Up");
        Debug.Log($"playerSpeed: {playerSpeed}");
    }

    private void UpdateGameData()
    {
        gameData.PlayerSpeed = playerSpeed;
        gameData.ObstacleSpeed = obstacleSpeed;
    }
}
