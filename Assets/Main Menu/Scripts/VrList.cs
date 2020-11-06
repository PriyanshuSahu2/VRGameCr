using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;
public class VrList : MonoBehaviour
{
    private GameObject[]  gameObject;
    string[] files;
    public GameObject Bp ;
    string pathPreFix;
    public GameObject cv;
    public VideoPlayer videopl;
    public GameObject videoList;
    public GameObject videoPlBtn;
    public Texture txt;


    public RenderTexture rt;

    void Start()
    {

    }
    IEnumerator playVideo()
    {
      videopl.Stop();
        videoPlBtn.SetActive(false);
        string path =@"C:\videos";
        pathPreFix = @"file://";
        files = System.IO.Directory.GetFiles(path,"*.mp4");
        Debug.Log(files.Length);

        for(int i =0;i<files.Length;i++)
        {
         int index = i;
            Debug.Log(i);
        string s1 = files[i];
        string s3 = path;
        string s4 = ".mp4";
        string s2 = s1.Replace(s3,"");
        s2  = s2.Replace(s4,"");

        GameObject gb= Instantiate(Bp,cv.transform,false);
        Button btns = gb.GetComponent<Button>();

        btns.onClick.AddListener(()=> TaskOnClick(index));

        rt = new RenderTexture(256,256,16,RenderTextureFormat.ARGB32);
        rt.Create();
        //btns.GetComponentInChildren<Image>().sprite = Sprite.Create(tex2d,new Rect(0.0f,0.0f,tex2d.width,tex2d.height),new Vector2(0.5f,0.5f));
        //foreach(var pm in gb.Find("Background").GetComponents<Image>()){pm.sprite =Sprite.Create(tex2d,new Rect(0.0f,0.0f,tex2d.width,tex2d.height),new Vector2(0.5f,0.5f));}

        foreach(var lm in gb.GetComponentsInChildren<VideoPlayer>()){lm.url = files[i];
          lm.targetTexture = rt;
          lm.frame = 111;lm.Prepare();

          Debug.Log(lm.isPrepared);
          yield return new WaitForSeconds(0.5f);
          lm.Pause();
        }

         foreach(var pm in gb.GetComponentsInChildren<RawImage>()){pm.texture=rt;
         }
        foreach(var tm in gb.GetComponentsInChildren<TextMeshProUGUI>()){tm.text =s2;
        Debug.Log(files[i]);
              }
    }

  }
    void Awake()
    {

      StartCoroutine(playVideo());
        }




    // Update is called once per frame
    void TaskOnClick(int index)
    {

        print(index);
        Debug.Log(files[index]);

        videopl.url= files[index];
        videoList.SetActive(false);
        videoPlBtn.SetActive(true);
        //SceneManager.LoadScene(2);
    }
    public void onupdate()
    {
      Debug.Log("FPEFP");
    }
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        //videoList.SetActive(true);
       //videoPlBtn.SetActive(false);
      }
    }
}
