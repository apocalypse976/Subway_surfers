using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
   [SerializeField] private Transform _player;
    private void Update()
    {
        transform.position = new Vector3(_player.position.x,_player.position.y+7,_player.position.z-8f);
    }
}
