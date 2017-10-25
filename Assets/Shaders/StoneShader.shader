// This is learnt from lab4
// Gouraud Shader
//UNITY_SHADER_NO_UPGRADE

Shader "Unlit/StoneShader"
{
	Properties
	{
		_PointLightColor ("Point Light Color", Color) = (0, 0, 0)
		_PointLightPosition ("Point Light Position", Vector) = (0.0, 0.0, 0.0)
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform float3 _PointLightColor;
			uniform float3 _PointLightPosition;
			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;

			struct vertIn
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 normal : NORMAL;
				float4 color : COLOR;

			};

			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float4 color : COLOR;
				float2 uv : TEXCOORD0;
			};

			// Implementation of the vertex shader
			vertOut vert(vertIn v)
			{
				vertOut o;
				// Convert Vertex position and corresponding normal into world coords.
				float4 worldVertex = mul(unity_ObjectToWorld, v.vertex);
				float3 worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));

				// Calculate ambient RGB intensities
				float Ka = 0.25;
				float3 amb = v.color.rgb * UNITY_LIGHTMODEL_AMBIENT.rgb * Ka;

				// Calculate diffuse RBG reflections
				float fAtt = 1;
				float Kd = 10;
				float3 L = normalize(_PointLightPosition - worldVertex.xyz);
				float LdotN = dot(L, worldNormal.xyz);
				float3 dif = fAtt * _PointLightColor.rgb * Kd * v.color.rgb * saturate(LdotN);
				
				// Calculate specular reflections
				float Ks = 1;
				float specN = 50;
				float3 V = normalize(_WorldSpaceCameraPos - worldVertex.xyz);
				// Using classic reflection calculation:
				float3 R = normalize((2.0 * LdotN * worldNormal) - L);
				float3 spe = fAtt * _PointLightColor.rgb * Ks * pow(saturate(dot(V, R)), specN);


				// Combine Phong illumination model components
				o.color.rgb = amb.rgb + dif.rgb + spe.rgb;
				o.color.a = v.color.a;

				// Transform vertex in world coordinates to camera coordinates
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			// Implementation of the fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{
				return v.color + tex2D(_MainTex, v.uv);
			}
			ENDCG
		}
	}
}
