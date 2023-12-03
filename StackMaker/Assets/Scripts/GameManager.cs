using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private TextMeshProUGUI winText; 
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject terrain;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject restartGameButton;
    [SerializeField] private List<GameObject> levelMapPrefabs;
    [SerializeField] private GameObject endingPanel;
    [SerializeField] private GameObject losePanel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI goldText;
    public static int level;
    
    // Start is called before the first frame update
    void Start(){   
        OnInit();
    }

    private void OnInit(){
        level = 0;
        level = PlayerPrefs.GetInt("level", 0);
        goldText.text = "0";
        if(level < levelMapPrefabs.Count){
            Instantiate(levelMapPrefabs[level], Vector3.zero, Quaternion.identity, terrain.transform);
        } else {
            Instantiate(levelMapPrefabs[0], Vector3.zero, Quaternion.identity, terrain.transform);
        }
        Time.timeScale = 1.0f;
        levelText.text = "Level: " + level;
    }

    // Update is called once per frame
    void Update(){
        goldText.text = Player.goldCount.ToString();
    }

    public void Quit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Aplication.Quit();
        #endif
    }

    private void OnApplicationQuit() {
        PlayerPrefs.SetInt("level", 0);
    }

    public void ReplayLevel(){
        SceneManager.LoadScene("InGameScene");
    }

    public void RestartGame(){
        SceneManager.LoadScene("StartScene");
    }

    public void NextLevelLoadScene()
    {
        PlayerPrefs.SetInt("level", level + 1);
        SceneManager.LoadScene("InGameScene");
    }

    public void LoadEndPanel(){
        endingPanel.SetActive(true);
        winText.text = "Level " + level + ": Finished";
        scoreText.text = "Score: " +  Player.goldCount.ToString();
        if(level == levelMapPrefabs.Count - 1){
            nextLevelButton.SetActive(false);
            restartGameButton.SetActive(true);
        }
    }

    public void LoadLosePanel(){
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}