﻿//---------------------------------------------------------------------
// <copyright file="UnresolvedVocabularyTerm.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

using Microsoft.OData.Edm.Vocabularies;

namespace Microsoft.OData.Edm.Csdl.CsdlSemantics
{
    internal class UnresolvedVocabularyTerm : EdmElement, IEdmTerm, IUnresolvedElement, IEdmFullNamedElement
    {
        private readonly UnresolvedTermTypeReference type = new UnresolvedTermTypeReference();
        private readonly string namespaceName;
        private readonly string name;
        private readonly string fullName;
        private readonly string appliesTo = null;
        private readonly string defaultValue = null;

        public UnresolvedVocabularyTerm(string qualifiedName)
        {
            qualifiedName = qualifiedName ?? string.Empty;
            EdmUtil.TryGetNamespaceNameFromQualifiedName(qualifiedName, out this.namespaceName, out this.name, out this.fullName);
        }

        public string Namespace
        {
            get { return this.namespaceName; }
        }

        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the full name of this schema element.
        /// </summary>
        public string FullName
        {
            get { return this.fullName; }
        }

        public EdmSchemaElementKind SchemaElementKind
        {
            get { return EdmSchemaElementKind.Term; }
        }

        public IEdmTypeReference Type
        {
            get { return this.type; }
        }

        public IEdmTerm BaseTerm
        {
            get { return null; }
        }

        public string AppliesTo
        {
            get { return this.appliesTo; }
        }

        public string DefaultValue
        {
            get { return this.defaultValue; }
        }

        private class UnresolvedTermTypeReference : IEdmTypeReference
        {
            private readonly UnresolvedTermType definition = new UnresolvedTermType();

            public bool IsNullable
            {
                get { return false; }
            }

            public IEdmType Definition
            {
                get { return this.definition; }
            }

            private class UnresolvedTermType : IEdmType
            {
                public EdmTypeKind TypeKind
                {
                    get { return EdmTypeKind.None; }
                }
            }
        }
    }
}
