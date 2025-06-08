using Robust.Shared.Serialization;
using Robust.Shared.GameStates;

namespace Content.Shared.Exodus.Lock.Components;

[Serializable, NetSerializable]
public sealed class CodeLockBoundUserInterfaceState : BoundUserInterfaceState
{
    public readonly string Code;
    public readonly string CurrentCode;
    public readonly bool SubmitEnabled;

    public CodeLockBoundUserInterfaceState(string code, string currentCode, bool submitEnabled = false)
    {
        Code = code;
        CurrentCode = currentCode;
        SubmitEnabled = submitEnabled;
    }
}

[Serializable, NetSerializable]
public sealed class CodeLockButtonPressedMessage : BoundUserInterfaceMessage
{
    public readonly UiButton Button;

    public CodeLockButtonPressedMessage(UiButton button)
    {
        Button = button;
    }
}

[Serializable, NetSerializable]
public enum CodeLockUiKey
{
    Key
}

public enum UiButton
{
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Clean,
    Zero,
    Submit,
}

[RegisterComponent, NetworkedComponent]
[AutoGenerateComponentState]
public sealed partial class CodeLockComponent : Component
{
    [DataField("password"), ViewVariables(VVAccess.ReadWrite)]
    [AutoNetworkedField]
    public string Password = "";

    public string CurrentCode = "";

    public int PasswordLength = 4;

    public bool SubmitEnabled = false;
}
