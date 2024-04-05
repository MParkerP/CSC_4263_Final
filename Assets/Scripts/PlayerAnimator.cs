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

    public void Die()
    {
        playerAn.SetTrigger("Die");
    }

    public void StartPlayerShoot()
    {
        StartCoroutine(playerShoot());
    }

    public void StartPlayerDeath()
    {
        StartCoroutine(playerDeath());
    }

    IEnumerator playerShoot()
    {
        Shoot();
        yield return new WaitForSeconds(2);
        Idle();
    }

    IEnumerator playerDeath()
    {
        yield return new WaitForSeconds(0.5f);
        Die();
        yield return new WaitForSeconds(5);
        Idle();
    }

}


