// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// - Unlit
// - Scroll 2 layers /w Multiplicative op

Shader "Wistone/Anrufen/Wave" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base layer (RGB)", 2D) = "white" {}
	_DetailTex ("2nd layer (RGB)", 2D) = "white" {}
	_ScrollX ("Base layer Scroll speed X", Float) = 1.0
	_ScrollY ("Base layer Scroll speed Y", Float) = 0.0
	_Scroll2X ("2nd layer Scroll speed X", Float) = 1.0
	_Scroll2Y ("2nd layer Scroll speed Y", Float) = 0.0
	_AMultiplier ("Layer Multiplier", Float) = 0.5
}

SubShader {
	Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
	
	Blend One One
	Cull Off Lighting Off ZWrite Off Fog { Color (0,0,0,0) }

		
	CGINCLUDE
	#pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
	#include "UnityCG.cginc"
	sampler2D _MainTex;
	sampler2D _DetailTex;

	float4 _MainTex_ST;
	float4 _DetailTex_ST;
	
	fixed4 _Color;
	
	float _ScrollX;
	float _ScrollY;
	float _Scroll2X;
	float _Scroll2Y;
	float _AMultiplier;
	
	struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		float2 uv2 : TEXCOORD1;
		fixed4 color : TEXCOORD2;		
	};

	
	v2f vert (appdata_full v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.texcoord.xy,_MainTex) + frac(float2(_ScrollX, _ScrollY) * _Time);
		o.uv2 = TRANSFORM_TEX(v.texcoord.xy,_DetailTex) + frac(float2(_Scroll2X, _Scroll2Y) * _Time);
		
		float clr = _AMultiplier * v.color.a * _Color.a;
		o.color = fixed4(clr, clr, clr, clr) * _Color;

		return o;
	}
	ENDCG


	Pass {
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#pragma fragmentoption ARB_precision_hint_fastest		
		fixed4 frag (v2f i) : COLOR
		{
			fixed4 o;
			fixed4 tex = tex2D (_MainTex, i.uv);
			fixed4 tex2 = tex2D (_DetailTex, i.uv2);
			
			o = (tex * tex2) * i.color;
			
			return o;
		}
		ENDCG 
	}	
}
}
