using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingsControls : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    private GameObject currentKey;
    public Text forward, left, backward, right, jump;
    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(239, 116, 36, 225);
    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Forward", (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Forward","W")));
        keys.Add("Backward", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
        keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
        forward.text = keys["Forward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        backward.text = keys["Backward"].ToString();
        jump.text = keys["Jump"].ToString();
    }
    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }

    }
    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keys["Forward"]))
        {
            Debug.Log("forward");
        }
        if (Input.GetKeyDown(keys["Backward"]))
        {
            Debug.Log("backward");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("right");

        }
        if (Input.GetKeyDown(keys["Jump"]))
        {
            Debug.Log("jump");
        }

    }
    private void OnDisable()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
