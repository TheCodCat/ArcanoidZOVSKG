using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using System.Collections;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private PlayableDirector _controlls;
    [SerializeField] private UIcontroller _controller;
    [SerializeField] private BallCreator _ball;
    [SerializeField] private int _score;
    [SerializeField] private int _lvl;
    private void OnEnable()
    {
        BlockManager.OnNewLVL += NewLVL;
        GameInput.OnRestartLVL += StartRestartPanel;
        
    }
    private void OnDisable()
    {
        BlockManager.OnNewLVL -= NewLVL;
        GameInput.OnRestartLVL -= StartRestartPanel;
    }
    private void NewLVL()
    {
        _lvl++;
        _controller.NewLVLCount(_lvl.ToString());
    }
    private void StartRestartPanel()
    {
        _controlls.Play();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
