using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    [Header("Lives UI")]
    public Transform livesContainer;
    public GameObject lifeIconPrefab;
    public Sprite playerSprite;
    public AudioSource audioSource;
    public AudioClip gameOverClip;
    private Image[] lifeIcons;

    private float score = 0f;

    public float maxLives = 3f;
    public float currentLives;

    public void AddScore(float points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString("0");
    }

    public void TakeDamage(float damage)
    {
        currentLives -= damage;
        currentLives = Mathf.Max(currentLives, 0);
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = i < currentLives;
        }
    }

    public float getMaxLives()
    {
        return maxLives;
    }

    void Start()
    {
        scoreText.text = "Score: 0";

        currentLives = maxLives;

        CreateLifeIcons();

        UpdateLivesUI();
    }

    void CreateLifeIcons()
    {
        lifeIcons = new Image[(int)maxLives];

        for (int i = 0; i < maxLives; i++)
        {
            GameObject iconObject = Instantiate(lifeIconPrefab, livesContainer);

            Image icon = iconObject.GetComponent<Image>();

            icon.sprite = playerSprite;
            icon.enabled = true;

            lifeIcons[i] = icon;
        }
    }

    void Update()
    {
        if (currentLives <= 0)
        {
            audioSource.PlayOneShot(gameOverClip);
            Time.timeScale = 0f;
            scoreText.text = "Game Over! Final Score: " + score.ToString("0") + "\nPress R to Restart";

            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RestartGame();
            }
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