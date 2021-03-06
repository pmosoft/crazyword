﻿using UnityEngine;
using System.Collections;

public class SwipeMotions : MonoBehaviour {

	public float minSwipeDistY;

	public float minSwipeDistX;

	public GUIText Swipe;

	private Vector2 startPos;


	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0];

			switch (touch.phase) {
			case TouchPhase.Began:
				startPos = touch.position;
				break;
			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

					if(swipeValue > 0) Swipe.text = "Up Swipe";
					else if(swipeValue < 0) Swipe.text = "Down Swipe";

				}

				float swipeDistHorizontal = (new Vector3(touch.position.x,0,0) - new Vector3(startPos.x,0,0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) {
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

					if(swipeValue > 0) Swipe.text = "Right Swipe";
					else if(swipeValue < 0) Swipe.text = "Left Swipe";
				}
				break;
			}
		}
	
	}
}
