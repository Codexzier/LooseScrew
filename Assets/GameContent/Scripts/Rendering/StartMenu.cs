using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartGame()
    {
        SceneManager.LoadScene("GameContentScence");
    }
}
