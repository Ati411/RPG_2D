using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen; // ตัวแปรสำหรับเก็บ Panel ของเรา

    // ฟังก์ชันสำหรับแสดงหน้า Game Over
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    // ฟังก์ชันสำหรับปุ่ม Restart
    public void RestartGame()
    {
        // โหลด Scene ปัจจุบันใหม่
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ฟังก์ชันสำหรับปุ่ม Quit
    public void QuitGame()
    {
        Debug.Log("Quitting game..."); // แสดงใน Console ตอนเทสใน Editor
        Application.Quit();
    }
}
