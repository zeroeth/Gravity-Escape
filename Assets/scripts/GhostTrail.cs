using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GhostTrail : MonoBehaviour {
    public Color white = Color.white;
    public Color red   = Color.red;
    public int line_point_count = 0;
	public float line_width = 0.2F;

	Vector3 last_position;
	LineRenderer current_line;
	List<LineRenderer> line_segments = new List<LineRenderer>();

	float last_point_time = 0.0F;

    void Start()
	{
		current_line = new_line(white);
    }


    void Update()
	{
		// Thrust vs Glide
        if (Input.GetButtonDown("Fire1")) { current_line = new_line(red);   }
        if (Input.GetButtonUp  ("Fire1")) { current_line = new_line(white); }

		track_position();
    }


	LineRenderer new_line(Color line_color)
	{
		GameObject line_object = new GameObject("Empty");

        LineRenderer line_renderer = line_object.AddComponent<LineRenderer>();
        line_renderer.material = new Material(Shader.Find("Particles/Additive"));
        line_renderer.SetColors(line_color, line_color);
        line_renderer.SetWidth(line_width, line_width);

		// Reset for new line
		line_point_count = 0;
        line_renderer.SetVertexCount(line_point_count);

		// position of last trail end point
		if(line_segments.Count > 0)
		{
			line_point_count = 1;
			line_renderer.SetVertexCount(line_point_count);
			line_renderer.SetPosition(line_point_count-1, last_position);
		}

		// List of line segments for this object
		line_segments.Add(line_renderer);

		return line_renderer;
	}


	void track_position()
	{
		if(should_track())
		{
			Vector3 position = new Vector3(transform.position.x, transform.position.y);

			last_position = position;

			line_point_count += 1;
			current_line.SetVertexCount(line_point_count);
			current_line.SetPosition(line_point_count-1, position);
		}
	}


	bool should_track()
	{
		if(Time.time - last_point_time > 0.001F)
		{
			last_point_time = Time.time;
			return true;
		}
		return false;
	}
}
