using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentLevelIndex = 0;
    public void LoadNextLevel()
    {
        Debug.Log("Load next level");

        SceneManager.LoadScene(currentLevelIndex + 1);
    }
}
