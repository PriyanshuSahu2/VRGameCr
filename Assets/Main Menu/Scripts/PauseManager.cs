using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Variables
    [SerializeField] GameObject pauseMenu, exitMenu,player;

    #endregion
    void Start()
    {
        
        var pauseMenuGroup = pauseMenu.GetComponent<CanvasGroup>();
        pauseMenuGroup.alpha = 0;
        pauseMenuGroup.blocksRaycasts = false;
        
        exitMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.GetComponent<CanvasGroup>().alpha==1)
            {
                Debug.Log("true");
                exitMenu.SetActive(true);
            }
            player.GetComponent<FirstPersonAIO>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.GetComponent<CanvasGroup>().alpha = 1;
            pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
      
    }
    public void Resume()
    {
        player.GetComponent<FirstPersonAIO>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.GetComponent<CanvasGroup>().alpha = 0;
        pauseMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
