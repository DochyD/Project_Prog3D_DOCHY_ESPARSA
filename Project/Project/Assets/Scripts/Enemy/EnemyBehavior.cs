using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -- Comportement des ennemies ( leur mort)

public class EnemyBehavior : MonoBehaviour
{
    public Transform particleEffectHolder;                  // Pour stocker les info temporairement
    [SerializeField] private ParticleSystem deathEffect;    // Recuperer l'animation de mort
    

    // Fonction que l'on appelle si jamais une cible meurt
    public void Death(Vector3 hitPoint, Vector3 direction)
    {
        gameObject.GetComponent<AudioSource>().Play(); // On joue le son de mort de l'enemie
        ParticleSystem effect = Instantiate(deathEffect, hitPoint, Quaternion.FromToRotation(Vector3.forward, -direction), particleEffectHolder);
        Destroy(effect.gameObject, 1f); // On detruit le gameObject de l'effet au bout d'une seconde
        Destroy(gameObject, 0.4f);      // On detruit la cible
        
    }

}
