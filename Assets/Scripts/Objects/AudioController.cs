using UnityEngine;
using UnityEngine.Events;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;

    public UnityEvent OnSoundStarted;

    /// <summary>
    /// Plays the given audio with duration
    /// </summary>
    /// <param name="playDuration">Duration of the played audio</param>
    public void PlayAudio(float playDuration)
    {
        OnSoundStarted.Invoke();
        foreach (AudioSource source in sources)
            source.Play();
        Invoke(nameof(StopAudio), playDuration);
    }

    public void StopAudio()
    {
        foreach (AudioSource source in sources)
            source.Stop();
    }
}