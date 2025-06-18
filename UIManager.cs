/*
* Author: Janelle Ng
* Date: 15-06-2025
* Description: Manages all UI elements including score tracking, health display, inventory status, 
*              collectible counting, and congratulatory messages.
*/

using UnityEngine;
using TMPro;

/* UI management system that handles score display, health tracking, inventory status, collectible progress, and game completion messages */
public class UIManager : MonoBehaviour
{
    /* Only one UIManager object */
    public static UIManager Instance;

    [Header("UI Text References")]
    public TextMeshProUGUI keyText;

    // UI text element displaying texts
    public TextMeshProUGUI keycardText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI healthText;

    public TextMeshProUGUI collectiblesRemainingText;

    public TextMeshProUGUI congratulationsText;

    [Header("Player Settings")]
    // Maximum health value for the player
    public int maxHealth = 100;


    /// Total number of collectibles in the scene 
    public int totalCollectibles = 5;


    /// Current player score
    private int score = 0;

    /// Current player health
    private int health;

    /// Number of collectibles remaining to be collected
    private int collectiblesRemaining;

    /// Whether player currently has a key
    private bool hasKey = false;


    /// Whether player currently has a keycard
    private bool hasKeycard = false;


    /// Whether the completion message has been shown
    private bool hasShownCompletion = false;

    /// Makes sure that only one instance of UIManager exists
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// Initialize UI state and components when game starts
    /// This method is called once at the start of the game
    private void Start()
    {
        // Initialize player stats
        health = maxHealth;
        collectiblesRemaining = totalCollectibles;

        // Hide congratulations message initially
        if (congratulationsText != null)
        {
            congratulationsText.gameObject.SetActive(false);
        }

        // Update all UI elements
        UpdateUI();
    }


    /* Add points to the player's score */
    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();
        Debug.Log($"Added {amount} points. Total score: {score}");
    }


    /// Apply damage to the player and handle death
    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Max(0, health); // Ensure health doesn't go below 0

        if (health <= 0)
        {
            HandlePlayerDeath();
        }

        UpdateUI();
        Debug.Log($"Player took {amount} damage. Health: {health}"); //Update UI with new health value
    }

    /// Handle player death and trigger respawn
    private void HandlePlayerDeath()
    {
        // Find player and trigger respawn through PlayerHealth component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth playerHealth = player?.GetComponent<PlayerHealth>();
    }

    /// Called when a collectible is gathered - decrements remaining count
    public void OnCollectibleGathered()
    {
        collectiblesRemaining--;
        collectiblesRemaining = Mathf.Max(0, collectiblesRemaining); // Ensure it doesn't go negative

        UpdateUI();

        // Check if all collectibles have been collected
        if (collectiblesRemaining <= 0 && !hasShownCompletion)
        {
            ShowCompletionMessage();
        }

        Debug.Log($"Collectible gathered! Remaining: {collectiblesRemaining}");
    }

    /// Display congratulatory message when all collectibles are collected
    private void ShowCompletionMessage()
    {
        hasShownCompletion = true;

        if (congratulationsText != null)
        {
            congratulationsText.text = "Congratulations! You collected all items!";
            congratulationsText.gameObject.SetActive(true);
        }
    }

    /// Reset all player state to initial values
    public void ResetPlayerState()
    {
        score = 0;
        health = maxHealth;
        hasKey = false;
        hasKeycard = false;
        collectiblesRemaining = totalCollectibles;
        hasShownCompletion = false;

        // Hide completion message
        if (congratulationsText != null)
        {
            congratulationsText.gameObject.SetActive(false);
        }

        UpdateUI();
        Debug.Log("Player state reset to initial values");
    }


    /// Give the player a key
    public void AddKey()
    {
        hasKey = true;
        UpdateUI();
        Debug.Log("Key added to inventory");
    }

    /// Remove the key from player's inventory
    public void RemoveKey()
    {
        hasKey = false;
        UpdateUI();
        Debug.Log("Key removed from inventory");
    }


    /// Give the player a keycard
    public void AddKeycard()
    {
        hasKeycard = true;
        UpdateUI();
        Debug.Log("Keycard added to inventory");
    }


    /// Remove the keycard from player's inventory when using it to open a door
    public void RemoveKeycard()
    {
        hasKeycard = false;
        UpdateUI();
        Debug.Log("Keycard removed from inventory");
    }

    /// <summary>
    /// Heal the player by specified amount
    /// </summary>
    /// <param name="amount">Amount of health to restore</param>
    public void HealPlayer(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth); // Cap at max health
        UpdateUI();
        Debug.Log($"Player healed for {amount}. Current health: {health}");
    }

    /// Set the total number of collectibles (useful for dynamic scenes)
    public void SetTotalCollectibles(int total)
    {
        totalCollectibles = total;
        collectiblesRemaining = total;
        hasShownCompletion = false;

        // Hide completion message if it was showing
        if (congratulationsText != null)
        {
            congratulationsText.gameObject.SetActive(false);
        }

        UpdateUI();
        Debug.Log($"Total collectibles set to: {total}");
    }

    /// Update all UI text elements with current values
    private void UpdateUI()
    {
        // Update score display
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }

        // Update health display
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString() + "/" + maxHealth.ToString();
        }

        // Update key status
        if (keyText != null)
        {
            keyText.text = hasKey ? "Key: Acquired" : "Key: None";
        }

        // Update keycard status
        if (keycardText != null)
        {
            keycardText.text = hasKeycard ? "Keycard: Acquired" : "Keycard: None";
        }

        // Update collectibles remaining
        if (collectiblesRemainingText != null)
        {
            collectiblesRemainingText.text = "Collectibles Remaining: " + collectiblesRemaining.ToString();
        }
    }
    /// Check if player has a key
    public bool HasKeycard => hasKeycard;

}