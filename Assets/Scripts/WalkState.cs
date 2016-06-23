using UnityEngine;
using System.Collections;

public class WalkState : IState {

    public PlayerStateMachine m_player;

    public WalkState(PlayerStateMachine _player)
    {
        m_player = _player;
        
    }

    public void UpdateState()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            ToJumpState();
        }

        Vector3 feetPosition = m_player.m_collideDetector.position;

        float directionOnX = Input.GetAxis("Horizontal");
        m_player.m_rb2D.velocity = new Vector2( m_player.m_accelerationCurve.Evaluate( Mathf.Abs( directionOnX ) ) * (Mathf.Sign( directionOnX ) * m_player.m_speedMax), m_player.m_rb2D.velocity.y );

        RaycastHit2D hit;
        hit = Physics2D.Raycast( feetPosition, Vector2.down, .5f, m_player.m_CollideWithMask );
        if( !hit.collider )
        {
            ToFallState();
        }
    }
    public void ToWalkState()
    {

    }
    public void ToJumpState()
    {
        //Debug.Log( "Jump" );
        m_player.m_rb2D.AddForce( Vector2.up * m_player.m_jumpImpluse, ForceMode2D.Impulse);
        m_player.m_currentState = m_player.m_jumpState;
    }
    public void ToFallState()
    {
        m_player.m_currentState = m_player.m_fallState;
    }
    public void ToDiveState()
    {

    }

    public void ToDuckState()
    {

    }


}
