using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}