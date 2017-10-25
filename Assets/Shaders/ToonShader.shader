// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'



Shader "Unlit/ToonShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Diffuse Color", Color) = (1,1,1,1)
		_UnlitColor ("Unlit Color", Color) = (0.5,0.5,0.5,1)
		_DiffuseThreshold ("Diffuse Threshold", Range(-1.1,1)) = 0.1
		_SpecColor ("Specular Color", Color) = (1,1,1,1)
		_Shininess ("Specular Threshold", Range(0.5,1)) = 1
		_OutlineThickness ("Outline Threshold", Range(0,1)) = 0.1

	}
	SubShader
	{


		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _Color;
			uniform float4 _UnlitColor;
			uniform float _DiffuseThreshold;
			uniform float4 _SpecColor;
			uniform float _Shininess;
			uniform float _OutlineThickness;

			uniform float4 _LightColor0;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			
			//#include "UnityCG.cginc"

			struct vertIn
			{
				float4 vertex : POSITION;

				float2 uv : TEXCOORD0;

				float3 normal : NORMAL;

			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
					
				float2 uv : TEXCOORD0;

				float3 worldNormal : TEXCOORD1;

				float4 lightDir : TEXCOORD2;

				float3 viewDir : TEXCOORD3;
			};

			// The vertex shader
			vertOut vert(vertIn vi)
			{
				vertOut vo;
		
				// Convert vertex position and normals into world coords.
				float4 worldVertex = mul(unity_ObjectToWorld, vi.vertex);
				float3 worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), vi.normal.xyz));

				// View Direction
				vo.viewDir = normalize (_WorldSpaceCameraPos.xyz - worldVertex.xyz);

				// Light Direction
				float3 fragmentToLightSource = (_WorldSpaceCameraPos.xyz - worldVertex.xyz);
				vo.lightDir = float4 (
					normalize ( lerp (_WorldSpaceLightPos0.xyz, fragmentToLightSource, _WorldSpaceLightPos0.w) ),
					lerp (1.0, 1.0/length(fragmentToLightSource), _WorldSpaceLightPos0.w)
				);

				// Automatically replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'				
				vo.vertex = UnityObjectToClipPos(vi.vertex);

				vo.worldNormal = worldNormal;
				vo.uv = vi.uv;

				return vo;
			}
			
			// The fragment shader
			float4 frag(vertOut vo) : SV_Target
			{
				float nDotL = saturate ( dot (vo.worldNormal, vo.lightDir.xyz));
				float nDotV = dot (vo.worldNormal, vo.viewDir);

				// Diffuse, specular, outline Threshold calculation
				// Times 1000 is to make the edge sharp
				// Saturate is to limit the range to 0-1
				float diffuseCutoff = saturate( (nDotL - _DiffuseThreshold) * 1000);
				float specularCutoff = saturate ( (nDotL - _Shininess) * 1000);
				float outlineStrength = saturate ( (nDotV - _OutlineThickness) * 1000);

				// Calculate three different lights
				float3 ambientLight = (1 - diffuseCutoff) * _UnlitColor.xyz;
				float3 diffuseReflection = (1 - specularCutoff) * _Color.xyz * diffuseCutoff;
				float3 specularReflection = _SpecColor.xyz * specularCutoff;

				// Combine all the lights
				float3 combinedLight = (ambientLight + diffuseReflection) * outlineStrength + specularReflection;

				// Add texture
				return float4(combinedLight, 1.0) + tex2D(_MainTex, vo.uv);
			}
			ENDCG
		}
	}
}
