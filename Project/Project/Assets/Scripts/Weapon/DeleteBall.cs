using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBall : MonoBehaviour
{

    // We destroy every ball 10 seconds after they've been fired.
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
