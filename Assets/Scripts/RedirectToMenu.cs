using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RedirectToMenu : MonoBehaviour {

    public void SelectMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
