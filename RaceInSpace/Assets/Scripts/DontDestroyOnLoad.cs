using UnityEngine;

public class DontDestroyOnLoadMusic : MonoBehaviour
{
    public static DontDestroyOnLoadMusic instance;
    public static AudioSource MainMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            MainMusic = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
