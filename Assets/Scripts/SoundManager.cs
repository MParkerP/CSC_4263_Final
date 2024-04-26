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
    [SerializeField] AudioClip pauseSound;

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

    public void PlayButtonHover()
    {
        audioSource.PlayOneShot(correct);
    }

    public void PlayPause()
    {
        audioSource.PlayOneShot(pauseSound);
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(whipSound);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correct);
    }
    public void PlayIncorrectSound()
    {
        audioSource.PlayOneShot(incorrect);
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
        audioSource.PlayOneShot(whipSound);
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
