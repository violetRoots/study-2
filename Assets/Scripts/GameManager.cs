using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private float maxRainPoints;
    [SerializeField] private float rainPointsPerFrame;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private Slider rainSlider;

    private bool isLose = false;

    private float CurrentRainPoints
    {
        get => _currentRainPoints;
        set => _currentRainPoints = Mathf.Clamp(value, 0, maxRainPoints);
    }
    private float _currentRainPoints;

    private void Start()
    {
        CurrentRainPoints = maxRainPoints;
    }

    private void Update()
    {
        CurrentRainPoints -= rainPointsPerFrame * Time.smoothDeltaTime;

        rainSlider.value = CurrentRainPoints / maxRainPoints;

        if(CurrentRainPoints == 0 && !isLose)
        {
            Time.timeScale = 0.0f;
            endGamePanel.SetActive(true);
            isLose = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddRainPoints(float value)
    {
        CurrentRainPoints += value;
    }
}
