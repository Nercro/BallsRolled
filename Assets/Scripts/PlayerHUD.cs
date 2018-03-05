using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {

    public Transform Player;
    public Vector3 Offset;

    public Slider playerSlider;

	void Update ()
    {
        transform.position = Player.position + Offset;
        playerSlider.value = Player.GetComponent<HealthManager>().Health;
	}
}
