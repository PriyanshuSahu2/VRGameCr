using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLeve : MonoBehaviour
{
public GameObject closePop;
private void Update()
{

}
    public void MenuLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void ForestLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void VrLevel()
    {
      SceneManager.LoadScene(2);
    }
    public void closePopUp()
    {
      closePop.SetActive(false);
    }

}
