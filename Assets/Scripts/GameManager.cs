using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int CurrentScore { get; set; }
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text bestScoreText;

    public float timeTillGameOver = 1.5f;

    [Header("Panels")]
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("GameOver")]
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private TMP_Text gameOverBestScoreText;



    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        

        scoreText.text = CurrentScore.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        gamePanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        CurrentScore += score;
        scoreText.text = CurrentScore.ToString();
    }

    public void GameOver()
    {
        if (CurrentScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", CurrentScore);
        }

        Debug.Log("Game Over");
        Time.timeScale = 0;
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = CurrentScore.ToString();
        gameOverBestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();

        AudioManager.Instance.PlaySFX("LoseGame");
        AudioManager.Instance.PlayMusic("GameOver");
    }
}
