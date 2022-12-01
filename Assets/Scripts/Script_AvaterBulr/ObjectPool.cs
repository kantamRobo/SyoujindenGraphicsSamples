using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<int,GameObject> pool;
    public GameObject poolinstance;
    public GameObject poolpos;
  
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            pool = new Dictionary<int, GameObject>();
            pool.Add(i, poolinstance);
            pool[i] = GameObject.Instantiate(poolinstance);
            pool[i].SetActive(true);
            pool[i].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        }// プールの最大サイズ
    
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
