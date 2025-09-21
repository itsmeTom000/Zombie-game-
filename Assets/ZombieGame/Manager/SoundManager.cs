using System.ComponentModel;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Public_Variable
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; 
    [SerializeField] private AudioSource sfxSource;   
    [SerializeField] private AudioSource victorySource;   
    [SerializeField] private AudioSource damageSource;   
    [SerializeField] private AudioSource firinigSource;   

    [Header("Audio Clips")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip buttonSfx;
    [SerializeField] private AudioClip victoryMusic;
    [SerializeField] private AudioClip damageMusic;
    [SerializeField] private AudioClip firingMusic;
    #endregion

    #region Unity_Callbacks
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Play_Music
    public void PlayMusic()
    {
        if (GameManager.Instance.uiData.savedUIData.settingData.music)
        {
            if (musicSource != null && backgroundMusic != null)
            {
                musicSource.clip = backgroundMusic;
                musicSource.volume = 0.7f;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }
    #endregion

    #region Pause_Music
    public void StopMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
    #endregion

    #region Play_Sfx
    public void PlaySfx()
    {
        if (GameManager.Instance.uiData.savedUIData.settingData.sfx)
        {
            if (sfxSource != null && buttonSfx != null)
            { 
                sfxSource.PlayOneShot(buttonSfx);
            }
        }
    }
    #endregion

    #region Play_VictorySound
    public void PlayVictorySound()
    {
        if (victorySource != null && victoryMusic != null)
        {
            victorySource.PlayOneShot(victoryMusic);
        }
    }
    #endregion

    #region Play_VictorySound
    public void PlayDamageSound()
    {
        if (damageSource != null && damageMusic != null)
        {
            damageSource.PlayOneShot(damageMusic);
        }
    }
    #endregion

    #region Play_VictorySound
    public void PlayFiringSound()
    {
        if (firinigSource != null && firingMusic != null)
        {
            firinigSource.PlayOneShot(firingMusic);
        }
    }
    #endregion

    #region Vibration
    public void Vibration()
    {
        if(GameManager.Instance.uiData.savedUIData.settingData.vibration)
        {

        }
    }
    #endregion
}
