using UnityEngine;

public class Marteau : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mole")) 
        {
            Vibration();
        }
    }

    void Vibration()
    {
        // TODO
    }
}