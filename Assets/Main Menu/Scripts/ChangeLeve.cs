using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLeve : MonoBehaviour
{
public GameObject exitPopUp;
private void Update()
{
  if(Input.GetKeyDown(KeyCode.Escape))
  {
    exitPopUp.SetActive(true);
  }
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
      exitPopUp.SetActive(false);
    }

}
