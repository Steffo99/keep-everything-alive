Shader "Custom/Static"
{
    Properties
    {
        _Brightness ("Brightness", Range(0.0, 1.0)) = 0.1
        _Multiplier ("Multiplier", Float) = 11111.1
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Brightness;
            float _Multiplier;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float random(float2 coordinates) {
                return frac(sin(dot(coordinates, float2(_Time.x + 1, _Time.y + 1))) * _Multiplier);
            }

            float4 frag (v2f i) : SV_Target
            {
                float r = random(i.vertex.xy) * _Brightness;
                return float4(r, r, r, 1.0);
            }
            ENDCG
        }
    }
}
