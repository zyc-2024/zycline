using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    public Vector3 newGravity = new Vector3(0, -9.81f, 0);


    private Vector3 originalGravity;

    void Start()
    {
        originalGravity = Physics.gravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        Physics.gravity = newGravity;

    }


}
