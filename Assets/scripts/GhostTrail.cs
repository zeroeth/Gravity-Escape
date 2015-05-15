using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GhostTrail : MonoBehaviour {
    public int line_point_count = 0;
	public float line_width = 0.2F;

	public Vector3 last_position;
	public LineRenderer current_line;
	public List<LineRenderer> line_segments = new List<LineRenderer>();

	public float last_point_time = 0.0F;

	public Material off_color;
	public Material on_color;

    void Start()
	{
		current_line = new_line(off_color);
    }


    void Update()
	{
		// Thrust vs Glide
        if (Input.GetButtonDown("Fire1")) { current_line = new_line(on_color);  }
        if (Input.GetButtonUp  ("Fire1")) { current_line = new_line(off_color); }

		track_position();
    }


	public LineRenderer new_line(Material line_color)
	{
		GameObject line_object = new GameObject("Empty");

        LineRenderer line_renderer = line_object.AddComponent<LineRenderer>();

		line_renderer.material = line_color;
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
