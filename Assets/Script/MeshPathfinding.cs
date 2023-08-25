using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshPathfinding : MonoBehaviour
{
    #region Variable

    [Header("Path Finding Component")]
    [SerializeField] private Transform[] points;
    private NavMeshAgent myNavAgent;
    private int destPoint;

    #endregion
    
    #region MonoBehaviour Callback

    private void Awake()
    {
        myNavAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        if (!myNavAgent.pathPending && myNavAgent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    #endregion
   

    #region Tsukuyomi Callback

    private void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        myNavAgent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    #endregion
}
