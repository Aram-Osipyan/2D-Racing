using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(SpriteShapeController))]
public class GroundController : MonoBehaviour
{
    [SerializeField] float constantValue;
    [SerializeField] Transform player;
    [SerializeField] int scale = 20;
    [SerializeField] int numOfPoints = 10;
    SpriteShapeController shape;
    Vector3 lowPosition;
    void Start()
    {
        shape = GetComponent<SpriteShapeController>();
        lowPosition = shape.spline.GetPosition(0);
        lowPosition.y -= 2;
        float distanceBwtnpoints = scale / numOfPoints;

        for (int i = 0; i < 2*numOfPoints-4; i++)
        {
            shape.spline.InsertPointAt(0, new Vector3(i,i,i));
        }
        shape.spline.SetPosition(0,
           new Vector3(lowPosition.x, player.position.y - 1, lowPosition.z));
        shape.spline.SetPosition(1,
            new Vector3(lowPosition.x + distanceBwtnpoints, player.position.y - 1, lowPosition.z));
        for (int i = 2; i < numOfPoints; i++)
        {
            float xPos = shape.spline.GetPosition(i-1).x + distanceBwtnpoints;
            shape.spline.SetPosition(i,
            //new Vector3(xPos, Mathf.PerlinNoise(Random.Range(5f, 15f), 0), lowPosition.z));
            new Vector3(xPos, player.position.y - 1, lowPosition.z)); ;
        }
        
        for (int i = 0; i < numOfPoints; i++)
        {
            float xPos = shape.spline.GetPosition(numOfPoints - i-1).x;
            shape.spline.SetPosition(numOfPoints + i, new Vector3(xPos, lowPosition.y, lowPosition.z));
            
        }
        for (int i = 0; i < numOfPoints; i++)
        {
            ChangePointTangent(i);
        }
       
    }

    Vector3 nextPoint = new Vector3();  
    private void FixedUpdate()
    {
        float distanceBwtnpoints = scale / numOfPoints;
        
        if (Mathf.Abs(player.position.x- shape.spline.GetPosition(0).x)>constantValue)
        {
            shape.spline.RemovePointAt(2 * numOfPoints - 1);
            shape.spline.RemovePointAt(0);
            
            nextPoint.x = shape.spline.GetPosition(numOfPoints - 2).x + distanceBwtnpoints;

            nextPoint.y = lowPosition.y;
            shape.spline.InsertPointAt(numOfPoints - 1 , nextPoint);
            
            ChangePointTangent(numOfPoints-2);
            nextPoint.y = 2*Mathf.PerlinNoise(Random.Range(5f, 15f), 0); // change to noise
            shape.spline.InsertPointAt(numOfPoints - 1, nextPoint);
            ChangePointTangent(numOfPoints - 2);
        }
    }
    private void ChangePointTangent(int pointIndex)
    {
        shape.spline.SetTangentMode(pointIndex, ShapeTangentMode.Continuous);
        shape.spline.SetLeftTangent(pointIndex, new Vector3(-2, 0, 0));
        shape.spline.SetRightTangent(pointIndex, new Vector3(2, 0, 0));
    }
    void Update()
    {
        
    }

}
