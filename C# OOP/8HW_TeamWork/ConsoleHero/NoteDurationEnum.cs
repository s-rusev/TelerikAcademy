using System;

namespace ConsoleHero
{
    public enum NoteDurationEnum
    {
        Whole = 2500,
        Half = Whole / 2,
        Quarter = Half / 2,
        Eighth = Quarter / 2,
        Sixteenth = Eighth / 2,
        HalFplusPoint = Eighth * 3,
    }
}
