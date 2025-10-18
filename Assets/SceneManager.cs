using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void ChangeLevel(string lvlToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
