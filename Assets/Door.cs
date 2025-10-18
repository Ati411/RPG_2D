using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int lvlToLoad;

    private void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }
     private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            other.GetComponent<Gatherinput>().DisableControls();
            LoadLevel();
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
