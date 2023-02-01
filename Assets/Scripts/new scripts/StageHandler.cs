using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHandler : MonoBehaviour
{
    private static Queue<Queue<GameObject>> stages = new Queue<Queue<GameObject>>();

    private static Queue<GameObject> currentStage;

    public static GameObject AddToStage(GameObject elem)
    {
        currentStage.Enqueue(elem);
        return elem;
    }
    public static void AddToStage(params GameObject[] elems)
    {
        foreach (GameObject elem in elems)
        {
            AddToStage(elem);
        }
    }

    public static void NewStage()
    {
        currentStage = new Queue<GameObject>();
        stages.Enqueue(currentStage);
    }

    public static void ClearStage()
    {
        foreach (var elem in stages.Peek())
        {
            Destroy(elem);
        }
        stages.Dequeue();
    }
}
