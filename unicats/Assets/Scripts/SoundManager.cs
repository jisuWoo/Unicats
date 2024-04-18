using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    //소리 조절 기능 삽입 필요
    public static SoundManager instance;
    public AudioSource efxSource;
    public AudioSource BgmSource;


    public Slider bgm_slider;
    public Slider efx_slider;

    public AudioClip doorSound;
    public AudioClip rubySound;
    public AudioClip fisheatSound;
    public AudioClip wrongeatSound;
    public AudioClip trashSound;
    public AudioClip wrongSound;
    
    private void Awake()
    {
        if(SoundManager.instance == null) SoundManager.instance = this;
        bgm_slider = bgm_slider.GetComponent<Slider>();
        efx_slider = efx_slider.GetComponent<Slider>();

        efxSource = GameObject.Find("EfxPlayer").GetComponent<AudioSource>();
        BgmSource = GameObject.Find("BgmPlayer").GetComponent<AudioSource>();

        bgm_slider.onValueChanged.AddListener(VolumBgm);
        efx_slider.onValueChanged.AddListener(VolumEfx);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    void VolumBgm(float value)
    {
        BgmSource.volume = value;
    }

    void VolumEfx(float value)
    {
        BgmSource.volume = value;
    }

}
