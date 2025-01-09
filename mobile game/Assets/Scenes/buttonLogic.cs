using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using CandyCoded.HapticFeedback;


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
        HapticFeedback.HeavyFeedback();
    }

    public void SettingsButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        HapticFeedback.LightFeedback();

    }

    public void BackButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        HapticFeedback.LightFeedback();
    }

    public void MenuButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        HapticFeedback.LightFeedback();
    }

    public void BackButton2()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        HapticFeedback.LightFeedback();
    }
    public void ShopButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        HapticFeedback.LightFeedback();
    }

    public void ExitButton()
    {
        HapticFeedback.HeavyFeedback();
        Application.Quit();
        Debug.Log("QUIT APP!");

    }
}
