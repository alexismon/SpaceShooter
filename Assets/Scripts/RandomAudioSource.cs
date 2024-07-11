using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioSource : MonoBehaviour
{
    public AudioClip[] audioClips; // Array of audio clips to choose from
    public AudioSource audioSource; // Reference to the specified AudioSource component

    void Awake()
    {
        // If no AudioSource is specified, get the first AudioSource attached to the GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Ensure there is at least one audio clip in the array
        if (audioClips == null || audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips assigned to the RandomAudioSource script on " + gameObject.name);
        }
    }

    void Start()
    {
        // Check if playOnAwake is enabled and play a random clip
        if (audioSource.playOnAwake)
        {
            Play();
        }
    }

    // Method to play a random clip
    public void Play()
    {
        if (audioClips.Length > 0)
        {
            // Pick a random clip from the array
            AudioClip clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
            // Play the selected clip
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clips available to play on " + gameObject.name);
        }
    }

    // Method to play a random clip with a delay
    public void PlayDelayed(float delay)
    {
        if (audioClips.Length > 0)
        {
            AudioClip clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.clip = clipToPlay;
            audioSource.PlayDelayed(delay);
        }
        else
        {
            Debug.LogWarning("No audio clips available to play on " + gameObject.name);
        }
    }

    // Method to play a random clip once
    public void PlayOneShot()
    {
        if (audioClips.Length > 0)
        {
            AudioClip clipToPlay = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.PlayOneShot(clipToPlay);
        }
        else
        {
            Debug.LogWarning("No audio clips available to play on " + gameObject.name);
        }
    }

    // You can add more methods to override other AudioSource methods if needed
}
