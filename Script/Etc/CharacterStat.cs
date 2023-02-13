using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    [SerializeField]private AudioSource hitSoundEffect;
    [SerializeField]private LayerMask bulletLayer;
    [SerializeField]private int maxHealth;
    private int currentHealth;
    private PlayerManager playerManager;
    private PlayerAnimator playerAnimator;
    private HealthBarUI healthBarUI;
    private GameOverMenu gameOverMenu;
    private GameStopwatch gameStopwatch;

    void Start() 
    {
        playerManager = GetComponent<PlayerManager>();
        playerAnimator = GetComponent<PlayerAnimator>();
        healthBarUI = GameObject.Find("Health Bar").GetComponent<HealthBarUI>();
        gameOverMenu = GameObject.Find("Game Over Menu").GetComponent<GameOverMenu>();
        gameStopwatch = GameObject.FindObjectOfType<GameStopwatch>();
        currentHealth = maxHealth;
        healthBarUI.numberOfHeart = maxHealth;
    }

    void Update()
    {

    }

    public void TakeDamage(int value)
    {
        hitSoundEffect.Play();
        currentHealth -= value;
        healthBarUI.numberOfHeart = currentHealth;

        if(currentHealth <= 0)
        {
            playerManager.PlayerDead();
            Invoke("DestroyObject",1.5f);
        }
    }

    public void Heal(int value)
    {
        currentHealth += value;
        healthBarUI.numberOfHeart = currentHealth;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void DestroyObject()
    {
        gameOverMenu.gameOverPanel.SetActive(true);
        gameStopwatch.isRunning = false;
        Destroy(gameObject);
    }
}
