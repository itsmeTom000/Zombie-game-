using UnityEngine;

[System.Serializable]
public class ZombieLevelData
{
    public int zombieCount;
    public int waveCount;
    public float zombieHealth;
    public float zombieSpeed;
    public float spawnInterval;
}

[System.Serializable]
public class BossZombieData
{
    public int bossCount;
    public float bossHealth;
    public float bossSpeed;
    public float bossSpawnInterval;
}

public class LevelGenerator : MonoBehaviour
{
    #region Singleton
    public static LevelGenerator Instance { get; private set; }
    #endregion

    #region Public Variables
    public ZombieLevelData zombieLevelData = new ();
    public BossZombieData bossData = new ();
    #endregion

    #region Private Variables
    private int level;
    private int defeatCount;
    private bool isEasyMode;
    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        level = GameManager.Instance.uiData.savedUIData.levelData.currentLevel;
        defeatCount = GameManager.Instance.uiData.savedUIData.levelData.defeatCount;
        GenerateLevel();
    }
    #endregion

    #region Core Algorithm

    private void GenerateLevel()
    {
        isEasyMode = defeatCount >= 3;
        bool isBreatherLevel = (level % 5 == 0 || level % 10 == 0);

        float difficultyMultiplier = GetDifficultyMultiplier(level, isEasyMode, isBreatherLevel);

        // 1. Zombie Count
        zombieLevelData.zombieCount = Mathf.Clamp(8 + level * 2, 8, 60);
        Debug.Log(zombieLevelData.zombieCount);

        // 2. Health (scaled by difficulty)
        float maxHealth = 500f;
        float baseHealth = 100f;
        float normalizedLevel = Mathf.Clamp01(level / 100f); // 0 to 1
        float t = Mathf.Pow(normalizedLevel, 0.5f); // Slower curve
        float health = Mathf.Lerp(baseHealth, maxHealth, t);
        zombieLevelData.zombieHealth = Mathf.Clamp(health * difficultyMultiplier, baseHealth, maxHealth);

        // 3. Speed (scaled by difficulty)
        float baseSpeed = 2.0f + (level * 0.1f);
        if (isBreatherLevel) baseSpeed *= 0.85f;
        if (isEasyMode) baseSpeed *= 0.75f;
        zombieLevelData.zombieSpeed = Mathf.Clamp(baseSpeed * difficultyMultiplier, 2.0f, 5.5f);

        // 4. Spawn Interval (inversely affected by difficulty)
        float baseSpawn = 2f - (zombieLevelData.zombieCount * 0.025f);
        if (isBreatherLevel || isEasyMode) baseSpawn += 0.5f;
        baseSpawn /= difficultyMultiplier; // harder = faster spawn
        zombieLevelData.spawnInterval = Mathf.Clamp(baseSpawn, 0.3f, 2f);

        // 5. Wave Count (scales with level, reduced in breather/easy mode)
        int baseWaves = Mathf.Clamp(1 + (int)(level / 5f), 1, 10);
        if (isEasyMode || isBreatherLevel) baseWaves = Mathf.Max(1, baseWaves - 1);
        zombieLevelData.waveCount = baseWaves;

        // 6. Mixed Boss & Normal Zombie Logic
        if (level >= 5) // Boss zombies start appearing after level 5
        {
            bossData.bossCount = Mathf.Clamp(level / 10, 1, 5); // slowly scale boss count
            bossData.bossHealth = Mathf.Clamp(300f + level * 20f, 300f, 1000f);
            bossData.bossSpeed = Mathf.Clamp(1.2f + (level * 0.03f), 1.2f, 3.0f);
            bossData.bossSpawnInterval = Mathf.Clamp(3f + level * 0.2f, 3f, 10f);

            // Reduce regular zombie count slightly to compensate for boss difficulty
            zombieLevelData.zombieCount = Mathf.Max(6, zombieLevelData.zombieCount - bossData.bossCount);
            Debug.Log(zombieLevelData.zombieCount);
        }
        else
        {
            bossData.bossCount = 0;
            bossData.bossHealth = 0;
            bossData.bossSpeed = 0;
            bossData.bossSpawnInterval = 0;
        }

        Debug.Log($"[Level {level}] Easy: {isEasyMode} | Breather: {isBreatherLevel} | Zombies: {zombieLevelData.zombieCount} Boss: {bossData.bossCount}, HP: {zombieLevelData.zombieHealth}, Speed: {zombieLevelData.zombieSpeed}, SpawnTime: {zombieLevelData.spawnInterval}");
    }

    private float GetDifficultyMultiplier(int level, bool isEasy, bool isBreather)
    {
        if (isEasy) return 0.7f;
        if (isBreather) return .7f;
        if (level < 5) return .9f;
        if (level < 10) return 1f;
        return 1.2f + Mathf.Log(level);
    }
    #endregion
}
