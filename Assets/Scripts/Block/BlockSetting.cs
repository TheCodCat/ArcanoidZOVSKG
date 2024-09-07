using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlockSetting : ScriptableObject
{
    public Sprite spritesHP;
    public int HP;
    public bool IsDestroy;
    [Range(0,1)]public float min;
    [Range(0,1)]public float max;
}
