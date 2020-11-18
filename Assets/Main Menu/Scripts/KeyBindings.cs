using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeyBindings : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI buttonText;
    public Button forwardkey;
    public Button backkey;
    public Button leftkey;
    public Button rightkey;
    public Button jumpKey;
    public Button runKey;
    public Button crouchKey;
    public GameObject bindPopup;
    string btnText;
    bool waitingForKey;
    KeyCode newKey;
    Event keyEvent;
    void Start()
    {
        waitingForKey = false;
        forwardkey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.forward.ToString();
        backkey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Backward.ToString();
        leftkey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Left.ToString();
        rightkey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Right.ToString();
        jumpKey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Jump.ToString();
        runKey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Run.ToString();
        crouchKey.GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.Crouch.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        keyEvent = Event.current;
        if(keyEvent.isKey && waitingForKey)
		{
			newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
			waitingForKey = false;
		}
    } 
    public void StartAsignment(string keyName)
    {
        if(!waitingForKey)
           
            StartCoroutine(AssignKey(keyName));
    }
    public void sendText(TextMeshProUGUI text)
    {
        buttonText = text;
    }
    IEnumerator waitForKey()
    {
        while (!keyEvent.isKey)
        {
            yield return null;
        }
        }
   public IEnumerator AssignKey(string keyName)
	{
		waitingForKey = true;
        
        yield return waitForKey(); //Executes endlessly until user presses a key
        if(keyEvent.isKey)
        {
            bindPopup.GetComponent<CanvasGroup>().alpha = 0;
        }

		switch(keyName)
		{
		case "forward":
			GameManager.GM.forward = newKey; //Set forward to new keycode
			buttonText.text = GameManager.GM.forward.ToString(); //Set button text to new key
			PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString()); //save new key to PlayerPrefs
			break;
		case "backward":
			GameManager.GM.Backward = newKey; //set backward to new keycode
			buttonText.text = GameManager.GM.Backward.ToString(); //set button text to new key
			PlayerPrefs.SetString("backwardKey", GameManager.GM.Backward.ToString()); //save new key to PlayerPrefs
			break;
		case "left":
			GameManager.GM.Left = newKey; //set left to new keycode
			buttonText.text = GameManager.GM.Left.ToString(); //set button text to new key
			PlayerPrefs.SetString("leftKey", GameManager.GM.Left.ToString()); //save new key to playerprefs
			break;
		case "right":
			GameManager.GM.Right = newKey; //set right to new keycode
			buttonText.text = GameManager.GM.Right.ToString(); //set button text to new key
			PlayerPrefs.SetString("rightKey", GameManager.GM.Right.ToString()); //save new key to playerprefs
			break;
		case "jump":
			GameManager.GM.Jump = newKey; //set jump to new keycode
			buttonText.text = GameManager.GM.Jump.ToString(); //set button text to new key
			PlayerPrefs.SetString("jumpKey", GameManager.GM.Jump.ToString()); //save new key to playerprefs
			break;
        case "Crouch":
			GameManager.GM.Crouch = newKey; //set jump to new keycode
			buttonText.text = GameManager.GM.Crouch.ToString(); //set button text to new key
			PlayerPrefs.SetString("jumpKey", GameManager.GM.Crouch.ToString()); //save new key to playerprefs
			break;    
        case "run":
			GameManager.GM.Run = newKey; //set jump to new keycode
			buttonText.text = GameManager.GM.Run.ToString(); //set button text to new key
			PlayerPrefs.SetString("jumpKey", GameManager.GM.Run.ToString()); //save new key to playerprefs
			break;    
		}

		yield return null;
	}
}
