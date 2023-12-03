using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    [SerializeField] private GameObject replayPanel;
    [SerializeField] private GameObject gameManager;
    public void TurnOnOffReplayPanel(){
        if(!replayPanel.activeInHierarchy){
            replayPanel.SetActive(true);
            Time.timeScale = 0f;
        } else {
            replayPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ChooseReplay(bool isReplay) {
        GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
        Time.timeScale = 1f;
        if(isReplay){
            replayPanel.SetActive(false);
            gameManagerScript.ReplayLevel();
        } else {
            replayPanel.SetActive(false);
        }
    }
}
