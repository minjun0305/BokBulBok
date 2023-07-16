using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisburbTheWitch : MonoBehaviour
{
    public int currIndex;

    public List<GameObject> wa;
    public List<GameObject> wb;
    public List<GameObject> oa;
    public List<GameObject> ob;
    public List<GameObject> oc;
    public List<GameObject> res0;
    public List<GameObject> res1;
    public List<GameObject> res2;
    public List<GameObject> res3;

    public int life = 10;

    // Start is called before the first frame update
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetNextIndex()
    {
        currIndex = Random.Range(0, 8);
        return currIndex;
    }
}
