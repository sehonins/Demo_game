using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    int _sceneCount;

    private void Start()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadNexeScene()
    {   
        
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (_sceneCount > nextScene)
            SceneManager.LoadScene(nextScene);
        else
            print("Last scene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        print("Exit");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            LoadMainMenu();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            LoadNexeScene();
        }
    }
}
