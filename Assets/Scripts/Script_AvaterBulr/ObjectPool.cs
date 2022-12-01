using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<int,GameObject> alivepool;
    public GameObject poolinstance;
    public GameObject poolpos;
  
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            alivepool = new Dictionary<int, GameObject>();
            alivepool.Add(i, poolinstance);
            alivepool[i] = GameObject.Instantiate(poolinstance);
            alivepool[i].SetActive(true);
            alivepool[i].transform.position = new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        }// プールの最大サイズ
    
       
    }

    // Update is called once per frame
    void Update()
    {
        //IDを取得する
        //https://answers.unity.com/questions/995134/identifying-the-index-of-a-gameobject-in-an-array.html
    }
}
