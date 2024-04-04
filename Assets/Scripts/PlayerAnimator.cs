using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator playerAn;
    // Start is called before the first frame update
    void Start()
    {
        playerAn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        playerAn.SetTrigger("Shoot");
    }

    public void Idle()
    {
        playerAn.SetTrigger("Idle");
    }
}
