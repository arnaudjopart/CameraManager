using UnityEngine;
using System.Collections;

public class DiveState : IState {

    public PlayerStateMachine m_player;

    public DiveState( PlayerStateMachine _player )
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        Vector3 feetPosition = m_player.m_collideDetector.position;

        Debug.DrawLine( feetPosition, feetPosition + Vector3.down * .1f, Color.red );
        RaycastHit2D hit;
        hit = Physics2D.Raycast( feetPosition, Vector2.down, .5f, m_player.m_CollideWithMask );
        if( hit.collider && m_player.m_rb2D.velocity.y < 0 )
        {
            Debug.Log( "On Ground" );
            ToWalkState();
        }

    }
    public void ToWalkState()
    {
        m_player.m_currentState = m_player.m_walkState;
    }
    public void ToJumpState()
    {


    }
    public void ToFallState()
    {
        
    }
    public void ToDiveState()
    {
        Debug.Log( "Already in State" );
    }

    public void ToDuckState()
    {

    }


}
