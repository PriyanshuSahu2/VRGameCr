using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gb;// Start is called before the first frame update
    void Start()
    {
      gb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
      {
        gb.SetActive(true);
      }
    }
}
