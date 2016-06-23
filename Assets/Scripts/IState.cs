using UnityEngine;
using System.Collections;

public interface IState {

    void UpdateState();
    void ToWalkState();
    void ToJumpState();
    void ToFallState();
    void ToDiveState();
    void ToDuckState();

}
