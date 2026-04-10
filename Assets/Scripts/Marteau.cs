using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class Marteau : MonoBehaviour
{
    public static Marteau Instance;
    
    public HapticImpulsePlayer manetteGauche;
    public HapticImpulsePlayer manetteDroite;
    
    /// <summary>
    /// Singleton
    /// </summary>
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    /// <summary>
    /// Permet de Gére le Trigger du Marteau
    /// </summary>
    /// <param name="other">L'autre Trigger</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mole")) 
        {
            Vibration(0.5f, 0.2f);
        }
    }

    /// <summary>
    /// Appel les Vibrations des manettes
    /// </summary>
    /// <param name="amplitude">Amplitude</param>
    /// <param name="duration">La Durée</param>
    public void Vibration(float amplitude, float duration)
    {
        manetteGauche.SendHapticImpulse(amplitude, duration);
        manetteDroite.SendHapticImpulse(amplitude, duration);
    }
}