using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSoundEffect : MonoBehaviour
{
    public static ShipSoundEffect instance;
    public AudioSource audioSource;

    public AudioClip shootSound;
    public AudioClip expplosioinSound;

    public AudioClip enemyShootSound;
    public AudioClip bossShootSound;
    public AudioClip equipSound;
    public AudioClip unequipSound;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        this.audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayShootSound()
    {
        this.audioSource.PlayOneShot(this.shootSound);
    }

    public void PlayExplosionSound()
    {
        this.audioSource.PlayOneShot(this.expplosioinSound);
    }

    public void PlayEquipSound()
    {
        this.audioSource.PlayOneShot(this.equipSound);
    }

    public void PlayUnequipSound()
    {
        this.audioSource.PlayOneShot(this.unequipSound);
    }

    public void PlayEnemyShootSound()
    {
        this.audioSource.PlayOneShot(this.enemyShootSound);
    }

    public void PlayBossShootSound()
    {
        this.audioSource.PlayOneShot(this.bossShootSound);
    }

    public void pauseSound()
    {
        this.audioSource.Pause();
    }

    public void unPauseSound()
    {
        this.audioSource.UnPause();
    }


}
