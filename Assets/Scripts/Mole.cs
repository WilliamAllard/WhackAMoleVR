using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mole : MonoBehaviour
{
    private bool isHit = false;

    public int pointParHit = 10;

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
        GameManager.Instance.addScore(pointParHit);
        Debug.Log("Whack !");
        
        Destroy(gameObject);
    }
}
