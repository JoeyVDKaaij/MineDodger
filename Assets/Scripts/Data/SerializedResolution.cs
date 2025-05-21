using UnityEngine;

[System.Serializable]
public struct SerializableResolution {
    public int width;
    public int height;
    public int refreshRate;
    
    public SerializableResolution(Resolution resolution) {
        width = resolution.width;
        height = resolution.height;
        refreshRate = resolution.refreshRate;
    }

    public Resolution ToUnityResolution() {
        Resolution r = new Resolution {
            width = this.width,
            height = this.height,
            refreshRate = this.refreshRate
        };
        return r;
    }
}