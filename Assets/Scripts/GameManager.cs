using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode Jump {get; set;}
    public KeyCode Backward {get; set;}
    public KeyCode forward {get; set;}
    public KeyCode Run {get; set;}
    public KeyCode Left {get; set;}
    public KeyCode Right {get; set;}
    public KeyCode Crouch {get; set;}
    public static GameManager GM;



    void Awake()
    {
      if(GM==null)
      {
        DontDestroyOnLoad(gameObject);
        GM=this;
      }
      else if(GM!=this)
      {
        Destroy(gameObject);
      }
      Jump = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("jumpKey","Space"));
      Backward = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("backwardKey","S"));
      forward = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("forwardKey","W"));
      Run = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("runKey","LeftShift"));
      Left = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("leftKey","A"));
      Right = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("rightKey","D"));
      Crouch = (KeyCode) System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Crouch","C"));
    }
    // Update is called once per frame
    void Update()
    {
    
    Debug.Log(forward);
    }
}
