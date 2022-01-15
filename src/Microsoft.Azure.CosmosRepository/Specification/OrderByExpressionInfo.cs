﻿// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Microsoft.Azure.CosmosRepository.Specification
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderExpressionInfo<T>
    {
        private readonly Lazy<Func<T, object>> keySelectorFunc;

        /// <summary>
        /// Creates instance of <see cref="OrderExpressionInfo{T}" />.
        /// </summary>
        /// <param name="keySelector">A function to extract a key from an element.</param>
        /// <param name="orderType">Whether to (subsequently) sort ascending or descending.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="keySelector"/> is null.</exception>
        public OrderExpressionInfo(Expression<Func<T, object>> keySelector, OrderTypeEnum orderType)
        {
            _ = keySelector ?? throw new ArgumentNullException(nameof(keySelector));

            KeySelector = keySelector;
            OrderType = orderType;

            keySelectorFunc = new Lazy<Func<T, object>>(KeySelector.Compile);
        }

        /// <summary>
        /// A function to extract a key from an element.
        /// </summary>
        public Expression<Func<T, object>> KeySelector { get; }

        /// <summary>
        /// Whether to (subsequently) sort ascending or descending.
        /// </summary>
        public OrderTypeEnum OrderType { get; }

        /// <summary>
        /// Compiled <see cref="KeySelector" />.
        /// </summary>
        public Func<T, object> KeySelectorFunc => keySelectorFunc.Value;

    }
}