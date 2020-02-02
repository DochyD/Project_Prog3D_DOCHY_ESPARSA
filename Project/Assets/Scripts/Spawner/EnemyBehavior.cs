using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    //private LayerMask maskProjectile = default;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private float duration = 3;

    private bool isTouched = false;

    private void OnCollisionEnter(Collision collision)
    {
        //Check that the enemy is touched by a ball +( not touched before to not trigger animation many times)
        if (!isTouched && collision.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            isTouched = true;
            Destroy(gameObject, 3f);
            Destroy(collision.gameObject, 10f);
            //StartCoroutine(Death());
        }
    }

    //Animation of death ( from color white to red in 3 secondes)
    public void Death()
    {
        Destroy(gameObject);
    }

}
