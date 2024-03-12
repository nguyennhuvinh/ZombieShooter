using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------ Audio Clip ------")]
    public AudioClip background;
    public AudioClip Shoot;
    public AudioClip PlayerGrunt;
    public AudioClip Zdeath;
    public AudioClip AssaulReload;
    public AudioClip HealthBell;


    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlaySoundShoot()
    {
        PlaySFX(Shoot);
    }
    public void PlayeSoundHealthBell()
    {
        PlaySFX(HealthBell);
    }

    public void PlaySoundPlayerGrunt()
    {
        PlaySFX(PlayerGrunt);
    }
    public void PlayeSoundAssaulReload()
    {
        PlaySFX(AssaulReload);
    }
    public void PlayeSoundZdead()
    {
        PlaySFX(Zdeath);
    }
}
