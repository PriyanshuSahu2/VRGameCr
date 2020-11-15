using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PLayerSave : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI txt;

    public Button forward;
    public Button backward;
    public List<string> ele = new List<string>();
    private int i = 0;
     Resolution resolution;
      public Animator selectorAnimator;
    void Awake()
    {
        
       i = PlayerPrefs.GetInt("My");
       txt.text = ele[i];
       Debug.Log(ele[i]);
       ChangeResolution();
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ChangeResolution()
    {
        if (ele[i] == "1080 X 1080")
        {
            Screen.SetResolution(1080, 1080, true);
            Debug.Log("1080");
        }
        else if(ele[i] == "1200 X 1200")
        {
            Screen.SetResolution(1200, 1200, true);
             Debug.Log("1200");
        }
        else if(ele[i] == "1920 X 1080")
        {
            Screen.SetResolution(1920, 1080, true);
             Debug.Log("1920*1080");
        }
    }

    public void Forward()
    {
        if((i +1)>=ele.Count)
        {
            i=0;
        }
        else{
            i++;
        }

     
     Debug.Log(ele[i]);
     txt.text = ele[i];
       ChangeResolution();
     PlayerPrefs.SetInt("My",i);
                 selectorAnimator.Play(null);
            selectorAnimator.StopPlayback();
            selectorAnimator.Play("Forward");
    }
    public void Backward()
    {
        if(i==0)
        {
            i=ele.Count-1;
        }
        else{
        i--;
        }
        Debug.Log(ele[i]);
        
        txt.text = ele[i];
        ChangeResolution();
        PlayerPrefs.SetInt("My",i);
         selectorAnimator.Play(null);
            selectorAnimator.StopPlayback();
            selectorAnimator.Play("Previous");
    }
}
