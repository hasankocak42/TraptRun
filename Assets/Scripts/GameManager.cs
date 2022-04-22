using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool _isgameactive;
    public  GameObject _canvaswin;
    public  GameObject _canvasgameover;
    public  GameObject _canvasdrag;
    // Start is called before the first frame update
    void Start()
    {
        _isgameactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void scenemanager(string _str)
    {
        SceneManager.LoadScene(_str);
    }
    public void StartGame()
    {
        _isgameactive = true;
        _canvasdrag.SetActive(false);
    }
    public void RestartGame()
    {

    }

    public void NextGame()
    {

    }



}
