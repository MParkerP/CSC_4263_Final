using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip correct;
    [SerializeField] AudioClip incorrect;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("s"))
        {
            PlayCorrectSound();
        }
    }

    public void PlayCorrectSound()
    {
        StartCoroutine(CorrectSound());
    }
    public void PlayIncorrectSound()
    {
        StartCoroutine(IncorrectSound());
    }
    IEnumerator CorrectSound()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = correct;
        audioSource.Play();
    }

    

    IEnumerator IncorrectSound()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = incorrect;
        audioSource.Play();
    }
}
