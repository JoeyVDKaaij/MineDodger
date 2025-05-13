using UnityEngine;

public class BillBoardingScript : MonoBehaviour
{
    private GameObject _camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        _camera = Camera.main.gameObject;  
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera != null)
        {
            float deltaX = _camera.transform.position.x - transform.position.x;
            float deltaZ = _camera.transform.position.z - transform.position.z;
            
            float rad = Mathf.Atan2(deltaZ, deltaX);
            
            transform.localRotation = Quaternion.Euler(0, 0, rad * (180 / Mathf.PI) + 90);
        }
    }
}
