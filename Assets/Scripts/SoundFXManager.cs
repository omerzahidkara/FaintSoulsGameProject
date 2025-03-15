
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    public float clipLength;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahne de�i�ti�inde kaybolmas�n
        }
        else
        {
            Destroy(gameObject); // E�er zaten varsa, yeni olu�an� yok et
        }
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        // spawn in gameobject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        if (audioClip != null)
        {
            //assign the audioClip
            audioSource.clip = audioClip;

            //assign volume
            audioSource.volume = volume;

            //play
            if (!audioSource.isPlaying && audioSource != null)
            {
                audioSource.Play();
            }
            //get lenght of sound FX clip
            clipLength = audioSource.clip.length;
        }

        //die
        Destroy(audioSource.gameObject,clipLength);

    }
}
