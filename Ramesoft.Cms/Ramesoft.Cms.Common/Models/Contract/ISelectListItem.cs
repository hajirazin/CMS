using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ramesoft.Cms.Common.Models.Contract
{
    /// <summary>
    /// The Selectable interface.
    /// </summary>
    public interface ISelectable
    {
        /// <summary>
        /// Gets the text.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        string Value { get; }
    }
}
