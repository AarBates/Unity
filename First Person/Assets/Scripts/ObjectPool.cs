using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objPrefab;
    public int createOnStart;
    private List<GameObject> pooledObjs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < createOnStart; x ++)
        {
            CreateNewObject();
        }
    }

    GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objPrefab);
        obj.SetActive(false);
        pooledObjs.Add(obj);

        return obj;
    }
    //Whenever a new object is needed, call the following script
    public GameObject GetObject()
    {
        // Collect all of the inactive world objects
        GameObject obj = pooledObjs.Find(x => x.activeInHierarchy == false);
        // If the scene has no active objects, create a new object
        if(obj == null)
        {
            obj = CreateNewObject();
        }
        // Activate created objects
        obj.SetActive(true);

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
