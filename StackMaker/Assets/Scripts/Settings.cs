using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Sprite musicOnSprite;
    [SerializeField] private Sprite musicOffSprite;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    [SerializeField] private Image musicImage;
    [SerializeField] private Image soundImage;
    public static bool musicOn = true; 
    public static bool soundOn = false;
    private static AudioSource musicAudioSource;
    private static AudioSource soundAudioSource;

    void Start()
    {
        musicAudioSource = gameManager.GetComponents<AudioSource>()[0];
        soundAudioSource = gameManager.GetComponents<AudioSource>()[1];
        OnInit();
    }

    void OnInit(){
        if(musicOn){
            musicImage.sprite = musicOnSprite;
            musicAudioSource.volume = 1;
        } else {
            musicImage.sprite = musicOffSprite;
            musicAudioSource.volume = 0;
        }
        if(soundOn){
            soundImage.sprite = soundOnSprite;
            soundAudioSource.volume = 1;
        } else {
            soundImage.sprite = soundOffSprite;
            soundAudioSource.volume = 0;
        }
    }

    public void TurnOnOffSettingsPanel(){
        if(!settingsPanel.activeInHierarchy){
            settingsPanel.SetActive(true);
        } else {
            settingsPanel.SetActive(false);
        }
    }

    public void TurnOnOffSound(){
        if(soundOn){
            soundOn = false;
            soundImage.sprite = soundOffSprite;
            soundAudioSource.volume = 0;
        } else {
            soundOn = true;
            soundImage.sprite = soundOnSprite;
            soundAudioSource.volume = 1;
        }
    }

    public void TurnOnOffMusic(){
        if(musicOn){
            musicOn = false;
            musicImage.sprite = musicOffSprite;
            musicAudioSource.volume = 0;
        } else {
            musicOn = true;
            musicImage.sprite = musicOnSprite;
            musicAudioSource.volume = 1;
        }
    }

    public static void PlaySoundEffect(AudioClip clip){
        soundAudioSource.clip = clip;
        soundAudioSource.Play();
    }
}
