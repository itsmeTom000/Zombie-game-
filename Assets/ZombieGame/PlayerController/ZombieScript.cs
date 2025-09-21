using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth = 100f;
    GameObject playerPosition;
    private int bulletDamage;
    #endregion

    #region Private Variables
    public float currentHealth;
    public float moveSpeed;
    #endregion

    #region Unity Callbacks
    private void Start()
    {
        bulletDamage = NewUiManager.Instance.zombieController.bulletDamage;
        playerPosition = GameObject.FindGameObjectWithTag("Wall");
        maxHealth = LevelGenerator.Instance.zombieLevelData.zombieHealth;
        currentHealth = maxHealth;
        moveSpeed = LevelGenerator.Instance.zombieLevelData.zombieSpeed;
        UpdateHealthBar();
    }

    private void Update()
    {
        Vector3 targetPosition = new(playerPosition.transform.position.x, 1, playerPosition.transform.position.z);
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += moveSpeed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            HandleBulletCollision(other);
        }
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Defeat");
            HandleWallCollision();
        }
    }
    #endregion

    #region Collision Handlers
    private void HandleBulletCollision(Collider bullet)
    {
        SoundManager.Instance.PlaySfx();
        currentHealth -= bulletDamage;
        UpdateHealthBar();

        Destroy(bullet.gameObject);

        if (currentHealth <= 0)
        {
            DetectZombie.Instance.enemyList.Remove(gameObject.transform);
            HandleDeath();
        }
    }

    private void HandleWallCollision()
    {
        IncrementDefeatCount(); // ✅ Increment defeat count on loss
        NewUiManager.Instance.victoryPanel.Open("Defeat");
        Time.timeScale = 0f;
    }
    #endregion

    #region Game State Updates
    private void HandleDeath()
    {
        var controller = NewUiManager.Instance.zombieController;
        controller.deadzombieCount++;

        NewUiManager.Instance.UpdateDeadZombieCount();

        if (controller.deadzombieCount == LevelGenerator.Instance.zombieLevelData.zombieCount + LevelGenerator.Instance.bossData.bossCount)
        {
            if (GameManager.Instance.uiData.savedUIData.levelData.currentLevel ==
                GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel)
            {
                GameManager.Instance.uiData.savedUIData.levelData.unlockedLevel++;
            }

            ResetDefeatCount(); // ✅ Reset defeat count on win

            NewUiManager.Instance.UpdateNextLevel();
            NewUiManager.Instance.victoryPanel.Open("Victory");
            SoundManager.Instance.PlayVictorySound();
        }
        Destroy(gameObject);
    }
    #endregion

    #region UI
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
        }
    }
    #endregion

    #region Defeat Count Logic
    private void IncrementDefeatCount()
    {
        GameManager.Instance.uiData.savedUIData.levelData.defeatCount++;
        Debug.Log("Defeat Count incremented to: " + GameManager.Instance.uiData.savedUIData.levelData.defeatCount);
    }

    private void ResetDefeatCount()
    {
        GameManager.Instance.uiData.savedUIData.levelData.defeatCount = 0;
        Debug.Log("Defeat Count reset to 0 after victory");
    }
    #endregion
}
