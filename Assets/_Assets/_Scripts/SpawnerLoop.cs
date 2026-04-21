using UnityEngine;

public class SpawnerLoop : MonoBehaviour
{
    [Header("Assign in Inspector")]
    [SerializeField] private Transform[] roadSegments;

    [Header("Settings")]
    [SerializeField] private float segmentLength = 10f;
    [SerializeField] private float offCameraZ = -15f;

    private void Update()
    {
        LoopSegments();
    }

    private void LoopSegments()
    {
        Transform first = GetFirstSegment();

        // Only move ONE segment when it goes behind camera
        if (first.position.z <= offCameraZ)
        {
            Transform last = GetLastSegment();

            float newZ = last.position.z + segmentLength;

            first.position = new Vector3(
                first.position.x,
                first.position.y,
                newZ
            );
        }
    }

    private Transform GetFirstSegment()
    {
        Transform first = roadSegments[0];

        foreach (Transform t in roadSegments)
        {
            if (t.position.z < first.position.z)
                first = t;
        }

        return first;
    }

    private Transform GetLastSegment()
    {
        Transform last = roadSegments[0];

        foreach (Transform t in roadSegments)
        {
            if (t.position.z > last.position.z)
                last = t;
        }

        return last;
    }
}