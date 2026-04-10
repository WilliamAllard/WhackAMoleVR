using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum EtatJeu { Menu, EnJeu, GameOver }
    
    [Header("Canvas")]
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private GameObject canvasHUD;
    [SerializeField] private GameObject canvasGameOver;
    
    private EtatJeu etatActuel;
    
    [Header("Mole")]
    public GameObject molePrefab; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 2.0f;
    public float vieDeLaMole = 1.5f; 
    
    [Header("TextJeu")]
    public TMP_Text timerTextJeu;
    public TMP_Text scoreTextJeu;
    public TMP_Text moleTextJeu;
    
    [Header("TextFin")]
    public TMP_Text timerTextFin;
    public TMP_Text scoreTextFin;
    public TMP_Text moleTextFin;
    
    private bool timerActif;
    private float timer;

    private int scoreFinal = 0;
    private int moleToucher = 0 ;
    
    /// <summary>
    /// Singleton
    /// </summary>
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    /// <summary>
    /// État de Base
    /// </summary>
    private void Start()
    {
        ChangerEtat(EtatJeu.Menu);
    }
    
    /// <summary>
    /// Permet le Changement d'état du Enum
    /// </summary>
    /// <param name="nouvelEtat">Le Nouvel état que le Jeu veux aller</param>
    public void ChangerEtat(EtatJeu nouvelEtat)
    {
        etatActuel = nouvelEtat;
        canvasMenu.SetActive(etatActuel == EtatJeu.Menu);
        canvasHUD.SetActive(etatActuel == EtatJeu.EnJeu);
        canvasGameOver.SetActive(etatActuel == EtatJeu.GameOver);
    }
    
    /// <summary>
    /// Update du Timer, à 0 float ses la fin du jeu
    /// </summary>
    private void Update()
    {
        if (timerActif)
        {
            timer -= Time.deltaTime;
            AfficherTimer();
            if (timer <= 0)
            {
                FinPartie();
            }
        }
    }
    
    /// <summary>
    /// Permet de Commencer le Jeu
    /// </summary>
    public void CommencerJeu()
    {
        StartCoroutine(SpawnRoutine());
        timer = 30;
        timerActif = true;
        AfficherTimer();
        ChangerEtat(EtatJeu.EnJeu);
        scoreFinal = 0;
        scoreTextJeu.text = "Score : " + scoreFinal;
        moleToucher = 0;
        moleTextJeu.text = "Taupe Toucher : " + moleToucher;
    }


    /// <summary>
    /// Coroutine pour l'apparition des Taupes
    /// </summary>
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

    /// <summary>
    /// Permet l'ajout de score/taupe et Update le Texte
    /// </summary>
    /// <param name="score"></param>
    public void AddScore(int score)
    {
        scoreFinal = scoreFinal + score;
        scoreTextJeu.text = "Score : " + scoreFinal;
        moleToucher = moleToucher + 1;
        moleTextJeu.text = "Taupe Toucher : " + moleToucher;
    }

    /// <summary>
    /// Permet de gérée la fin de la partie
    /// </summary>
    private void FinPartie()
    {
        StopAllCoroutines();
        timerTextFin.text = "Fin de la Partie !";
        scoreTextFin.text = "Score Final : " + scoreFinal;
        moleTextFin.text = "Total Taupe Toucher : " + moleToucher;
        Marteau.Instance.Vibration(0.5f, 0.2f);
        ChangerEtat(EtatJeu.GameOver);
    }
    
    /// <summary>
    /// Update le Timer
    /// </summary>
    private void AfficherTimer()
    {
        timerTextJeu.text = "Temps Restant : " + timer.ToString("F2");
    }
    
    /// <summary>
    /// Pour rejouer
    /// </summary>
    public void Rejouer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }

    /// <summary>
    /// Alt-F4
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }
}
