using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> pointsToFollow;
    [SerializeField] private float platformSpeed;
    private const float POINTREACHEDMAGNITUDE = 0.25f;
    private int index;
    private bool goingLeft;
    private bool reachedNextPoint;

    private void Awake()
    {
        index = 0;
        goingLeft = false;
        reachedNextPoint = false;
    }

    private void ChooseNextPoint() 
    {
        if (reachedNextPoint) 
        {
            if (goingLeft) 
            {
                index--;
                if (index < 0) 
                {
                    index = 0;
                    goingLeft = false;
                }
            }
            else 
            {
                index++;
                if (index >= pointsToFollow.Count) 
                {
                    index = pointsToFollow.Count - 1;
                    goingLeft = true;
                }
            }
            reachedNextPoint = false;
        }
    }

    private void PlatformMove() 
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, pointsToFollow[index].position, platformSpeed * Time.deltaTime);
    }

    private void CheckPlatformArrival() 
    {
        if (Vector3.Distance(this.transform.position, pointsToFollow[index].position) <= POINTREACHEDMAGNITUDE) 
        {
            reachedNextPoint = true;
        }
    }

    private void PlatformBehaviour() 
    {
        ChooseNextPoint();
        PlatformMove();
        CheckPlatformArrival();
    }

    private void Update()
    {
        PlatformBehaviour();
    }
}
