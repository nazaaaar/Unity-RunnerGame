using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawning : MonoBehaviour
{
    public GameObject plane;
    public GameObject food;
    private GameObject thisPlane;
    public Material material2;
    public Material material3;
    private PlaneMovement planeMovement;
    private float z = 1;
    private bool isPositive = true;
    public static Spawning instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
    }
    void Start()
    {
        NewSpawn();
        NewSpawn();
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private int k = 1;
    private bool Spawn()
    {
        
        z += Random.Range(5, 8f);
        int type;
        if (k > 4) type = 6;
        else if (k < 3) type = Random.Range(0, 6);
        else if (k == 4) type = Random.Range(0, 7);
        else type = Random.Range(0, 8);

        if (type < 4) type = 1;
        else if (type < 6) type = 2;
        else type = 3;

        k++;

        float speed;
        float x;

        switch (type)
        {
            

            case 1:
                speed = Random.Range(5.0f, 6.5f);
                if (!isPositive) speed *= -1;
                isPositive = !isPositive;

                x = Random.Range(-14f, 0);
                Instantiate(plane, new Vector3(x, 0, z), Quaternion.identity).GetComponent<PlaneMovement>().speed = speed;
                Instantiate(plane, new Vector3(x + Random.Range(6, 14f), 0, z), Quaternion.identity).GetComponent<PlaneMovement>().speed = speed;
                break;
            case 2:
                speed = Random.Range(6.5f, 7f);
                if (!isPositive) speed *= -1;
                isPositive = !isPositive;

                thisPlane = Instantiate(plane, new Vector3(Random.Range(-14f, 14), 0, z), Quaternion.identity);
                thisPlane.GetComponent<Renderer>().material = material2;
                planeMovement = thisPlane.GetComponent<PlaneMovement>();
                planeMovement.type = 2;
                planeMovement.speed = speed;
                break;

            case 3:
                x = Random.Range(-3f, 3);
                thisPlane = Instantiate(plane, new Vector3(x, 0, z), Quaternion.identity);
                thisPlane.GetComponent<PlaneMovement>().speed = 0;
                thisPlane.GetComponent<Renderer>().material = material3;
                Instantiate(food, new Vector3(x, 1, z), Quaternion.identity).GetComponent<FoodComponent>().player = gameObject.GetComponentsInChildren<Transform>()[1];
                k = 0;
                return true;
        }
        return false;
    }
    static public void NewSpawn()
    {
        while (!instance.Spawn());
    }

    public static void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
