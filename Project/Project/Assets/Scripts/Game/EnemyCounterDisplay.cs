using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI enemyCounter;
    [SerializeField] private EnemySpawner nbOfEnemy;
    [System.NonSerialized] public bool gameStarted = false;

    public void startCounter()
    {
        gameStarted = true;
        StartCoroutine(Counter());
    }

    private IEnumerator Counter()
    {
        while (gameStarted)
        {
            yield return new WaitForEndOfFrame();
            enemyCounter.text = nbOfEnemy.getNbEnemy().ToString();

        }


    }

}
