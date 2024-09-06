using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lvlScore;
    public void NewLVLCount(string count)
    {
        _lvlScore.text = count;
    }
}
