using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject replayPanel;
    public void TurnOnOffSettingsPanel(){
        if(!settingsPanel.activeInHierarchy){
            settingsPanel.SetActive(true);
        } else {
            settingsPanel.SetActive(false);
        }
    }

    public void TurnOnOffReplayPanel(){
        if(!replayPanel.activeInHierarchy){
            replayPanel.SetActive(true);
            Time.timeScale = 0f;
        } else {
            replayPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
