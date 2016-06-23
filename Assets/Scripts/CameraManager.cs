using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour {

    #region Public And Protected Members

    public Transform m_player;
    public Transform m_transform;
    public ICameraMouvement m_currentCameraMouvement;
    #endregion

    #region Main Methods
    // Use this for initialization
    void Awake()
    {
        m_transform = GetComponent<Transform>();
    }
    void Start()
    {
        m_mouvementList.Add( new WindowCameraMouvement( this, new Vector2( 5, 2 ) ) );
        m_currentCameraMouvement = m_mouvementList[ 0 ];
        m_currentCameraMouvement.Init( m_transform.position );
    }

    // Update is called once per frame
    void Update()
    {
        m_currentCameraMouvement.UpdateMouvement();
        //m_currentCameraMouvement.GetPosition();
        m_transform.position = m_currentCameraMouvement.GetPosition();
    }

    #endregion

    #region Private Members    
    private List<ICameraMouvement> m_mouvementList = new List<ICameraMouvement>();
    #endregion
}
