﻿#region Copyright & License

// Copyright © 2020 - 2021 Emmanuel Benitez
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BigSolution
{
    [Serializable]
    public class AggregateArgumentException : ArgumentException
    {
        public AggregateArgumentException() { }

        public AggregateArgumentException(IEnumerable<ArgumentException> exceptions)
            : this(Resources.AggregateArgumentException.DefaultErrorMessage, exceptions) { }

        public AggregateArgumentException(string message, IEnumerable<ArgumentException> exceptions)
            : base(message)
        {
            Exceptions = exceptions ?? Enumerable.Empty<ArgumentException>();
        }

        public AggregateArgumentException(string message, string paramName, IEnumerable<ArgumentException> exceptions)
            : base(message, paramName)
        {
            Exceptions = exceptions ?? Enumerable.Empty<ArgumentException>();
        }

        protected AggregateArgumentException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        #region Base Class Member Overrides

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Exceptions", Exceptions, typeof(IEnumerable<Exception>));
        }

        #endregion

        public IEnumerable<ArgumentException> Exceptions { get; }
    }
}
