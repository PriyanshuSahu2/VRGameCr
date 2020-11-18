using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VrEscape : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject vrPlay;
    public GameObject vrVideoPlayer;
    public GameObject vrlist;
    public GameObject exitPopUp;
    public GameObject pauseMenu;
    public Material videoRenderer;
    public Material nightBox;
    void Start()
    {
        vrlist.SetActive(true);
        vrPlay.SetActive(false);
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        RenderSettings.skybox = nightBox;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vrPlay.activeSelf)
        {
            RenderSettings.skybox = videoRenderer;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(vrPlay.activeSelf)
            {
                vrlist.GetComponent<CanvasGroup>().alpha = 1;
                vrlist.GetComponent<CanvasGroup>().blocksRaycasts = true;
                vrPlay.SetActive(false);
                vrVideoPlayer.SetActive(false);
                RenderSettings.skybox = nightBox;

            }
            else if(vrlist.GetComponent<CanvasGroup>().alpha ==1)
            {
                vrlist.GetComponent<CanvasGroup>().alpha = 0;
                vrlist.GetComponent<CanvasGroup>().blocksRaycasts = false;
                pauseMenu.GetComponent<CanvasGroup>().alpha = 1;
                pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            else
            {
                exitPopUp.SetActive(true);
            }
        }
    }
    public void Resume()
    {
        vrlist.GetComponent<CanvasGroup>().alpha = 1;
        vrlist.GetComponent<CanvasGroup>().blocksRaycasts = true;
        RenderSettings.skybox = videoRenderer;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
     public void closePopUp()
    {
      exitPopUp.SetActive(false);
    }

}