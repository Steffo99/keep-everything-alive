Shader "Custom/Static"
{
    Properties
    {
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
                return frac(sin(dot(coordinates, float2(231.231f, _Time.y))) * 11111.1f);
            }

            float4 frag (v2f i) : SV_Target
            {
                float r = random(i.vertex.xy);
                return float4(r, r, r, 1.0f);
            }
            ENDCG
        }
    }
}
