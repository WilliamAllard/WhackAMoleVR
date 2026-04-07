using UnityEngine;

public class Mole : MonoBehaviour
{
    private bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isHit) return;
        
        if (other.CompareTag("Marteau"))
        {
            HandleHit(transform.position);
        }
    }

    /// <summary>
    /// Permet de Gérer dans le Marteau Frappe la Mole
    /// </summary>
    /// <param name="point"></param>
    void HandleHit(Vector3 point)
    {
        // Todo Ajouter le Système de Point
        Debug.Log("Whack !");
        
        Destroy(gameObject);
    }
}
