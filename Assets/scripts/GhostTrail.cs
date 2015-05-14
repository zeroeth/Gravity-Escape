using UnityEngine;
using System.Collections;

public class GhostTrail : MonoBehaviour {
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 200;
    void Start() {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
    }
    void Update() {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        int i = 0;
        while (i < lengthOfLineRenderer) {
            Vector3 pos = new Vector3(i * 0.1F, Mathf.Sin(i*0.2F + Time.time), 0);
            lineRenderer.SetPosition(i, pos);
            i++;
        }
    }
}
