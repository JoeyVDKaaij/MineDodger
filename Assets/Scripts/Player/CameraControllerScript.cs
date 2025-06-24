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
        _orientation = transform.parent;
        _rotationX = _orientation.rotation.eulerAngles.x;
        _rotationY = _orientation.rotation.eulerAngles.y;
        
        if (OptionsManager.instance != null)
        {
            mouseSensitivityX = OptionsManager.instance.mouseSensitivity;
            mouseSensitivityY = OptionsManager.instance.mouseSensitivity;
        }
    }

    void LateUpdate()
    {
        if ((GameManager.instance != null && GameManager.instance.gameplayType != GameplayTypes.Paused) || GameManager.instance == null)
        {
            if (!Mouse.MouseLocked()) Mouse.LockMouse();
            
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivityX * Time.deltaTime * 3;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivityY * Time.deltaTime * 3;

            _rotationY += mouseX;

            _rotationX -= mouseY;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

            transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
            _orientation.rotation = Quaternion.Euler(0f, _rotationY, 0f);
        }
        else if (((GameManager.instance != null && GameManager.instance.gameplayType == GameplayTypes.Paused) || GameManager.instance == null) && Mouse.MouseLocked())
        {
            Mouse.UnlockMouse();
        }
    }
}
