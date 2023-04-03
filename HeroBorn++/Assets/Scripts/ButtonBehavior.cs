using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void RestartGame()
    {
        /*
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        */
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
