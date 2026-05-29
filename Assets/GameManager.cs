using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player playerPrefab;

    public Transform spawnPoint;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("GameManager: Не назначены префаб игрока или точка спавна!");
        }
    }
}