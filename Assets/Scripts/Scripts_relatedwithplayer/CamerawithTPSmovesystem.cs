using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerawithTPSmovesystem : MonoBehaviour
{
    // Start is called before the first frame updat
    //
    [SerializeField]
    private ThirdPersonController tpscontroller;
    [SerializeField]
    private Camera camera;
    //移動時のカメラ処理のバッファ。好きに変更してよい
    [SerializeField]
    private readonly float epsilon= 0.01f;
    //カメラのFOV。これらも任意に変更してよい
    [SerializeField]
    private readonly float maxfov = 60f;
    [SerializeField]
    private readonly float minfov = 30f;

    void Start()
    {
        camera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentfov = camera.fieldOfView;
        //プレイヤーが移動中は
        if (tpscontroller.MoveSpeed >epsilon )
        {
            if (tpscontroller.MoveSpeed == tpscontroller.SprintSpeed) {
                camera.fieldOfView = Mathf.Lerp(currentfov, minfov, Time.deltaTime);
                    }
            else
            {
                camera.fieldOfView = Mathf.Lerp(currentfov, maxfov, Time.deltaTime);

            }
        }
    }
}
