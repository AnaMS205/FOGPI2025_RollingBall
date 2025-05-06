using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public string newGameScene; //name of the scene we want to load
    public string controlScene;

    //public TMP_Text menuText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //menuText.text = " ";
        
    }

    public void StartGame(){
        SceneManager.LoadScene(newGameScene);
    }

    public void ControlMenu(){
        //show text on how to play
        //menuText.text = "W,A,S,D or Arrow Keys  =  Movement\nSpace Key  =  \"Attack\"";
        SceneManager.LoadScene(controlScene);
    }

    public void OuitGame(){
        Application.Quit();
    }
}
