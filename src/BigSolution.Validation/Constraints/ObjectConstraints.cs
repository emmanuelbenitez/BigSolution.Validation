﻿#region Copyright & License

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
    public static class ObjectConstraints
    {
        public static IArgumentValidation<T> IsNotNull<T>(this IArgumentValidation<T> argumentValidation)
        {
            return argumentValidation.Validate(value => !Equals(null, value), parameterName => new ArgumentNullException(parameterName));
        }
    }
}
