using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    AudioSource audioSource;
    void Awake()
    {
        // Ensure only one instance of MusicManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scene changes
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Play music here (optional)
        PlayMusic();
    }

    void Update(){
        Scene currentScene = SceneManager.GetActiveScene();
    if (currentScene.name == "MainMenu" || currentScene.name == "csChar" || currentScene.name == "ending")
    {
        // Destroy(gameObject);
        audioSource.volume = 0;
    }
    }

    public void PlayMusic()
    {
        // Get the Audio Source component and play music
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
