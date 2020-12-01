using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class ARManager : MonoBehaviour
{
    [Header("點擊後要生成的物件")]
    public GameObject obj;
    [Header("AR 管理器")]
    public ARRaycastManager arManager;

    private Vector2 pointmouse;

    private List<ARRaycastHit> hits;

    private void Tap()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pointmouse = Input.mousePosition;
            print(pointmouse);

            if(arManager.Raycast(pointmouse, hits,TrackableType.PlaneWithinPolygon))
            {
                Instantiate(obj, hits[0].pose.position, Quaternion.identity);

            }


        }
    }
    private void Update()
    {
            Tap();
    }


}

