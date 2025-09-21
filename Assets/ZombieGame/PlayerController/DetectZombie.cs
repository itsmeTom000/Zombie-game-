using System.Collections.Generic;
using UnityEngine;

public class DetectZombie : MonoBehaviour
{
    public static DetectZombie Instance { get; set; }
    public List<Transform> enemyList = new();
    void Awake()
    {
        Instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            enemyList.Add(other.gameObject.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            enemyList.Remove(other.gameObject.transform);
        }
    }
}
