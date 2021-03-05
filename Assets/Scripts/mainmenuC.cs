using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class mainmenuC : MonoBehaviour
{
    public string gameRoom;

    [Header("Parametros del menu de Settigns")]
    public float audioSliderMaxValue;
    public float audioSliderMinValue;

    public string audioMusic;
    public float audioMusicValue;

    public string audioSounds;
    public float audioSoundsValue;

    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider soundsSlider;


    // Start is called before the first frame update
    void Start()
    {
        soundsSlider.minValue = audioSliderMinValue;
        soundsSlider.maxValue = audioSliderMaxValue;

        musicSlider.maxValue = audioSliderMaxValue;
        musicSlider.minValue = audioSliderMaxValue;

        audioMixer.GetFloat(audioMusic, out audioMusicValue);
        audioMixer.GetFloat(audioSounds,out audioSoundsValue);

        musicSlider.value = audioMusicValue;
        soundsSlider.value = audioSoundsValue;
    }



    public void ChangeSoundAudio()
    {
        audioSoundsValue = soundsSlider.value;
        audioMixer.SetFloat(audioSounds, audioSoundsValue);
    }
    public void ChangeMusicAudio()
    {
        audioMusicValue = musicSlider.value;
        audioMixer.SetFloat(audioMusic, audioMusicValue);
    }

    public void GameStart()
    {
        SceneManager.LoadSceneAsync(gameRoom);
    }
}
