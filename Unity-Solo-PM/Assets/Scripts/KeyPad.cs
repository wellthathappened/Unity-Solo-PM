using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    GameManager gm;
    TextMeshProUGUI KP_Screen;

    string userEntry;

    string validCode = "0451";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KP_Screen = GameObject.FindGameObjectWithTag("key_screen").GetComponent<TextMeshProUGUI>();
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();

        userEntry = "";
    }

    private void Update()
    {
        KP_Screen.text = userEntry;
    }

    public void Leave()
    {
        GameObject.FindGameObjectWithTag("kp_ui").SetActive(false);

        gm.DisableKeypad();
    }

    public void Submit()
    {
        if (userEntry == validCode)
        {
            gm.doorCodeEntered = true;

            Leave();
        }

        else
            userEntry = "Invalid Code";
    }

    public void ClearScreen()
    {
        userEntry = "";
    }

    public void InvalidCheck()
    {
        if (userEntry == "Invalid Code")
            ClearScreen();
    }

    public void DeleteChar()
    {
        InvalidCheck();

        if (userEntry.Length > 0)
            userEntry = userEntry.Remove(userEntry.Length - 1);
    }

    public void NumEntry()
    {
        InvalidCheck();

        if (userEntry.Length < 4)
            userEntry += EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
    }
}
