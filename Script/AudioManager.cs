using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //without it, the script has nothing in the inspector
public class Sound {
    public string   name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(0f, 2f)]
    public float pitch = 1f;

    public bool loop = false;
    public bool playOnAwake = false;
    private bool isPlaying;
    private AudioSource source;

    public void SetSource(AudioSource _source) {  // fazer variaveis representar atributos do audioSource
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.playOnAwake = playOnAwake;
    }
    public void playAudio() {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
    public void stopAudio() {
        source.Stop();
    }
    public void pauseAudio() {
        source.Pause();
    }
    public void unpauseAudio() {
        source.UnPause();
    }
    public void playOneShot() { //preguiça de fazer um metodo para o tiro
        source.volume = volume;
        source.pitch = pitch;
        //source.PlayOneShot(AudioClip,float);
    }
    public void playDelayedAudio(){
        source.volume = volume;
        source.pitch = pitch;
        source.PlayDelayed(0.5f);
    }
}



public class AudioManager : MonoBehaviour {

    public static AudioManager instance;

    private void Awake(){
        if (instance != null) {
            Debug.LogError("More than one AudioManager in the scene SKRT");

            if (instance != this) {
                Destroy(this.gameObject);
            }
        }else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    [SerializeField] Sound[] sounds;

    private void Start(){
        for (int i = 0; i < sounds.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name); //store the audios
            _go.transform.SetParent(this.transform); //makes it organized on the hierarchy
            sounds[i].SetSource(_go.AddComponent<AudioSource>()); // it makes the audioClip plays on AudioSource
        }
    }

    public void playSound(string _name) {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].playAudio();
                return;
            }
        }
        Debug.LogWarning("(playSound)AudioManager: Sound not found in sound list, " + _name);
    }
    public void playDelayedSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].playDelayedAudio();
                return;
            }
        }
        Debug.LogWarning("(playDelayedSound)AudioManager: Sound not found in sound list, " + _name);
    }

    public void pauseSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].pauseAudio();
                return;
            }
        }
        Debug.LogWarning("(pauseSound)AudioManager: Sound not found in sound list, " + _name);
    }
    public void unpauseSound(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].unpauseAudio();
                return;
            }
        }
        Debug.LogWarning("(unpauseSound)AudioManager: Sound not found in sound list, " + _name);
    }
}
