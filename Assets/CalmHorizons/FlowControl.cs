using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowControl : MonoBehaviour
{
    public Skybox[] skyboxes; // Array of skybox objects
    private int currentIndex = 0; // Index of the current skybox object

    [System.Serializable]
    public class Skybox
    {
        public Material skyboxMaterial; // Skybox material
        public AudioClip soundEffect; // Sound effect for this skybox

        public Skybox(Material skyboxMaterial, AudioClip soundEffect)
        {
            this.skyboxMaterial = skyboxMaterial;
            this.soundEffect = soundEffect;
        }

        // Play the sound effect for this skybox
        public void PlaySoundEffect()
        {
            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, Vector3.zero);
            }
        }
    }
       
    public void SkyboxIndex(int i)
    {
        currentIndex = i;
        ChangeSkybox(skyboxes[currentIndex]);
        ClickAudioSource.Play();
    }

    public AudioSource MainAudioSource;
    public AudioSource ClickAudioSource;
    public AudioSource Wimhofff;

    public void PlayWimhoff()
    {
        Wimhofff.Play();
        ClickAudioSource.Play();

    }
    public void ChangeSkybox(Skybox currentbox)
    {
        RenderSettings.skybox = skyboxes[currentIndex].skyboxMaterial;
        MainAudioSource.clip = skyboxes[currentIndex].soundEffect;
        MainAudioSource.Play();
    }

    private void Start()
    {
        ChangeSkybox(skyboxes[currentIndex]);
    }
    public GameObject rain;
    public void StartRain()
    {
        ClickAudioSource.Play();

        if (rain.activeSelf)
        {
            rain.SetActive(false);
        }
        else
        {
            rain.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
