using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class Floater : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody;
    [SerializeField]
    private float depthBefSub;
    [SerializeField]
    private float displacementAmt;
    [SerializeField]
    private int floaters;
    [SerializeField]
    private float waterDrag;
    [SerializeField]
    private float waterAngularDrag;
    [SerializeField]
    private WaterSurface water;
    private WaterSearchParameters Search;
    private WaterSearchResult SearchResult;

    private void FixedUpdate()
    {
        rigidBody.AddForceAtPosition(Physics.gravity / floaters, transform.position, ForceMode.Acceleration);

        Search.startPosition = transform.position;

        water.FindWaterSurfaceHeight(Search, out SearchResult);

        if(transform.position.y < SearchResult.height)
        {
            float displacementMult = Mathf.Clamp01(SearchResult.height - transform.position.y / depthBefSub * displacementAmt);
            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMult, 0f), transform.position, ForceMode.Acceleration);
            rigidBody.AddForce(displacementMult * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMult * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
