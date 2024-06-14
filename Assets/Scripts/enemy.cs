using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] float enemySpeed;
    [SerializeField] float distance; //distance of enemy to player
    [SerializeField] float noticeDistance; //how far away you are before it sees you
    [SerializeField] Vector3 startPos;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPos = gameObject.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if(distance <= noticeDistance)
        {
           chase(); //chase
        }
        if(distance > noticeDistance)
        {
           goHome(); //go back home
        }

        void chase()
        {
            //enemy watches player
            Vector3 playerPosition = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
            transform.LookAt(playerPosition);
            //enemy moves towards player
            transform.Translate(0,0, enemySpeed * Time.deltaTime);
        }

        void goHome()
        {
            transform.LookAt(startPos);
            transform.Translate(0,0, enemySpeed * Time.deltaTime);

        }
    }
}
