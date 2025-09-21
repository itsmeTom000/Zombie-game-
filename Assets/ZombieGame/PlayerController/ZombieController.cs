using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using DG.Tweening;

public class ZombieController : MonoBehaviour
{
    #region Priavte_Variable
    public static ZombieController Instance { get; private set; }

    [SerializeField] private ZombieScript zombiePrefeb;
    [SerializeField] private BossZombieScript bossZombiePrefeb;
    [SerializeField] private Transform playerPosition;
    Vector3 max = new(30, 0, 30);

    [Range(0, 100)]
    public int bulletDamage;
    private int level;
    #endregion

    #region Public_Variable
    public int deadzombieCount;
    #endregion

    #region Unity_Callbacks

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        level = GameManager.Instance.uiData.savedUIData.levelData.currentLevel;
    }
    private void Start()
    {
        if (level % 10 == 0)
        {
            bulletDamage += 20;
        }
        StartCoroutine(SpawnNormalZombies());
        StartCoroutine(SpawnBossZombies());
    }
    #endregion

    #region Private_Callbacks
    IEnumerator SpawnNormalZombies()
    {
        for (int i = 0; i < LevelGenerator.Instance.zombieLevelData.zombieCount; i++)
        {
            Vector3 offset = new(
                Random.Range(-max.x, max.x),
                1,
                Random.Range(-max.z, max.z)
            );
            Vector3 spawnPosition = playerPosition.position + offset;
            ZombieScript zombie = Instantiate(zombiePrefeb, spawnPosition, Quaternion.identity);
            zombie.currentHealth = LevelGenerator.Instance.zombieLevelData.zombieHealth;
            float delay = LevelGenerator.Instance.zombieLevelData.spawnInterval;
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator SpawnBossZombies()
    {
        for (int i = 0; i < LevelGenerator.Instance.bossData.bossCount; i++)
        {
            Vector3 offset = new(
               Random.Range(-max.x, max.x),
               1,
               Random.Range(-max.z, max.z)
            );
            Vector3 spawnPosition = playerPosition.position + offset;
            BossZombieScript boss = Instantiate(bossZombiePrefeb, spawnPosition, Quaternion.identity);
            boss.currentHealth = LevelGenerator.Instance.bossData.bossHealth;
            float delay = LevelGenerator.Instance.bossData.bossSpawnInterval;
            yield return new WaitForSeconds(delay);
        }
    }

    #endregion
}
