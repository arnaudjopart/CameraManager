using UnityEngine;
using System.Collections;

public interface ICameraMouvement {

    void UpdateMouvement();
    void Init(Vector3 vector);
    Vector3 GetPosition();

}
