using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class buttonLogic : MonoBehaviour
{
    public TextMeshProUGUI buttontext;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            //add sceneswitcher to buttons onclick event
            button.onClick.AddListener(StartButton);
        }
    }
    public void StartButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void SettingsButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void BackButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + - 2);

    }

    public void ExitButton()
    {

        Application.Quit();
        Debug.Log("QUIT APP!");

    }
}
