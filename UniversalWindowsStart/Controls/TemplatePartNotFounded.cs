using System;
using System.Runtime.Serialization;

namespace UniversalWindowsStart.Controls
{
    [Serializable]
    internal class TemplatePartNotFounded : Exception
    {
        public string PartName { get; set; }
        public Type PartType { get; set; }

        public TemplatePartNotFounded()
        {
        }

        public TemplatePartNotFounded(string partName, Type partType)
        {
            PartName = partName;
            PartType = partType;
        }

        public TemplatePartNotFounded(string message) : base(message)
        {
        }

        public TemplatePartNotFounded(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TemplatePartNotFounded(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}