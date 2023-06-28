using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{

    public LineRenderer lineRenderer;

    public int lineSegmentCount = 20;

    private List<Vector3> linePoints = new List<Vector3>();

    public static DrawTrajectory Instance;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        linePoints.Clear();
    }

    // Update is called once per frame
    public void UpdateTrajectory(Vector3 forceVector,Rigidbody rigidbody,Vector3 startingPoint)
    {
        float width = lineRenderer.startWidth;
        lineRenderer.material.mainTextureScale = new Vector2(1f / width, 1.0f);
        //lineRenderer.material.color = new Color(1, 1, 1,0);

        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (2 * velocity.y) / Physics.gravity.y - 0.5f;

        float stepTime = FlightDuration / lineSegmentCount;

        linePoints.Clear();

        linePoints.Add(startingPoint);
        for(int i = 1; i < (int)lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;
            Vector3 MovementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
                );
            Vector3 nextPoint = -MovementVector + startingPoint;

            RaycastHit hit;
            if (Physics.Raycast(linePoints[i - 1], nextPoint - linePoints[i - 1], out hit, (nextPoint - linePoints[i - 1]).magnitude))
            {
                linePoints.Add(hit.point);
                break;
            }

            linePoints.Add(nextPoint);

        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }

    public void HideLine()
    {
        lineRenderer.positionCount = 0;

    }
}
