using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] AudioSource mainMusic;


    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        mainMusic.volume = 0.02f;
    }


    public void ExitGame()
    {
        Application.Quit();  
    }
}
