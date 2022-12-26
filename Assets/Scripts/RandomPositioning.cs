using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositioning : MonoBehaviour
{
    public Camera _Camera;
    public GameObject PointBoard;

    private void Start()
    {
        instantiateAtRandom();
    }

    public void instantiateAtRandom()
    {
        Transform cameraViewPoint = _Camera.transform;
        var position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
        GameObject pointBoard = Instantiate(PointBoard, position, Quaternion.identity);
        pointBoard.transform.LookAt(cameraViewPoint);
    }
}
