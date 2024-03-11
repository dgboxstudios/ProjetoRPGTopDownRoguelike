using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public float moveSpeed = 1;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(GameManager.Instance.player.transform.position.x, GameManager.Instance.player.transform.position.y, transform.position.z), moveSpeed * Time.fixedDeltaTime);
    }
}
