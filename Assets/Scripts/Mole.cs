using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Mole : MonoBehaviour
{
    private bool isHit = false;

    public int pointParHit = 10;
    
    [Header("Audio")]
    [SerializeField] private AudioClip sonWhack;
    
    private AudioSource audioSource;
    
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Permet de Gére le Trigger de La Taupe
    /// </summary>
    /// <param name="other">L'autre Trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;
        
        if (other.CompareTag("Marteau"))
        {
            HandleHit();
        }
    }

    /// <summary>
    /// Permet de Gérer dans le Marteau Frappe la Mole
    /// </summary>
    void HandleHit()
    {
        GameManager.Instance.AddScore(pointParHit);
        
        Debug.Log("Whack !");
        
        audioSource.PlayOneShot(sonWhack);
        
        Destroy(gameObject);
        
    }
}
