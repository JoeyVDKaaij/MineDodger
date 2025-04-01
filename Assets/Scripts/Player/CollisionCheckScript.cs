using UnityEngine;

public class CollisionCheckScript : MonoBehaviour
{
    [SerializeField, Tooltip("Set the GameObject that has the death animation.")]
    private GameObject deathAnimation;
    
    private void OnCollisionEnter(Collision other)
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
