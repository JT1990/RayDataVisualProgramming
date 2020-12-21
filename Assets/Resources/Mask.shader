Shader "ScratchCard/Mask" {
    Properties {
        _MainTex ("Main", 2D) = "white" {}
        _MaskTex ("Mask", 2D) = "white" {}
    }

    SubShader {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        ZTest Off
        Blend SrcAlpha OneMinusSrcAlpha
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _MaskTex;
            float4 _MainTex_ST;
            float4 _MaskTex_ST;

            struct a2v
            {
                float4 position: POSITION;
                half4 color: COLOR;
                float2 texcoord: TEXCOORD0;
            };

            struct v2f
            {
                float4 position: POSITION;
                half4 color: COLOR;
                float2 texcoord: TEXCOORD0;
            };

            v2f vert(a2v i)
            {
                v2f o;
                o.position = UnityObjectToClipPos(i.position);
				o.color = i.color;
                o.texcoord = TRANSFORM_TEX(i.texcoord, _MainTex);
                return o;
            }

            fixed4 frag(v2f v) : COLOR
            {
                fixed4 main_color = tex2D(_MainTex, v.texcoord);
                fixed4 mask_color = tex2D(_MaskTex, v.texcoord);
                fixed4 value = fixed4(v.color.r * main_color.r, v.color.g * main_color.g, 
                v.color.b * main_color.b, v.color.a * main_color.a * (1.0f - mask_color.a));
                return value;
            }
            ENDCG
        }
    }
}

