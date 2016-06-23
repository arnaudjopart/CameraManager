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
        m_mouvementList.Add( new WindowCameraMouvement( this, new Vector2( 5, 2 ),new Vector2( 1, 1) ) );
        m_mouvementList.Add( new WindowCameraMouvement( this, new Vector2( 5, 2 ), new Vector2( -4, 0) ) );
        m_mouvementList.Add(new WindowCameraMouvement(this, new Vector2(0, 1.5f), new Vector2(0, 0)));
        m_currentCameraMouvement = m_mouvementList[ 2 ];
        m_currentCameraMouvement.Init( m_transform.position );
    }

    // Update is called once per frame
    void Update()
    {
        m_currentCameraMouvement.UpdateMouvement();
        //m_currentCameraMouvement.GetPosition();
        m_transform.position = m_currentCameraMouvement.GetPosition();
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(Vector3.up, Vector3.zero);
    }
    #endregion

    #region Private Members    
    private List<ICameraMouvement> m_mouvementList = new List<ICameraMouvement>();
    #endregion
}
