using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

    public static GamePlayController Instance;

    private void GetInstance()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Awake()
    {
        Time.timeScale = 0; // 0: đóng băng tiến trình, 1: chạy
        GetInstance();
    }

    public void InstructionButton()
    {
        Time.timeScale = 1;
        instructionButton.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = "" + score;
    }

    public void BirdDiedShowPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
