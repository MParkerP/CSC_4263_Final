using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip correct;
    [SerializeField] AudioClip incorrect;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip countDownMusic;
    [SerializeField] AudioClip whipSound;
    [SerializeField] AudioClip gameMusic;
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
    public void PlayMenuMusic()
    {
        audioSource.loop = true;
        StartCoroutine(MenuMusic());
    }
    public void PlayCountDownMusic()
    {
        audioSource.loop = true;
        StartCoroutine(CountDownMusic());
    }
    public void PlayWhipSound()
    {
        audioSource.clip = whipSound;
        audioSource.Play();
    }
    public void PlayGameMusic()
    {
        audioSource.loop = true;
        StartCoroutine(GameMusic());
    }
    public void StopMusic()
    {
        audioSource.loop = false;
        audioSource.Stop();
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
    IEnumerator MenuMusic()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = menuMusic;
        audioSource.Play();
    }
    IEnumerator CountDownMusic()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = countDownMusic;
        audioSource.Play();
    }
    IEnumerator GameMusic()
    {
        yield return new WaitForSeconds(0);
        audioSource.clip = gameMusic;
        audioSource.Play();
    }
}
