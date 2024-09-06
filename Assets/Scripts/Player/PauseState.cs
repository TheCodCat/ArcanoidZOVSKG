using UnityEngine.InputSystem;

public class PauseState : State
{
    public Player _player;
    public PauseState(Player player)
    {
        _player = player;
    }

    public override void Update()
    {
        base.Update();
    }
}
