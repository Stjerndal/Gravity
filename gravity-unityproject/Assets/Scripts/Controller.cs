using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{

	public GameObject player;
	public bool engine = false;

	
	#if !(UNITY_ANDROID || UNITY_IPHONE) || UNITY_EDITOR
//	void OnMouseDown ()
//	{
//		
//	}
	#endif
	
	#if UNITY_ANDROID || UNITY_IPHONE
//	void Update() {
//		if(Input.touchCount > 0) {
//			foreach(Touch touch in Input.touches) {
//				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position)) {
//					handlePress();
//				}
//			}
//		}
//	}
	#endif

	void Update ()
	{
		Debug.DrawLine (player.rigidbody2D.position+player.rigidbody2D.velocity, player.rigidbody2D.position, Color.yellow);
//		if (Input.GetMouseButtonDown (0)) {
//				Debug.Log ("shoot!");
//				handlePress ();
//		}

//		if(Input.GetMouseButton(0))
//			handlePress(Input.mousePosition);

		if(Input.touchCount > 0) {
			foreach(Touch touch in Input.touches) {
					handlePress(touch.position);
			}
		}

		Vector2 max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
		Vector2 min = Camera.main.ScreenToWorldPoint(new Vector2(0,0));

		if(player.rigidbody2D.position.x > max.x || player.rigidbody2D.position.x < min.x || 
		   player.rigidbody2D.position.y > max.y || player.rigidbody2D.position.y < min.y) {
			player.rigidbody2D.position = new Vector2(0,0);
			player.rigidbody2D.velocity = new Vector2(0,0);
		}

	}

//	void OnMouseDown () {
//		engine = true;
//	}
//	
//	void OnMouseUp () {
//		engine = false;
//	}
	
	
	void handlePress (Vector2 inputPosition)
	{
		
		Vector2 inputWorldPoint = (Vector2) Camera.main.ScreenToWorldPoint(inputPosition);
		Vector2 mouseToPlayer =  player.rigidbody2D.position - inputWorldPoint;
//			Vector2 vec = (player.rigidbody2D.position - (Vector2) Input.mousePosition).normalized;
		player.rigidbody2D.AddForce(mouseToPlayer.normalized);
		Debug.DrawLine (inputWorldPoint, player.rigidbody2D.position, Color.red);

	}

}
