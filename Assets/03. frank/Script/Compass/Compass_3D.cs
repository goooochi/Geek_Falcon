using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass_3D : MonoBehaviour
{
    public RectTransform compassBarTransform;

    public RectTransform objectiveMarkerTransform;
    public RectTransform northMArkerTransform;
    public RectTransform southMakerTransform;

    public Transform cameraObjectTransform;
    public Transform objectiveObjectTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetMarkerPosition(objectiveMarkerTransform, objectiveMarkerTransform.position);
        SetMarkerPosition(northMArkerTransform, Vector3.forward * 1000);
        SetMarkerPosition(southMakerTransform, Vector3.back * 1000);

    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPosition)
    {
        Vector3 directionToTarget = worldPosition - cameraObjectTransform.position;
        float angle = Vector2.Angle(new Vector2(directionToTarget.x,
            directionToTarget.z), new Vector2(cameraObjectTransform.transform.forward.x,
            cameraObjectTransform.transform.forward.z));
        float compassPositionX = Mathf.Clamp(2 * angle / Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width / 2 * compassPositionX, 0);
    }
}
