using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AvaterBlur : MonoBehaviour
{
    [SerializeField]
    private Shader blurmaterialshader;
    [SerializeField]
    private GameObject parentobject;
    [SerializeField]
    private Animator parentanimator;
    private Animator bluranimator;
    private List<GameObject> blurObjects;
    [SerializeField]
    private static readonly int gameobjectnum;
    [SerializeField]
    private static readonly int blurconst;
    // Start is called before the first frame update
    void Start()
    {
        Animator bluranimator = parentanimator;
        for (int i = 0; i < gameobjectnum; i++)
        {
            GameObject blurinstance = new GameObject();

            blurinstance.AddComponent<Animator>();
            blurinstance.name = "blurobjects" + i;
            blurinstance.AddComponent<SkinnedMeshRenderer>();

            blurinstance.GetComponent<SkinnedMeshRenderer>().sharedMaterial = new Material(blurmaterialshader);

            blurinstance.GetComponent<SkinnedMeshRenderer>().bones = parentobject.GetComponent<SkinnedMeshRenderer>().bones;
            Material parentmaterial = parentobject.GetComponent<SkinnedMeshRenderer>().sharedMaterial;
            parentobject.GetComponent<SkinnedMeshRenderer>().sharedMaterial.SetColor("blurmaterialcolor", new Color(parentmaterial.color.r,
                                                                                    parentmaterial.color.g,
                                                                                    parentmaterial.color.b,
                                                                                    GetAlpha(i)));

            blurinstance.GetComponent<SkinnedMeshRenderer>().sharedMesh = parentobject.GetComponent<SkinnedMeshRenderer>().sharedMesh;
            blurinstance.transform.rotation = parentobject.transform.rotation;
            blurinstance.transform.localPosition = GetLocalPosition(parentobject.transform.position, i);
            blurObjects.Add(blurinstance);
            blurObjects[i].SetActive(false);
        }
    }
    Vector3 GetLocalPosition(Vector3 parent, int instanceCount)
    {
        Vector3 temp = new Vector3(0, 0, 0);

        for (int i = 0; i < instanceCount; i++)
        {
            temp = new Vector3(parent.x + i, 0, parent.z + i);
            return temp;
        }
        return temp;
    }
    int GetAlpha(int instanceCount)
    {
        int alpha = 0;
        for (int i = 0; i < instanceCount; i++)
        {
            alpha = instanceCount / 1;
            return alpha;
        }
        return alpha;
    }
    // Update is called once per frame
    void Update()
    {
        //分身をかける
        //分身の数だけ、時間をカウントする

        int time = 0;
        if (time < blurObjects.Count) {

            time = (int)Time.deltaTime;
            blurObjects[time].SetActive(true);
            blurObjects[time].transform.localPosition = Execute_MotionBlur(parentobject.transform.position, time);
        }
        else { time = 0;

            for (int i = 0; i < blurObjects.Count; i++)
            {
                blurObjects[i].SetActive(false);
            }


        }
    }

    Vector3 Execute_MotionBlur(Vector3 parentpos,int index)
    {
        return Vector3.Lerp(parentpos, new Vector3(parentpos.x * index, 0, parentpos.z * index),Time.deltaTime);
    }
}
