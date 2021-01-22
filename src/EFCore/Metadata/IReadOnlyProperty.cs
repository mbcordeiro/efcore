// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable enable

namespace Microsoft.EntityFrameworkCore.Metadata
{
    /// <summary>
    ///     Represents a scalar property of an entity.
    /// </summary>
    public interface IReadOnlyProperty : IReadOnlyPropertyBase
    {
        /// <summary>
        ///     Gets the entity type that this property belongs to.
        /// </summary>
        IReadOnlyEntityType DeclaringEntityType { get; }

        /// <summary>
        ///     Gets a value indicating whether this property can contain <see langword="null" />.
        /// </summary>
        bool IsNullable { get; }

        /// <summary>
        ///     Gets a value indicating when a value for this property will be generated by the database. Even when the
        ///     property is set to be generated by the database, EF may still attempt to save a specific value (rather than
        ///     having one generated by the database) when the entity is added and a value is assigned, or the property is
        ///     marked as modified for an existing entity. See <see cref="PropertyExtensions.GetBeforeSaveBehavior" />
        ///     and <see cref="PropertyExtensions.GetAfterSaveBehavior" /> for more information.
        /// </summary>
        ValueGenerated ValueGenerated { get; }

        /// <summary>
        ///     Gets a value indicating whether this property is used as a concurrency token. When a property is configured
        ///     as a concurrency token the value in the database will be checked when an instance of this entity type
        ///     is updated or deleted during <see cref="DbContext.SaveChanges()" /> to ensure it has not changed since
        ///     the instance was retrieved from the database. If it has changed, an exception will be thrown and the
        ///     changes will not be applied to the database.
        /// </summary>
        bool IsConcurrencyToken { get; }

        /// <summary>
        ///     <para>
        ///         Gets the <see cref="PropertyAccessMode" /> being used for this property.
        ///         <see langword="null" /> indicates that the default property access mode is being used.
        ///     </para>
        /// </summary>
        /// <returns> The access mode being used, or <see langword="null" /> if the default access mode is being used. </returns>
        PropertyAccessMode IReadOnlyPropertyBase.GetPropertyAccessMode()
            => (PropertyAccessMode)(this[CoreAnnotationNames.PropertyAccessMode]
                ?? DeclaringType.GetPropertyAccessMode());
    }
}
