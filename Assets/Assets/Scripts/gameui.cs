using UnityEngine;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    public int maxLives = 3;
    public int maxHealth = 100;

    public int score;
    private int health;
    private int lives;

    private Label scoreLabel;
    private Label healthLabel;
    private VisualElement livesContainer;

    void Start()
    {
        // Get UI references
        var root = GetComponent<UIDocument>()?.rootVisualElement;

        scoreLabel = root.Q<Label>("score");


        healthLabel = root.Q<Label>("health");

        livesContainer = root.Q<VisualElement>("lives");


        // Initialize values
        score = 0;
        health = maxHealth;
        lives = maxLives;

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            lives--;
            if (lives <= 0)
            {
                Time.timeScale = 0f; // Game over

            }
            else
            {
                health = maxHealth; // Reset health
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreLabel != null)
            scoreLabel.text = "score: " + score;
        if (healthLabel != null)
            healthLabel.text = "health: " + health;

        if (livesContainer != null)
        {
           
        var life1 = livesContainer.Q<VisualElement>("player-1");
        var life2 = livesContainer.Q<VisualElement>("player-2");
        var life3 = livesContainer.Q<VisualElement>("player-3");

        life1.style.display = lives >= 1 ? DisplayStyle.Flex : DisplayStyle.None;
         life2.style.display = lives >= 2 ? DisplayStyle.Flex : DisplayStyle.None;
        life3.style.display = lives >= 3 ? DisplayStyle.Flex : DisplayStyle.None;
    }
        
    }

}