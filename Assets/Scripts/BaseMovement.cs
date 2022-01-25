using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected Transform movePoint;
    public Transform MovePoint => movePoint;

    [SerializeField] protected LayerMask obstaclesLayer;
    protected enum DirectionList { Right, Left, Up, Down }
    protected Dictionary<DirectionList, Vector3> direction = new Dictionary<DirectionList, Vector3>()
    {
        [DirectionList.Right] = Vector3.right,
        [DirectionList.Left] = Vector3.left,
        [DirectionList.Up] = Vector3.up,
        [DirectionList.Down] = Vector3.down,
    };

    protected void Move(DirectionList directionName, float distanceRatio = 1f)
    {
        if (!Physics2D.Raycast(movePoint.position, direction[directionName], distanceRatio, obstaclesLayer))
            movePoint.localPosition += direction[directionName] * distanceRatio;
    }
}