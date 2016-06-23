using UnityEngine;
using System.Collections;

public class PlayerStateMachine : MonoBehaviour {


    #region Public And Protected Members
    public float m_speedMax = 10;
    public float m_jumpImpluse = 10;
    public float m_diveForce =20;
    public LayerMask m_CollideWithMask;
    public AnimationCurve m_accelerationCurve;

    public WalkState m_walkState;
    public JumpState m_jumpState;
    public FallState m_fallState;
    public DiveState m_diveState;
    public IState m_currentState;

    [HideInInspector]
    public Transform m_collideDetector;
    

    [HideInInspector]
    public Rigidbody2D m_rb2D;
    [HideInInspector]
    public Transform m_transform;

    #endregion

    #region Main Methods
    // Use this for initialization
    void Awake()
    {
        m_transform = GetComponent<Transform>();
        m_rb2D = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        m_walkState = new WalkState( this );
        m_jumpState = new JumpState( this );
        m_fallState = new FallState( this );
        m_diveState = new DiveState( this );
        m_currentState = m_fallState;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentState.UpdateState();
    }
    void OnGUI()
    {
        GUILayout.Button(m_currentState.ToString());
    }
    #endregion
    #region Utils

    #endregion
    #region Private Members

    #endregion

}
