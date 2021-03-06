using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, z:forceInit.y))*forceMultiplier;

        if (!isShoot)
            //    Trajectory.Instance.UpdateTrajectory( forceVector: forceV, rb, startingPoint: transform.position);
            Trajectory.Instance.UpdateTrajectory(forceVector: forceV, rb,  Vector3.zero);
    }

    private void OnMouseUp()
    {
        Trajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(Force:mousePressDownPos - mouseReleasePos);
    }

    private float forceMultiplier = 5;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y)* forceMultiplier);
        isShoot = true;
    }
}
