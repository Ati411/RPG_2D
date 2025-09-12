using UnityEngine;
using UnityEngine.UI;

public class PlayCollectibles : MonoBehaviour
{
    public Text textComponent;
    public int gemNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
    }
    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }
    public void GemCollected()
    {
        gemNumber++;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
