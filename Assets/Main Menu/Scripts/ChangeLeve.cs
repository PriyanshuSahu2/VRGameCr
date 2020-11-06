using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLeve : MonoBehaviour
{


    public void ForestLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void VrLevel()
    {
      SceneManager.LoadScene(2);
    }
}
