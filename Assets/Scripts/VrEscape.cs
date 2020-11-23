using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VrEscape : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject vrPlay;
    public GameObject vrVideoPlayer;
    public GameObject vrlist;
    public GameObject exitPopUp;

    public Material videoRenderer;
    public Material nightBox;
    public VideoPlayer videoPlayer;
    public GameObject cameraSetting;
    void Start()
    {
        vrlist.SetActive(true);
        vrPlay.SetActive(false);

        RenderSettings.skybox = nightBox;
        cameraSetting.GetComponent<MouseLook>().enabled = false;
        exitPopUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(vrPlay.activeSelf)
        {
            Debug.Log("JIEJFPEJFJEFJPO");
            RenderSettings.skybox = videoRenderer;
            cameraSetting.GetComponent<MouseLook>().enabled = true;

            vrlist.GetComponent<CanvasGroup>().alpha = 0;
            vrlist.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pkaying");
            if (videoPlayer.isPlaying)
            {

                videoPlayer.Pause();

            }
            else
            {
                videoPlayer.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cameraSetting.GetComponent<MouseLook>().enabled = false;
            if (vrPlay.activeSelf)
            {
                Debug.Log("HIFJJI");
                vrlist.GetComponent<CanvasGroup>().alpha = 1;
                vrlist.GetComponent<CanvasGroup>().blocksRaycasts = true;
                vrPlay.SetActive(false);
                vrVideoPlayer.SetActive(false);
                RenderSettings.skybox = nightBox;
            }
            else if(vrlist.GetComponent<CanvasGroup>().alpha ==1)
            {
                Debug.Log("fIi");
                exitPopUp.SetActive(true);

            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void CloseExitpopUp()
    {
        exitPopUp.SetActive(false);
    }


}