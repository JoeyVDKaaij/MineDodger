using UnityEngine;
using JoUnityAddOn.Input;

public class CameraControllerScript : MonoBehaviour
{
    
    public float mouseSensitivityX = 1f;
    public float mouseSensitivityY = 1f;
    
    private Transform _orientation;
    private float _rotationX;
    private float _rotationY;
    
    void Start()
    {
        Mouse.LockMouse();

        _orientation = transform.parent;
    }

    void Update()
    {
        if (GameManager.instance.gameplayType == GameplayTypes.Moving)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivityX * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivityY * Time.deltaTime;

            _rotationY += mouseX;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
            _orientation.rotation = Quaternion.Euler(0f, _rotationY, 0f);
        }
    }
}
