Shader "Custom/PlanetShader" {
	Properties {
		_MainColor ("Color", Color) = (1,1,1,1)
		_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth ("Outline width", Range(0.0, 0.03)) = 0.005
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
				float shade;
			};

			vertexOutput vert(vertexInput v) {
				vertexOutput o;

				float3 normalDirection = normalize(mul(float4(v.norm, 0.0), _World2Object).xyz);
				float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - mul(UNITY_MATRIX_MVP, v.pos).xyz));

				o.shade = dot(normalDirection, viewDirection);

				return o;
			}

			float4 frag(vertexOutput v) : COLOR {
				return float(v.shade, v.shade, v.shade, 1.0);
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
