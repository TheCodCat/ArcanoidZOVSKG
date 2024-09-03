public class ColorBlock : Block
{
    int _hp = 2;
    public override void TakeBlock()
    {
        _hp--;
        if(_hp <= 0)
        {
            BlockManager.OnDestroyBlock?.Invoke(this);
        }
    }
}
