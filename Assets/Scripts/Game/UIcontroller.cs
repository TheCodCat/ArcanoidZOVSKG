using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private Text _lvlScore;
    public void NewLVLCount(string count)
    {
        _lvlScore.text = $"LVL:{count}";
    }
}
