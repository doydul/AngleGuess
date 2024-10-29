using UnityEngine;

public class AngleRenderer : MonoBehaviour {
    
    [SerializeField] float lineLength = 3;
    [SerializeField] float guideRadius = 1;
    [SerializeField] int degreesPerVertex = 10;
    
    public LineRenderer mainLine;
    public LineRenderer angleLine;
    
    public Vector3 position {
        get => transform.position;
        set => transform.position = value;
    }
    
    int _angle;
    public int angle {
        get => _angle;
        set => SetAngle(value);
    }
    
    void SetAngle(int value) {
        mainLine.positionCount = 3;
        mainLine.SetPositions(new Vector3[] {
            new Vector3(0, lineLength),
            new Vector3(0, 0),
            new Vector3(Mathf.Sin(Mathf.Deg2Rad * value) * lineLength, Mathf.Cos(Mathf.Deg2Rad * value) * lineLength)
        });
        
        angleLine.positionCount = (int)(value / degreesPerVertex) + 2;
        var points = new Vector3[angleLine.positionCount];
        for (int i = 0; i < points.Length; i++) {
            float angle = degreesPerVertex * i;
            if (angle > value) angle = value;
            points[i] = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle) * guideRadius, Mathf.Cos(Mathf.Deg2Rad * angle) * guideRadius);
        }
        angleLine.SetPositions(points);
    }
}