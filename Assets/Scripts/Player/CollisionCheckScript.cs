using System;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheckScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Door":
                other.gameObject.GetComponent<DoorScript>().WinPuzzle();
                break;
        }
    }
}
