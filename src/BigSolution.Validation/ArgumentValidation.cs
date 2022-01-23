#region Copyright & License

// Copyright © 2020 - 2022 Emmanuel Benitez
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

namespace BigSolution
{
    internal sealed class ArgumentValidation<T> : IArgumentValidation<T>
    {
        public ArgumentValidation(T value, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(Resources.StringConstraints.IsNotNullOrEmptyErrorMessage, nameof(name));

            Value = value;
            Name = name;
        }

        #region IArgumentValidation<T> Members

        public void AddException(ArgumentException exception)
        {
            _exceptions.Add(exception);
        }

        public IReadOnlyCollection<ArgumentException> Exceptions => _exceptions.AsReadOnly();

        public string Name { get; }

        public T Value { get; }

        #endregion

        private readonly List<ArgumentException> _exceptions = new();
    }
}
