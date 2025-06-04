using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.Rendering.Universal;


public class TitleManager : MonoBehaviour
{

    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public TMP_Dropdown resolutionDropdown;
    [SerializeField] public TMP_Dropdown qualityDropdown;
    [SerializeField] public TMP_Dropdown aaDropdown; 
    [SerializeField] public Slider volumeSlider;
    float currentVolume;
    Resolution[]  resolutions;
    //-----------------------------
    [SerializeField] GameObject PanelOpciones;
    [SerializeField] GameObject PanelMenu;
    Canvas canvas;
    [SerializeField] private Canvas canvasplayer;
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        //resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSetting();
    }

 

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume=volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions [ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit=textureIndex;
        //qualityDropdown.value = 6;
    }

    public void SetAntiAlising(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        aaDropdown.value = aaIndex;
        aaDropdown.RefreshShownValue();
    }

    public void SetQuality(int qualityIndex)
    {

            qualityDropdown.value = qualityIndex;
            QualitySettings.SetQualityLevel(qualityIndex);
            qualityDropdown.RefreshShownValue();
        
    }


    public void SaveSetting()
    {
        Debug.Log("Guarda");
        PlayerPrefs.SetInt("QualitySettingPreference",qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionSettingPreference",resolutionDropdown.value);
        PlayerPrefs.SetInt("AntiAlisingPreference",aaDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference",Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",currentVolume);
    }

    public void LoadSetting()
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            int loadedQuality = PlayerPrefs.GetInt("QualitySettingPreference");
            qualityDropdown.value = loadedQuality;
            QualitySettings.SetQualityLevel(loadedQuality);
        }
        
        if (PlayerPrefs.HasKey("ResolutionSettingPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionSettingPreference");
        }
       
        if (PlayerPrefs.HasKey("TextureSettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("TextureSettingPreference");
        }
        if (PlayerPrefs.HasKey("AntiAlisingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("AntiAlisingPreference");
            
        }
        
        if (PlayerPrefs.HasKey("FullScreenPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("FullScreenPreference");
        }
        
        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        
        

    }
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Opciones()
    {
        PanelOpciones.SetActive(true);
        PanelMenu.SetActive(false);
    }
    
    public void Salir()
    {
        Application.Quit();
    }
    public void SalirOpciones()
    {
        PanelOpciones.SetActive(false);
        PanelMenu.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PanelMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
}
