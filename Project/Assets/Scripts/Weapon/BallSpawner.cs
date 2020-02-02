using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab = default;               
    [SerializeField] private Transform ballsParentTransform = default; // To 'stock' our instanciated prefab
    [SerializeField] private float spawningForce = 5000f;
    private Transform cameraTransform;


    private void Awake()
    {
        cameraTransform = transform;
        //StartCoroutine(DoSpawnBall());

    }


    public void Spawnball()
    {
        GameObject ball = Instantiate(prefab, cameraTransform.position, Quaternion.identity, ballsParentTransform);
        ball.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * spawningForce);

    }
}
