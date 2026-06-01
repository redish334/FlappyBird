using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;

  
    void Start()
    {
        Time.timeScale = 0f;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

  
    public void StartTheGame()
    {
        Time.timeScale = 1f; 
    }

    [ContextMenu("Increae Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (playerScore > highScore)
        {
            highScore = playerScore;

            // Зберігаємо новий рекорд у пам'ять пристрою під ключем "HighScore"
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Фіксуємо зміни на диску

            // Оновлюємо текст на екрані
            UpdateHighScoreText();
        }
    }

    void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "BEST SCORE: " + highScore.ToString();
        }
    }

    public void restartGame()
    {
       
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    [ContextMenu("Reset High Score")]
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        UpdateHighScoreText();
    }
}