using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSoundEffect : MonoBehaviour
{
    public static ShipSoundEffect instance;
    public AudioSource audioSource;

    public AudioClip shootSound;
    public AudioClip explosioinSound;

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
        this.audioSource = this.GetComponent<AudioSource>();
        this.shootSound = Resources.Load<AudioClip>("Assets/SFX/ShootSound.wav");
        this.explosioinSound = Resources.Load<AudioClip>("Assets/SFX/ExplosionSound.mp3");
        this.enemyShootSound = Resources.Load<AudioClip>("Assets/SFX/EnemyShootSound.wav");
        this.bossShootSound = Resources.Load<AudioClip>("Assets/SFX/BossShootSound.wav");
        this.equipSound = Resources.Load<AudioClip>("Assets/SFX/EquipSound.wav");
        this.unequipSound = Resources.Load<AudioClip>("Assets/SFX/UnequipSound.wav");
    }

    public void PlayShootSound()
    {
        this.audioSource.PlayOneShot(this.shootSound);
    }

    public void PlayExplosionSound()
    {
        this.audioSource.PlayOneShot(this.explosioinSound);
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
