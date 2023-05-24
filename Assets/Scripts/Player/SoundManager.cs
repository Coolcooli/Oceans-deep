using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private AudioSource[] loopSounds;
    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    public AudioSource Sound => audioSources["movementSound"];

    private void Start(){
        StoreSounds();
    }

    /// <summary>
    /// function that sets the items from the array in a dictionary on file name index
    /// </summary>
    private void StoreSounds(){
        foreach (AudioSource sound in sounds)
            audioSources.Add(sound.name, sound);

        foreach (AudioSource sound in loopSounds){
            audioSources.Add(sound.name, sound);
            StopLoop(sound.name);
        }

    }

    /// <summary>
    /// plays a sound
    /// </summary>
    /// <param name="name">the name of the sound</param>
    public void Play(string name)
    {
        AudioSource audio = audioSources[name];

        if(!CheckSound(audio, false)){
            Debug.LogError(name + "is not the right sound type, use Startloop() instead");
            return;
        }

        audio.Play();
    }

    /// <summary>
    /// stops a sound
    /// </summary>
    /// <param name="name">name of the sound</param>
    public void Stop(string name){
        AudioSource audio = audioSources[name];

        if(!CheckSound(audio, false)){
            Debug.LogError(name + "is not the right sound type, use Stoploop() instead");
            return;
        }
        audio.Stop();
    }


    /// <summary>
    /// activates a loop sound
    /// </summary>
    /// <param name="name">name of the loopsound</param>
    public void StartLoop(string name){

        AudioSource audio = audioSources[name];
        if(!CheckSound(audio, true)){
            Debug.LogError(name + "is not the right sound type, use Start() instead");
            return;
        }
        audio.gameObject.SetActive(true);
    }

    /// <summary>
    /// deactivates a loop sound
    /// </summary>
    /// <param name="name">name of the loopsound</param>
    public void StopLoop(string name){

        AudioSource audio = audioSources[name];
        if(!CheckSound(audio, true)){
            Debug.LogError(name + "is not the right sound type, use Stop() instead");
            return;
        }
        audio.gameObject.SetActive(false);

    }


    /// <summary>
    /// checks if an audio is started/stopped the right way
    /// </summary>
    /// <param name="audio">the audio that needs to be checked</param>
    /// <param name="isLoop">is the audio an loop</param>
    /// <returns>true if the sound is called the right way</returns>
    private bool CheckSound(AudioSource audio, bool isLoop){
        if(isLoop)
            return loopSounds.Contains(audio);
        return sounds.Contains(audio);
    }

    /// <summary>
    /// checks if a specific audio is playing
    /// </summary>
    /// <param name="name">name of the audio source</param>
    /// <returns>whether the audio is playing or not, returns false and a warning when not found </returns>
    public bool isPlaying(string name){
        AudioSource audio = audioSources[name];
        if (audio == null)
        {
            Debug.LogWarning("audio " + name + " doesn't exist so it can't be playing");
            return false;
        }

        if(sounds.Contains(audio))
            return audioSources[name].isPlaying;

        return audio.gameObject.activeSelf;
    }

}
