using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;  // GameObject와 차이?
    bool m_IsPlayerInRange;
    public GameEnding gameEnding;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;  //JohnLemon의 위치는 두 발 사이의 지면이라는 것을 기억하실 겁니다.
            //관찰자가 JohnLemon의 질량 중심을 볼 수 있도록 하려면 Vector3.up을 추가하여 방향을 한 단위 위로 향하게 해야 합니다.
            Ray ray = new Ray (transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray,out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    // 벽을 넘어서 감지하는것을 방지하기위함
}
