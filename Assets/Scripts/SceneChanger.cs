using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Button trainingGroundButton;
    [SerializeField] Button inGameButton;
    [SerializeField] Button exitGameButton;

    private void Start()
    {
        if (trainingGroundButton != null)
        {
            trainingGroundButton.onClick.AddListener(() => GoToTrainingGround("Training Ground"));
        }

        if (inGameButton != null)
        {
            inGameButton.onClick.AddListener(() => GoToInGame("Game"));
        }

        if(exitGameButton != null)
        {
            exitGameButton.onClick.AddListener(() => ExitGame());
        }
    }

    public void GoToTrainingGround(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToInGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
