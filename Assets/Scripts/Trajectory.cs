using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _linerenderer;
    [SerializeField]
    [Range(3, 30)]
    private int _lineSegmentCount = 20;

    private List<Vector3> _linePoints = new List<Vector3>();

    public static Trajectory Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
       
    }

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody , Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for(int i = 0; i< _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                x: velocity.x * stepTimePassed,
                y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                z: velocity.z * stepTimePassed
                ) ;
            if (i == 0)
            {
                _linePoints.Add(item: startingPoint);
            }
            else
            {
                _linePoints.Add(item: -MovementVector + startingPoint);
            }
    
        }

        
        _linerenderer.positionCount = _linePoints.Count;
        _linerenderer.SetPositions(_linePoints.ToArray());
    }
        public void HideLine()
    {
        _linerenderer.positionCount = 0;
    } 

}
