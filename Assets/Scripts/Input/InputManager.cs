using UnityEngine;

public static class InputManager
{
    public static KeyCode Sprint = KeyCode.LeftShift;
    public static KeyCode Jump = KeyCode.Space;
    public static Vector2 KeyBoardMove => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    public static float mouseSensitivity = 100f;
    public static Vector2 MouseMove => new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * mouseSensitivity);

    public static bool Attack => Input.GetKeyDown(KeyCode.Mouse0);

    public static KeyCode CastPerkSlot1 = KeyCode.Alpha1;
    public static KeyCode CastPerkSlot2 = KeyCode.Alpha2;
    public static KeyCode CastPerkSlot3 = KeyCode.Alpha3;
    public static KeyCode CastPerkSlot4 = KeyCode.Alpha4;
}
