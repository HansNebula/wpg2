using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

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
        // Play music here (optional)
        PlayMusic();
    }

    void Update(){
        Scene currentScene = SceneManager.GetActiveScene();
    if (currentScene.name == "MainMenu" || currentScene.name == "csChar" || currentScene.name == "ending")
    {
        Destroy(gameObject);
    }
    }

    public void PlayMusic()
    {
        // Get the Audio Source component and play music
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
