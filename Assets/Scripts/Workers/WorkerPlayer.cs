using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class WorkerPlayer : Worker // INHERITANCE (CHILD)
{
    // Private/Protected attributes
    private NavMeshAgent navMeshAgent;
    private List<Vector3> decorationPositions = new List<Vector3>();
    private Vector3 currentPosition;

    // Private/Protected methods
    protected override void Start()
    {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        this.GetDecorationPositions();

        this.walkDuration = 5.0f;
        this.coroutineWaitTime = 5.0f;

        base.Start();
    }

    private void GetDecorationPositions()
    {
        GameObject[] decorations = GameObject.FindGameObjectsWithTag("Decoration");

        foreach (GameObject decoration in decorations)
        {
            Vector3 position = decoration.transform.position;
            this.decorationPositions.Add(position);
        }
    }

    // Overrided methods
    protected override IEnumerator Walk() // POLYMORPHISM (CHILD)
    {
        int index;
        Vector3 randomDecorationPosition;
        this.navMeshAgent.isStopped = true;

        do
        {
            index = Random.Range(0, this.decorationPositions.Count);
            randomDecorationPosition = this.decorationPositions[index];
        }
        while (randomDecorationPosition == this.currentPosition);

        this.currentPosition = randomDecorationPosition;
        this.navMeshAgent.SetDestination(randomDecorationPosition);
        this.navMeshAgent.isStopped = false;

        yield return null;
    }
}
