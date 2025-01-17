// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.Azure.CosmosRepository.ChangeFeed
{
    /// <summary>
    /// The options for monitoring the change feed.
    /// </summary>
    public class ChangeFeedOptions
    {
        internal Type ItemType { get; }

        internal ChangeFeedOptions(Type itemType)
        {
            ItemType = itemType;
        }

        /// <summary>
        /// The instance name of the processor.
        /// </summary>
        public string InstanceName { get; set; } = "default";

        internal bool IsTheSameAs(ChangeFeedOptions options) =>
            options.InstanceName == InstanceName;
    }
}