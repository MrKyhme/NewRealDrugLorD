using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Transform))]
public class QT_AlignObjects : Editor
{

	void OnSceneGUI()
	{
 		Event e = Event.current;
		
		 if(e.type == EventType.keyDown)
			{		
				if (e.control && e.alt && e.keyCode == KeyCode.A)
				{
					Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
	           		RaycastHit hit;
	                if(Physics.Raycast(ray,out hit))	     
						{
						Undo.RegisterSceneUndo("Moved GameObjects.");
					 	Selection.gameObjects[0].transform.position = hit.transform.gameObject.transform.position;
						Selection.gameObjects[0].transform.rotation = hit.transform.gameObject.transform.rotation;
						Debug.Log("Aligned " + Selection.gameObjects[0].name + " to " + hit.transform.gameObject.name);
						}
					else
						Debug.LogError("Ray cast didn't hit. Make sure objects you want to align to has a collider.");
				}
				if (e.control && e.keyCode == KeyCode.T)
				{
					Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
				  	RaycastHit hit;
	                if(Physics.Raycast(ray,out hit))
						{
							Undo.RegisterSceneUndo("Moved GameObjects.");
							Selection.gameObjects[0].transform.position = hit.point;
							Debug.Log("Teleported " + Selection.gameObjects[0].name + " to "+hit.point);
						}
					else
						Debug.LogError("Ray cast didn't hit. Check to see if the surface you're teleporting to has a collider.");
				}
			
			}
               
	}
	
	
}
