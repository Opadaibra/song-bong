
using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManger : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManger instance;
 
    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        play("Theme");
    }
    public void play(String name)
    {
        Sound s=Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("This Sound" + name + "is not found");
            return;
        }
        else
        {
            s.source.Play();
        }
    }
    public void mute(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("This Sound" + name + "is not found");
            return;
        }
        else
        {
            s.source.volume = 0; 
        }
    }
    public void Unmute(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("This Sound" + name + "is not found");
            return;
        }
        else
        {
            s.source.volume = 0.1f;
        }
    }
    
    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("This Sound" + name + "is not found");
            return;
        }
        else
        {
            s.source.Stop();
        }
    }


}
