using UnityEngine;
using System.Collections;

public class FenceCollision : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Car")
        {
            PlayerCar c = col.gameObject.GetComponent<PlayerCar>();
            c.velocity = new Vector3(0, c.velocity.y, c.velocity.z);

        }
    }
}
