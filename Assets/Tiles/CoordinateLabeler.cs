using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.red;
    
    TextMeshPro textLabel;
    Vector2Int coordinates;
    Waypoint waypoint;

    private void Awake()
    {
        textLabel = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        UpdateObjectName();
    }
    private void Start()
    {
        waypoint = GetComponentInParent<Waypoint>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        ColorCoordinates();
        if(Input.GetKeyDown(KeyCode.T))
            ToggleLable();
    }

    private void ColorCoordinates()
    {
        if (waypoint.IsPlacable)
            textLabel.color = defaultColor;
        else
            textLabel.color = blockedColor;
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x/UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z);
        textLabel.text = coordinates.ToString();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ToggleLable()
    {
        textLabel.enabled = !textLabel.enabled;
    }
}
