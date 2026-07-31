using TMPro;
using UnityEngine;

public class BestTime : MonoBehaviour
{
    TMP_Text canvasText;
    [SerializeField] string ScoreKey;
    [SerializeField] float devTime;

    private void Awake()
    {
        canvasText = GetComponent<TMP_Text>();
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasText.text = PlayerPrefs.GetFloat(ScoreKey, devTime).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
