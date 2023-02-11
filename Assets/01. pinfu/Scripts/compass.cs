using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compass : MonoBehaviour
{
    public GameObject iconPrefab;
    public List<QestMarker> qestMarkers = new List<QestMarker>();

    public RawImage compassImage;
    Transform player_position;

    float compassUnit;

    public QestMarker one;
    QestMarker twe;
    QestMarker three;
    QestMarker four;

    // Start is called before the first frame update
    void Start()
    {
        player_position = GameObject.Find("unitychan(Clone)").GetComponent<Transform>();
        compassUnit = compassImage.rectTransform.rect.width / 360f;

        
        twe = GameObject.Find("key_1_collider(Clone)").GetComponent<QestMarker>(); 
        three = GameObject.Find("key_2_collider(Clone)").GetComponent<QestMarker>();
        four = GameObject.Find("key_3_collider(Clone)").GetComponent<QestMarker>();
        AddQestMaker(one);
        AddQestMaker(twe);
        AddQestMaker(three);
        AddQestMaker(four);
    }

    // Update is called once per frame
    void Update()
    {

        compassImage.uvRect = new Rect(player_position.localEulerAngles.y / 360f, 0f, 1f, 1f);
         foreach (QestMarker marker in qestMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
        }
    }

    public void AddQestMaker (QestMarker marker)
    {
        GameObject newMaker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMaker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        qestMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass (QestMarker marker)
    {
        Vector2 playerPos = new Vector2(player_position.transform.position.x, player_position.transform.position.z);
        Vector2 playerFwd = new Vector2(player_position.transform.forward.x, player_position.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);
        return new Vector2(compassUnit * angle, 0f);
    }
}
