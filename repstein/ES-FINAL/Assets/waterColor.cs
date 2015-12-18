//using UnityEngine;
//using System.Collections;

//public class waterColor : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
	
//	}
	
//	// Update is called once per frame
//	void Update () {
	
//	}

//        VS_OUTPUT Output;

//        float3 Nrm = normalize(Input.Normal);
//        float3 ViewVec = normalize(Input.Position - viewPos);
//        Output.edge = dot(Nrm, ViewVec);
//        Output.Position = mul(Input.Position, mul(mul(view, projection), world));
//        Output.Normal = Nrm;
//        return (Output);
//    }

//        float4 ps_main(float edge:TEXCOORD0, float3 N1: TEXCOORD1) : COLOR0 
//    {   
//        float4 color;
//        float absV = abs(edge);
//        if(absV
//       {
//          float2 findColor = float2(absV * 2.5f, N1.x / 2.0f + N1.y / 2.0f);
//        color = tex2D(Texture1, findColor);
//    }
//       else
//       {
//         float2 findColor = float2((1 - absV) * 1.666f, N1.x / 2.0f + 0.5f);
//    color = tex2D(Texture0, 1-findColor);
//       }
//       return color;  
//}
