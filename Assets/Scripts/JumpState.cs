using UnityEngine;
using System.Collections;

public class JumpState : IState
{

    public PlayerStateMachine m_player;

    public JumpState( PlayerStateMachine _player )
    {
        m_player = _player;
    }

    public void UpdateState()
    {
        float directionOnX = Input.GetAxis("Horizontal");
        m_player.m_rb2D.velocity = new Vector2( m_player.m_accelerationCurve.Evaluate( Mathf.Abs( directionOnX ) ) * (Mathf.Sign( directionOnX ) * m_player.m_speedMax), m_player.m_rb2D.velocity.y );
        if( m_player.m_rb2D.velocity.y < .1 )
        {
            ToFallState();
        }
        if( Input.GetKeyDown( KeyCode.DownArrow ) )
        {
            ToDiveState();
        }
    }
    public void ToWalkState()
    {
        m_player.m_currentState = m_player.m_walkState;
    }
    public void ToJumpState()
    {
        Debug.Log( "Already in JumpState" );
        
    }
    public void ToFallState()
    {
        m_player.m_currentState = m_player.m_fallState;
    }
    public void ToDiveState()
    {
        m_player.m_rb2D.AddForce( Vector2.down * m_player.m_diveForce, ForceMode2D.Impulse );
        m_player.m_currentState = m_player.m_diveState;
    }

    public void ToDuckState()
    {

    }


}
