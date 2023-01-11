using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // !!!!!!! HARUS DIPLAY DARI SCENE MAIN MENU ATAU NANTI AKAN ERROR NULL REFERENCE JIKA INGIN MUNCUL AUDIO
    
    public Sound[] sounds;

    private void Start()
    {
        Play("bg");
    }
    
    private void Awake()
    {
        GameObject audioManager = GameObject.Find("AudioManager");
        if (audioManager != null && audioManager != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
}
