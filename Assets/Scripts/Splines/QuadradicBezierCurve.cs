using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticBezierCurve
{
	public Vector3 start;
	public Vector3 middle;
	public Vector3 end;

	public QuadraticBezierCurve(Vector3 start, Vector3 middle, Vector3 end)
	{
		this.start = start;
		this.middle = middle;
		this.end = end;
	}

	public Vector3 GetQuadraticBezierPoint(float t)
	{
		return Mathf.Pow(1 - t, 2) * start + 2 * t * (1 - t) * middle + Mathf.Pow(t, 2) * end;
	}

}