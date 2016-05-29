using UnityEngine;
using System.Collections;

public class scr_HugeEyeLid : MonoBehaviour {

    bool IsReady;
    bool IsUpperEyeLid;
    int TotalEyes;
    float speed;

	public void associateEyeLid(bool IsUpperEyeLid, int TotalEyes)
    {
        this.IsUpperEyeLid = IsUpperEyeLid;
        this.TotalEyes = TotalEyes;
        speed = 45 / TotalEyes;
        IsReady = true;
    }
	
	
    public void RaiseEyeLid()
    {
        if (IsUpperEyeLid)
        {
            transform.Rotate(-speed, 0, 0);
        }
        else
        {
            transform.Rotate(speed, 0, 0);
        }
    }

    public void LowerEyeLid()
    {
        if (IsUpperEyeLid)
        {
            transform.Rotate(speed, 0, 0);
        }
        else
        {
            transform.Rotate(-speed, 0, 0);
        }
    }
}
