using UnityEngine;

/// <summary>
/// Place an UI element to a world position
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class MapDisplay : MonoBehaviour
{
    Camera cam;
    public GameObject player;
    public RectTransform locator;

    /// <summary>
    /// Initiate
    /// </summary>
    void Start()
    {
        cam = Camera.main;
    }

    /// <summary>
    /// Move the UI element to the world position
    /// </summary>
    /// <param name="objectTransformPosition"></param>
    public void Update()
    {
        Vector3 pos = player.transform.position/10f;
        pos = new Vector3(-pos.x, -pos.z, 0);
        locator.localPosition = pos;
        print(locator.localPosition);
    }
}
