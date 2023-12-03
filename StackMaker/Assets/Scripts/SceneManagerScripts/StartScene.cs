using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    private string ingameSceneName = "InGameScene";
    void Start(){
        Time.timeScale = 1f;
        GameManager.level = 0;
        PlayerPrefs.SetInt("level", 0);
        Settings.musicOn = true;
        Settings.soundOn = true;
    }
    public void PlayGame(){
        SceneManager.LoadScene(ingameSceneName);
    }
}
