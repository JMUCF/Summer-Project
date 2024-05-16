using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    private bool controllerPriority = false;
    
    public GameObject pauseMenuUI;
    //public GameObject panelHowToPlay;

    public GameObject resume;
    //public GameObject HowToPlay;
    //public GameObject closeHowToPlay;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        string[] joystickNames = Input.GetJoystickNames();
        bool controllerConnected = joystickNames.Length > 0;

        controllerPriority = controllerConnected;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused){
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Resume();
            }else if(!GameIsPaused && controllerPriority){
                Pause();
                EventSystem.current.sendNavigationEvents = true;
                EventSystem.current.SetSelectedGameObject(resume);
                //panelHowToPlay.SetActive(false);
            }else{              
                Pause();
                //panelHowToPlay.SetActive(false);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }

        if(GameIsPaused && controllerPriority)
        {
        
            if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
            
    }

    void Pause(){
        pauseMenuUI.SetActive(true); 
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*public void HowToPlay()
    {
        panelHowToPlay.SetActive(true);
        EventSystem.current.SetSelectedGameObject(closeHowToPlay);
    }

    public void exitHowToPlay()
    {
        panelHowToPlay.SetActive(false);
        EventSystem.current.SetSelectedGameObject(HowToPlay);
    }*/
}