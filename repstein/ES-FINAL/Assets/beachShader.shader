Shader "UnityCoder/BeachSandTest1" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess("Shininess", Range(0.03, 1)) = 0.078125
		_CutOff("CutOff", Range(0.0, 1)) = 0.5
		_MainTex("Base (RGB)", 2D) = "white" {}
	_BumpMap("Normal map", 2D) = "bump" {}
	_SpecMap("Specular map", 2D) = "black" {}
	_Mask("Mask", 2D) = "black" {}
	}
		SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 400

		CGPROGRAM
#pragma surface surf BlinnPhong
#pragma exclude_renderers flash
#pragma target 3.0

		sampler2D _MainTex;
	sampler2D _BumpMap;
	sampler2D _SpecMap;
	sampler2D _Mask;
	fixed4 _Color;
	fixed _CutOff;
	half _Shininess;

	struct Input {
		float2 uv_MainTex;
		float2 uv_Mask;
	};

	void surf(Input IN, inout SurfaceOutput o) {

		float2 pan = float2(0,_SinTime.y*0.5f - 0.5f);

		fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);

		//    fixed wet = clamp(tex2D(_Mask, IN.uv_Mask+pan).r,0,0.5f); //,0,_CutOff)*2;
		fixed wet = tex2D(_Mask, IN.uv_Mask + pan).r;
		//fixed wet = tex2D(_Mask, IN.uv_Mask).r;
		//    fixed4 specTex = tex2D(_SpecMap, IN.uv_MainTex+pan);
		fixed4 specTex = tex2D(_SpecMap, IN.uv_MainTex);
		fixed4 specTex2 = tex2D(_SpecMap, IN.uv_MainTex + pan*0.2f);

		float4 norm1 = tex2D(_BumpMap, IN.uv_MainTex);
		float4 norm2 = tex2D(_BumpMap, IN.uv_MainTex + pan * 2);

		fixed4 tex2 = tex2D(_MainTex, IN.uv_MainTex + pan);

		//fixed3 c = tex.rgb;
		fixed3 cc = lerp(tex.rgb,tex2.rgb*0.2f,wet*_CutOff);

		float g = clamp(lerp(specTex2.r,0,cc.r),0,1);
		float g2 = clamp(lerp(specTex.r,specTex2.r,wet),0,1);

		o.Albedo = cc;
		o.Gloss = g;
		//o.Emission = g*10;
		o.Alpha = 1; //tex.a * _Color.a;
		o.Specular = g2;//*_Shininess;// * specTex.g * wet;
		o.Normal = UnpackNormal(lerp(norm1,norm2,g));
	}
	ENDCG
	}

		FallBack "Specular"
}
