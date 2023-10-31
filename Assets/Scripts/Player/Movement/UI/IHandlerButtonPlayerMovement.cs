namespace UI.Player.Movement
{
    public interface IHandlerButtonPlayerMovement
    {
        HandlerButtonPlayerMovement.TypeButtonMovement typeButtonMovement { get; }

        bool isPressed { get; }
    }
}
