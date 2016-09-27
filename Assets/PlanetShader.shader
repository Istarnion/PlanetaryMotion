// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/PlanetShader" {
	Properties {
		_MainColor ("Color", Color) = (1,1,1,1)
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth ("Outline width", Range(0.0, 1.0)) = 0.5
	}
	SubShader {
		Tags { "RenderType"="Opaque" }

		pass {
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform float4 _MainColor;
			uniform float4 _OutlineColor;
			uniform float _OutlineWidth;

			struct vertexInput {
				float4 pos : POSITION;
				float3 norm : NORMAL;
			};

			struct vertexOutput {
				float4 pos : SV_POSITION;
				float shade : COLOR;
			};

			vertexOutput vert(vertexInput v) {
				vertexOutput o;

				float3 normalDirection = normalize(mul(float4(v.norm, 0.0), unity_WorldToObject).xyz);
				float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - mul(UNITY_MATRIX_MVP, v.pos).xyz));

				o.shade = dot(normalDirection, viewDirection);
				o.pos = mul(UNITY_MATRIX_MVP, v.pos);

				return o;
			}

			float4 frag(vertexOutput v) : COLOR {
				if(v.shade < _OutlineWidth) {
					return _OutlineColor * v.shade;
				}
				else {
					return _MainColor;
				}
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
