using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonLogic : MonoBehaviour
{
    public TextMeshProUGUI buttontext;

    public void BackButton()
    {

        SceneManager.LoadSceneAsync(0);
    }
    public void PlayButton()
    {

        SceneManager.LoadSceneAsync(1);         //basic button scene manager button logic using scene layers (loaded asynchronously)
    }

    public void SetingsButton()
    {

        SceneManager.LoadSceneAsync(2);
    }

    

    public void QuitButton()
    {

        Application.Quit();
    }

}
