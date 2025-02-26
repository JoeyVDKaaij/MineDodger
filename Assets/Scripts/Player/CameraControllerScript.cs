using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerScript : MonoBehaviour
{
    
    public float mouseSensitivityX = 1f;
    public float mouseSensitivityY = 1f;
    
    private Transform _orientation;
    private float _rotationX;
    private float _rotationY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _orientation = transform.parent;
    }

    // Update is called once per frame
    void Update()
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
