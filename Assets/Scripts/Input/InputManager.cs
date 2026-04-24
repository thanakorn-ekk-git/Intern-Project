using UnityEngine;

public static class InputManager
{
    public static KeyCode Sprint = KeyCode.LeftShift;
    public static KeyCode Jump = KeyCode.Space;
    public static Vector2 KeyBoardMove => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    public static float mouseSensitivity = 100f;
    public static Vector2 MouseMove => new Vector2(Input.GetAxis("Mouse X") * mouseSensitivity, Input.GetAxis("Mouse Y") * mouseSensitivity);
}
