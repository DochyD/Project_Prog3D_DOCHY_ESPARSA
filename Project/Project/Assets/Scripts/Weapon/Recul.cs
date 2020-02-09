using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recul : MonoBehaviour
{
    Animator anim;
    private float lastTrigger;
    void Awake()
    {
        
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void fireAnimation() {
        lastTrigger = Time.time;

        anim.SetTrigger("shoot");
    }
}
