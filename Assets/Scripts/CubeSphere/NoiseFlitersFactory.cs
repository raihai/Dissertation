using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseFlitersFactory 
{
    public static INoiseFilters CreateNoiseFilter(NoiseSettings setting)
    {
        switch (setting.filterType)
        {
            case NoiseSettings.FilterType.Simple:
                return new SimpleNoiseFilter(setting.simpleNoiseSettings);
            case NoiseSettings.FilterType.Ridgid:
                return new RigidNoiseFilter(setting.ridgidNoiseSettings);
        }
        return null;
    }
}
