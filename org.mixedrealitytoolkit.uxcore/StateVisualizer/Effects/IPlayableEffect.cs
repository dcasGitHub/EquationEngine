// Copyright (c) Mixed Reality Toolkit Contributors
// Licensed under the BSD 3-Clause

using UnityEngine.Playables;

namespace MixedReality.Toolkit.UX
{
    /// <summary>
    /// An <see cref="IEffect"/> that is backed by a <see cref="Playable"/>.
    /// </summary>
    public interface IPlayableEffect : IEffect
    {
        /// <summary>
        /// The non-serialized runtime <see cref="Playable"/> generated by this <see cref="IEffect"/>.
        /// </summary>
        Playable Playable { get; }
    }
}
