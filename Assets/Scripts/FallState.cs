using UnityEngine;
using System.Collections;

public class FallState : IState
{

    public PlayerStateMachine m_player;

    public FallState( PlayerStateMachine _player )
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
            ToWalkState();
        }

        if( Input.GetKeyDown( KeyCode.DownArrow ) )
        {
            ToDiveState();
        }

        float directionOnX = Input.GetAxis("Horizontal");
        m_player.m_rb2D.velocity = new Vector2( m_player.m_accelerationCurve.Evaluate( Mathf.Abs( directionOnX ) ) * (Mathf.Sign( directionOnX ) * m_player.m_speedMax), m_player.m_rb2D.velocity.y );
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
        Debug.Log( "Already in State" );
    }
    public void ToDiveState()
    {
        m_player.m_rb2D.AddForce( Vector2.down * m_player.m_diveForce, ForceMode2D.Impulse );
    }

    public void ToDuckState()
    {

    }


}
