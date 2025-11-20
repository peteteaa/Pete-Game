using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class GameUIController : MonoBehaviour
{
    public int maxLives = 3;
    public int maxHealth = 100;
    public static GameUIController Instance;
    public int score = 0    ;
    public int health;
    public int lives;

    private Label scoreLabel;
    private Label healthLabel;
    private VisualElement livesContainer;
        private bool gameOver = false;
    private float gameOverStartTime;
    private float gameOverDuration = 3f;
  void Awake()
{


    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Only initialize defaults if PlayerInfo has no values yet
        if (PlayerInfo.CurrentScore == 0 && PlayerInfo.CurrentHealth == 0 && PlayerInfo.NumRemainingLives == 0)
        {
            score = 0;
            health = maxHealth;
            lives = maxLives;

            PlayerInfo.CurrentScore = score;
            PlayerInfo.CurrentHealth = health;
            PlayerInfo.NumRemainingLives = lives;
        }
    }
    else
    {
        Destroy(gameObject); // Remove duplicate
    }
}

    void Start()
    {
        // Get UI references
        var root = GetComponent<UIDocument>()?.rootVisualElement;

        scoreLabel = root.Q<Label>("score");


        healthLabel = root.Q<Label>("health");

        livesContainer = root.Q<VisualElement>("lives");

         score = PlayerInfo.CurrentScore;
        health = PlayerInfo.CurrentHealth;
        lives = PlayerInfo.NumRemainingLives;



        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        PlayerInfo.CurrentScore = score;
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
                if (scoreLabel != null)
                    scoreLabel.text = "Game Over!";


                gameOver = true;
                gameOverStartTime = Time.realtimeSinceStartup;
                PlayerInfo.CurrentScore = 0;
                PlayerInfo.CurrentHealth = 100;
                PlayerInfo.NumRemainingLives = 3;    
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                UpdateUI();
                return;
            }
            else
            {
                health = maxHealth; // Reset health
            }
        }
        PlayerInfo.CurrentHealth = health;
        PlayerInfo.NumRemainingLives = lives;
    
        UpdateUI();
    }

    void UpdateUI()
    {
        Debug.Log("lives: " + PlayerInfo.NumRemainingLives);
        Debug.Log("health: " + PlayerInfo.CurrentHealth);
        Debug.Log("score: " + PlayerInfo.CurrentScore);   
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