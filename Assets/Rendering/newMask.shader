Shader "Custom/newMask" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}

      SubShader {
        // draw after all opaque objects (queue = 2001):
        Tags { "Queue"="Geometry+1" }
        Pass {
          Blend Zero One // keep the image behind it
        }
      } 

	FallBack "Diffuse"
}
