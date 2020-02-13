using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    // -- References


    [SerializeField] private GameObject prefabEnemy = default;      // L'enemie que l'on fera spawn       
    [SerializeField] private Transform enemyParent = default;       // Holder pour les ennemies
    [SerializeField] private GameManager gameManager = default;     // Reference au gameManager ( gestion chrono + compteur ennemies)


    // -- Données pour le spawner                
    private float minXZ = -100f;                                    //Valeur pour delimiter le spawn des enemies
    private float maxXZ = 100f;
    private float mixY = 2;
    private float maxY = 60;

    // -- Quand on lance le jeu ( On lance le chrono + compteur + spwawn enemie.
    private void OnTriggerEnter()
    {
        if (!gameManager.gameStarted) {
            SpawnEnemy();
            gameManager.StartGame();
        }
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
                if (nbEnemies >= gameManager.numberOfEnemy) areAllEnemiesThere = true;
            }

        }
    }


    
}
