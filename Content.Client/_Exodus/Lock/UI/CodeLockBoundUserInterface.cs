using Content.Shared.Exodus.Lock.Components;
using JetBrains.Annotations;
using Robust.Client.UserInterface;

namespace Content.Client.Exodus.Lock.UI;

[UsedImplicitly]
public sealed class CodeLockBoundUserInterface : BoundUserInterface
{
    private CodeLockWindow? _window;

    public CodeLockBoundUserInterface(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();
        _window = this.CreateWindow<CodeLockWindow>();
        _window.OnCodeLockButton += ButtonPressed;
    }

    protected override void UpdateState(BoundUserInterfaceState state)
    {
        base.UpdateState(state);
        var castState = (CodeLockBoundUserInterfaceState)state;
        _window?.UpdateState(castState);
    }
    public void ButtonPressed(UiButton button)
    {
        SendMessage(new CodeLockButtonPressedMessage(button));
    }
}
