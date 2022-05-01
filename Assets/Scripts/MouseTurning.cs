using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTurning : MonoBehaviour
{
    // makes the player turn towards wherever the mouse is
    void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
    }
}
