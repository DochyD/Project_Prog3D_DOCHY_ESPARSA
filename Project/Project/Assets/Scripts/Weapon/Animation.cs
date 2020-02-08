using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    public void fireAnimation() {
        anim.SetBool("canShoot", true);
        
        anim.SetBool("canShoot", false);
    }
}
