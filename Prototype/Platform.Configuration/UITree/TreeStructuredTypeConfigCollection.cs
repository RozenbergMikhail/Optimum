//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Linq;
using System.Xml;
using System.Configuration;
using System.Collections.Generic;

using Platform.UITree;

namespace Platform.Configuration.UITree
{
	/// <summary>
	/// Contains tree-structured type configuration collection 
	/// </summary>
	[ConfigurationCollection(typeof(TreeStructuredTypeBaseConfigElement))]
	public class TreeStructuredTypeConfigCollection : ConfigurationElementCollection, IUITree
	{
		/// <summary>
		/// Defines name of the "Entity" item of the configuration section
		/// </summary>
		public const string EntitySectionItemName = "Entity";

		/// <summary>
		/// Defines name of the "Group" item of the configuration section
		/// </summary>
		public const string GroupSectionItemName = "Group";

		/// <summary>
		/// Defines name of the "NamedGroup" item of the configuration section
		/// </summary>
		public const string NamedGroupSectionItemName = "NamedGroup";

		#region ITree members

		/// <summary>
		/// Gets tree roots
		/// </summary>
		public List<IUITreeNode> GetRoots()
		{
			return this.Cast<IUITreeNode>().ToList();
		}

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		public void TraverseDepth(Action<IUITreeNode, int> traverseAction)
		{
			foreach (var element in this.Cast<IUITreeNode>())
			{
				element.TraverseDepth(traverseAction, 0);
			}
		}

		#endregion

		/// <summary>
		/// Creates new element
		/// </summary>
		/// <returns>new element</returns>
		protected override ConfigurationElement CreateNewElement()
		{
			return null;
		}

		/// <summary>
		/// Creates new element
		/// </summary>
		/// <param name="elementName">element name</param>
		/// <returns>new element</returns>
		protected override ConfigurationElement CreateNewElement(string elementName)
		{
			var element = GetTreeStructuredTypeConfigElementByName(elementName);
			if (element != null)
			{
				return element;
			}
			throw new ConfigurationErrorsException("Unsupported element: " + elementName);
		}

		/// <summary>
		/// Provides custom deserializer for collection element
		/// </summary>
		/// <param name="elementName">element name</param>
		/// <param name="reader">reader instance</param>
		/// <returns>true, if the element has been successfully deserialized</returns>
		protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
		{
			var element = GetTreeStructuredTypeConfigElementByName(elementName);
			if (element != null)
			{
				element.Members = this.GetMembersConfigCollection();
				element.Deserialize(reader);
				BaseAdd(element);
				return true;
			}
			return base.OnDeserializeUnrecognizedElement(elementName, reader);
		}

		/// <summary>
		/// Gets element key
		/// </summary>
		/// <param name="element">configuration element</param>
		/// <returns>element key object</returns>
		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((TreeStructuredTypeBaseConfigElement)element).GetElementKey();
		}

		/// <summary>
		/// Gets entity tag name
		/// </summary>
		/// <returns>entity tag name</returns>
		protected virtual string GetEntityTagName()
		{
			return EntitySectionItemName;
		}

		/// <summary>
		/// Gets entity group tag name
		/// </summary>
		/// <returns>entity group tag name</returns>
		protected virtual string GetEntityGroupTagName()
		{
			return GroupSectionItemName;
		}

		/// <summary>
		/// Gets entity named group tag name
		/// </summary>
		/// <returns>entity named group tag name</returns>
		protected virtual string GetEntityNamedGroupTagName()
		{
			return NamedGroupSectionItemName;
		}

		/// <summary>
		/// Gets members config collection
		/// </summary>
		/// <returns>members config collection</returns>
		protected virtual TreeStructuredTypeConfigCollection GetMembersConfigCollection()
		{
			return new TreeStructuredTypeConfigCollection();
		}

		private TreeStructuredTypeBaseConfigElement GetTreeStructuredTypeConfigElementByName(string elementName)
		{
			TreeStructuredTypeBaseConfigElement result = null;

			if (elementName == this.GetEntityTagName())
			{
				result = new TreeStructuredTypeEntityConfigElement();
			}
			else if (elementName == this.GetEntityGroupTagName())
			{
				result = new TreeStructuredTypeGroupConfigElement();
			}
			else if (elementName == this.GetEntityNamedGroupTagName())
			{
				result = new TreeStructuredTypeNamedGroupConfigElement();
			}

			return result;
		}
	}
}
