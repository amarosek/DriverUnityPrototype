using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] Canvas menuCanvas;

    bool paused = false;
    
    void Start()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    
    void Update()
    {
        OpenMenu();
    }

    private void OpenMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Time.timeScale = 1.0f;
                menuCanvas.gameObject.SetActive(false);
                paused = false;
            }
            else
            {
                Time.timeScale = 0f;
                menuCanvas.gameObject.SetActive(true);
                paused = true;

            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        menuCanvas.gameObject.SetActive(false);
        Cursor.visible = false;
        paused = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
