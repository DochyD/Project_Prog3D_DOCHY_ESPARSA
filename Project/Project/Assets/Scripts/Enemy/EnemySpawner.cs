using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject prefabEnemy = default;          // Les cible que l'on spawn.
    [SerializeField] private Transform enemyParent = default;           // gameObject pour stocker les cibles

    // -- Pour gerer les affichage sur l'UI (texte nombre d'ennemies restant + text de fin de jeu)
    [SerializeField] private TMPro.TextMeshProUGUI textnbEnemy;
    [SerializeField] private TMPro.TextMeshProUGUI endText;

    // -- Reference a notre chrono / compteur d'ennemies restant.
    [SerializeField] private ChronoDisplay chrono = default;            
    [SerializeField] private EnemyCounterDisplay counter = default;
    
    // - Le nombre d'enemie qu'il y aura sur le jeu.
    private int numberOfEnemy = 20;

    // -- Valeur pour delimiter le spawn des enemies.
    private float minXZ = -100f;
    private float maxXZ = 100f;
    private float mixY = 2;
    private float maxY = 60;

    // -- Quand on lance le jeu ( On lance le chrono + compteur + spwawn enemie.
    private void OnTriggerEnter()
    {
        SpawnEnemy();
        chrono.startTimer();
        counter.startCounter();
        textnbEnemy.text = "Nombre d'énemie restant  : ";
    }

    // -- Pour faire spawn les cibles et s'assurer qu'elle ne spawnent pas n'import ou.
    private void SpawnEnemy() {
        int nbEnemies = 0;
        bool areAllEnemiesThere = false;
        while (!areAllEnemiesThere)
        {
            float x = Random.Range(minXZ, maxXZ);
            float y = Random.Range(mixY, maxY);
            float z = Random.Range(minXZ, maxXZ);

            if (!Physics.CheckSphere(new Vector3(x, y, z), 3f))
            {
                GameObject enemy = Instantiate(prefabEnemy, new Vector3(x, y, z), Quaternion.identity, enemyParent);
                nbEnemies++;
                if (nbEnemies >= numberOfEnemy) areAllEnemiesThere = true;
            }

        }
    }

    // -- Pour faire decrementer le nombre de cible. (appeller par la classe enemyBehavior.)
    // Lance la fin du jeu si plus de cible restante.
    public void enemyKilled() {
        numberOfEnemy--;
        if (numberOfEnemy == 0) {
            chrono.stopChrono();
            EndOfGame();
        }
    }

    // -- Affiche le message de fin du jeu.
    private void EndOfGame() {
        endText.text = "Toutes les cibles sont mortes. \n Temps : " + chrono.getTimer().ToString();
    }

    // -- Pour recuperer le nombre d'ennemies (sert pour le counter)
    public int getNbEnemy() {
        return numberOfEnemy;
    }
}
