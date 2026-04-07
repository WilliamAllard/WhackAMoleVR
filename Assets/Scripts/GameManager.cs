using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject molePrefab; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 2.0f;
    public float vieDeLaMole = 1.5f; 

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    /// <summary>
    /// Coroutine pour l'apparition des Taupes
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            
            Transform targetPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
            GameObject newMole = Instantiate(molePrefab, targetPoint.position, targetPoint.rotation);
            
            Destroy(newMole, vieDeLaMole);
        }
    }
}
