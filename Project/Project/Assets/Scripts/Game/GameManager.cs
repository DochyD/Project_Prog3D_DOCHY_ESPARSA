using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // -- Global Attributs
    public static GameManager instance { get; private set; }
    [System.NonSerialized] public bool gameStarted = false;
    [SerializeField] public int numberOfEnemy = 20;                // Nombre d'ennemies a instancier 

    // -- Manage chrono
    [SerializeField] private TMPro.TextMeshProUGUI chronoDisplay = default;
    private float chrono = default;

    // -- Manage enemy counter
    [SerializeField] private TMPro.TextMeshProUGUI enemyCounter = default;
    [SerializeField] private TMPro.TextMeshProUGUI textnbEnemy = default;

    // -- To Display the message at the end of the game
    [SerializeField] private TMPro.TextMeshProUGUI endText = default;



    // -- Global Method

    //On lance le jeu (chrono + counter)
    public void StartGame() {
        gameStarted = true;
        textnbEnemy.text = "Nombre d'énemie restant  : ";
        startTimer();
        startCounter();
    }

    // Fin du jeu
    public void EndGame()
    {
        gameStarted = false;
        endText.text = "Toutes les cibles sont mortes. \n Temps : " + getTimer().ToString() + "\n Escape to quit";
    }

    // -- Counter Methods
    private void startCounter()
    {
        StartCoroutine(Counter());
    }

    private IEnumerator Counter()
    {
        while (gameStarted)
        {
            yield return new WaitForEndOfFrame();
            enemyCounter.text = GetNbEnemy().ToString();

        }


    }


    // -- Chrono Methods

    private void startTimer()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (gameStarted)
        {
            yield return new WaitForEndOfFrame();
            chrono += Time.deltaTime;
            chronoDisplay.text = Mathf.Floor(chrono / 60) + " : " + Mathf.RoundToInt(chrono % 60);
        }


    }

    public float getTimer()
    {
        return chrono;
    }



    // -- Pour faire decrementer le nombre de cible. (appeller par la classe enemyBehavior.)
    // Lance la fin du jeu si plus de cible restante.
    public void EnemyKilled()
    {
        numberOfEnemy--;
        if (numberOfEnemy == 0)
        {
            EndGame();
        }
    }

    // -- Pour recuperer le nombre d'ennemies (sert pour le counter)
    public int GetNbEnemy()
    {
        return numberOfEnemy;
    }

}
