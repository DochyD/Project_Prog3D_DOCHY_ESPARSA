using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private float minXZ = -100f;
    private float maxXZ = 100f;
    private float mixY = 2;
    private float maxY = 60;


    [SerializeField] private GameObject prefabEnemy = default;
    [SerializeField] private Transform enemyParent = default;
    [SerializeField] private Transform enemyHolder = default;
    [SerializeField] private float spawnLimit = 20f;



    [SerializeField] private float spawningRate = 0.3f;
    
    
    private void Awake()
    {
        //StartCoroutine(Spawner());
        SpawnEnemy();
    }

    //Enemy will spawn on a 2D plane in a 3D world
    private IEnumerator Spawner()
    {

        while (true)
        {
            float numberEnemy = enemyHolder.childCount; 
            if (numberEnemy < spawnLimit) //To check they aren't too many enemies
            {
                yield return new WaitForSeconds(1F / spawningRate);           
                
                GameObject enemy = Instantiate(prefabEnemy, new Vector3(Random.Range(minXZ, maxXZ), Random.Range(mixY, maxY), Random.Range(minXZ, maxXZ)), Quaternion.identity, enemyParent);
                enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                // We freeze position so enemy won't fall after spawning.
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
            }
        }
        
    }

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
                if (nbEnemies >= spawnLimit) areAllEnemiesThere = true;
            }

        }
    }

}
