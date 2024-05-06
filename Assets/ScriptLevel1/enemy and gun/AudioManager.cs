using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance {  get; private set; }
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        OpenMusicSound("Topic");
        PlaySecondMusic();
        sfxSource.volume = 0.5f;
    }

    private void PlaySecondMusic()
    {
        if (sfxSounds.Length > 1)
        {
            musicSource.PlayOneShot(sfxSounds[3].audioClip);
        }
    }
    public void OpenMusicSound(string name)
    {
        foreach (Sound sound in musicSounds)
        {
            if (sound.Name == name)
            {
                musicSource.clip = sound.audioClip;
                musicSource.Play();
            }
        }
        
    }
    public void OpenSFXSound(string name)
    {
        foreach (Sound sound in sfxSounds)
        {
            if (sound.Name == name)
            {
                sfxSource.PlayOneShot(sound.audioClip);
            }
        }
    }
}
