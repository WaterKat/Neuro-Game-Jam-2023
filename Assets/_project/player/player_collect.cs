using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collect : MonoBehaviour
{
    public Transform player_collectible_container;
    List<GameObject> collectibles = new List<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.gameObject.tag == "collectible")
        {
            collectible collectible_script = other.gameObject.GetComponentInParent<collectible>();
            GameObject collectible_game_object = collectible_script.Collect();
            collectible_game_object.transform.parent = player_collectible_container;
            collectible_game_object.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
