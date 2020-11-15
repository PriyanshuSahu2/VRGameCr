using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void vSyncOn()
    {
        QualitySettings.vSyncCount =1;
        Debug.Log("On");
    }
    public void vSyncOff()
    {
        QualitySettings.vSyncCount =0;
        Debug.Log("off");
        
    }
}
