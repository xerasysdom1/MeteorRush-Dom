using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI livesText;

    float score = 0f;
    public void AddScore(float points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString("0");
    }
    public float maxLives = 3f;
    public float currentLives;

    public void TakeDamage(float damage)
    {
        currentLives -= damage;

    }
    public float getMaxLives()
    {
        return maxLives;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: 0";
        currentLives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLives <= 0)
        {
            // Here you could add code to restart the game or return to the main menu
            Time.timeScale = 0f; // Pause the game
            scoreText.text = "Game Over! Final Score: " + score.ToString("0") + "\nPress R to Restart";
            
        }
    }

    public float getCurrentLives()
    {
        return currentLives;
    }



    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}


