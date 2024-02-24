using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.pitch = s.pitch;
        }
    }
    public void Play(string name)
    {
        Sounds s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sounds s = System.Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void Mute()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = 0;
        }
    }
    public void Unmute()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = 0.5f;
        }
    }
}
