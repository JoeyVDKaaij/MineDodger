using System;
using UnityEngine;

public class CollisionCheckScript : MonoBehaviour
{
    [SerializeField, Tooltip("Set the GameObject that has the death animation.")]
    private GameObject deathAnimation;
    [SerializeField, Tooltip("Set the GameObject that has the death animation.")]
    private LayerMask whatIsGround;
    [SerializeField, Tooltip("Set the GameObject that has the death animation.")]
    private float playerHeight;

    public bool CheckCollisionWithRayCast()
    {
        bool _grounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (_grounded)
        {
            TileScript tileScript = hit.collider.gameObject.GetComponent<TileScript>();
            if (tileScript != null)
                tileScript.ShowCounter();
        }
        
        return _grounded;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.instance != null && GameManager.instance.gameplayType == GameplayTypes.Moving)
        {
            switch (other.gameObject.tag)
            {
                case "Door":
                    if (other.gameObject.GetComponent<DoorScript>() != null)
                        other.gameObject.GetComponent<DoorScript>().WinPuzzle();
                    else
                        Debug.LogError("No DoorScript found. Please add DoorScript to your door object.");
                    break;
            }

            if (other.gameObject.layer == 3)
            {
                TileScript tileScript = other.gameObject.GetComponent<TileScript>();
                if (tileScript != null)
                    tileScript.ShowCounter();
            }
        }
    }
}
