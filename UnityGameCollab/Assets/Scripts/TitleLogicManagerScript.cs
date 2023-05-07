using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleLogicManagerScript : MonoBehaviour
{
    public GameObject TitleParent;
    public GameObject SettingsParent;
    public Text ControlsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenSettings()
    {
        TitleParent.SetActive(false);
        SettingsParent.SetActive(true);
    }

    public void SetControls(bool inputValue = false)
    {
        StateNameController.mouseControls = inputValue;
        SettingsParent.SetActive(false);
        if (StateNameController.mouseControls)
        {
            ControlsText.text = "Move mouse to move the Platform";
        }
        else
        {
            ControlsText.text = "Use arrows to move the Platform";
        }
        TitleParent.SetActive(true);
        Debug.Log("Mouse Controls set to " + StateNameController.mouseControls);
    }
}
