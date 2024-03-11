using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public float offset;

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {
        Vector2 newDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(newDirection.y, newDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        if (angle > 90 || angle < -90)
            localScale.y = -1;
        else
            localScale.y = 1;

        transform.localScale = localScale;
    }
}
