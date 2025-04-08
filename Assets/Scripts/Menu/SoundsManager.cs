using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;
    [SerializeField] AudioSource[] _sources = new AudioSource[2];

    float _volumeGeneral = 0.5f;
    float _volumeMusic = 0.5f;
    float _volumeFX = 0.5f;

    public void ChangeVolumeGeneral(Slider slider)
    {
        _volumeGeneral = slider.value;

        if (_volumeGeneral < 0.01f)
            _volumeGeneral = 0.01f;

        _mixer.SetFloat("MasterVolume", Mathf.Log10(_volumeGeneral) * 20);
    }

    public void ChangeVolumeMusic(Slider slider)
    {
        _volumeMusic = slider.value;

        if (_volumeMusic < 0.01f)
            _volumeMusic = 0.01f;

        _mixer.SetFloat("MusicVolume", Mathf.Log10(_volumeMusic) * 20);
    }

    public void ChangeVolumeFx(Slider slider)
    {
        _volumeFX = slider.value;

        if (_volumeFX < 0.01f)
            _volumeFX = 0.01f;

        _mixer.SetFloat("FxVolume", Mathf.Log10(_volumeFX) * 20);

        if (!_sources[1].isPlaying)
            _sources[1].Play();
    }
}
