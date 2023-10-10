using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGameBob);
    }

 
    void StartGameBob()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 
}
