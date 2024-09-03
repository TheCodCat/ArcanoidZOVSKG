using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private int _lvl;
    [SerializeField] private UIcontroller _controller;

    private void Start()
    {
        BlockManager.OnNewLVL += NewLVL;
    }
    private void NewLVL()
    {
        _lvl++;
        _controller.NewLVLCount(_lvl.ToString());
    }
}
