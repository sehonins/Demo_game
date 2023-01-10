using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    int _sceneCount;

    private void Start()
    {
        _sceneCount = SceneManager.sceneCountInBuildSettings;

        EnemySpawner enemyspawner = FindObjectOfType<EnemySpawner>();
        if (enemyspawner != null)
            enemyspawner.AllEnemiesDied += OnAllEnemiesDied;
    }

    public void OnAllEnemiesDied(object source, EventArgs e)
    {
        LoadNexeScene();
    }


    public void StartGame()
    {
        StartCoroutine(LoadScene(1));
    }
    public void LoadNexeScene()
    {   
        
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (_sceneCount > nextScene)
            StartCoroutine(LoadScene(nextScene));
        else
        {
            print("Last scene");
            StartCoroutine(LoadScene(0));
        }
            
    }
    IEnumerator  LoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
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
