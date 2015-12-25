Shader "Custom/displacementShader" {
	Properties {

	}
	SubShader {
		void vert(inout appdata_full v)
		{
			v.vertex.xyz += v.normal.xyz * _Amount * abs(sin(_Time * 3)) * v.color.x;
			v.vertex.y += _Amount * abs(sin(_Time * 200)) * v.color.y;
		}
	} 

}
