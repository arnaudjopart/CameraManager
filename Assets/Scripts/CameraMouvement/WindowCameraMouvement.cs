using UnityEngine;
using System.Collections;

public class WindowCameraMouvement : ICameraMouvement {


    
    public WindowCameraMouvement(CameraManager _cam,Vector2 _dimensionOfWindow, Vector2 _offSet)
    {
        m_camera = _cam;
        m_offSet = _offSet;
        m_dimension = _dimensionOfWindow;
    }
    public void Init(Vector3 _vector)
    {
        m_position = _vector;
    }
    public void UpdateMouvement()
    {
        float distanceX = m_camera.m_player.position.x - m_camera.m_transform.position.x;
        float distanceY = m_camera.m_player.position.y - m_camera.m_transform.position.y;
        // Update Offset

        bool isMovingRight = distanceX > 0 && distanceX > m_dimension.x+m_offSet.x;
        bool isMovingLeft = distanceX<0 && Mathf.Abs(distanceX)>m_dimension.x;
        bool isMovingUP = distanceY>0 && distanceY>m_dimension.y;
        bool isMovingDown = distanceY<0 && Mathf.Abs(distanceY)>m_dimension.y;

        Vector3 position = m_position;

        if( isMovingRight )
        {
            position.x = m_camera.m_player.position.x - m_dimension.x -m_offSet.x;            
        }

        if( isMovingLeft )
        {
            position.x = m_camera.m_player.position.x + m_dimension.x;
            
        }
        if( isMovingUP )
        {
            position.y = m_camera.m_player.position.y - m_dimension.y;
        }
        if( isMovingDown )
        {
            position.y = m_camera.m_player.position.y + m_dimension.y;            
        }

        
        m_position = position;
        DrawLimits();
        
        
    }

    
    public Vector3 GetPosition()
    {
        return m_position;
    }
    #region Private Methods

    private void DrawLimits()
    {
        
    }

    #endregion
    #region Private Members

    private Vector3 m_position;
    private Vector3 m_offSet;
    private Vector3 m_dimension;
    private CameraManager m_camera;

    #endregion  

}
