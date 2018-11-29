using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImageSlicer {

	public static Texture2D[,] GetSlices(Texture2D image, int blocksPerLine) {
        int imageSize = Mathf.Min(image.width, image.height);
        int blocksSize = imageSize/blocksPerLine;

        Texture2D[,] blocks = new Texture2D[blocksPerLine, blocksPerLine];

        for(int i = 0; i < blocksPerLine; i++) {
			for(int j = 0; j < blocksPerLine; j++) {
				Texture2D block = new Texture2D(blocksSize, blocksSize);
                block.wrapMode = TextureWrapMode.Clamp;
                block.SetPixels(image.GetPixels(j*blocksSize, i*blocksSize, blocksSize, blocksSize));
                block.Apply();
                blocks[j, i] = block;
			}
		}
        return blocks;
    }
}
