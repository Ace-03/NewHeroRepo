using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
