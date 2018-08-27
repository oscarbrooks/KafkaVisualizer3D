using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraControls : MonoBehaviour
{

    [SerializeField]
    private float _sensitivity;
    private float _rotationX;
    private bool _cursorLocked = true;

    private void Start()
    {

    }

    private void Update()
    {
        HandleCursor();

        if (!_cursorLocked) return;

        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rot = new Vector3(mouseY, Input.GetAxis("Mouse X"), 0);
        rot *= _sensitivity;

        _rotationX += rot.x;
        _rotationX = Mathf.Clamp(_rotationX, -70, 90);

        transform.Rotate(-mouseY, 0, 0);
        transform.parent.Rotate(0, rot.y, 0);
    }

    private void HandleCursor()
    {
        if (Input.GetKeyDown("p"))
            _cursorLocked = !_cursorLocked;
        Cursor.visible = (!_cursorLocked);
        if (_cursorLocked)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.None;
    }
}
