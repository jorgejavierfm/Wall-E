using System;

namespace FlowChartDesigner
{
    /// <summary>
    /// Determina el tipo de pin.
    /// </summary>
    [Serializable]
    public enum PinType
    {
        /// <summary>
        /// Pin de entrada.
        /// </summary>
        Input,
        /// <summary>
        /// Pin de salida.
        /// </summary>
        Output
    }
}
