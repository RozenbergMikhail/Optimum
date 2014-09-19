//
// Copyright (c) 2014
//
// Author: Rozenberg Mikhail
//

using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Development;

namespace Platform.UITree
{
	/// <summary>
	/// Represents UI tree
	/// </summary>
	public class UITree : IUITree
	{
		private readonly List<UITreeNode> roots;

		/// <summary>
		/// Creates new instance of <see cref="UITree"/>
		/// </summary>
		public UITree()
		{
			this.roots = new List<UITreeNode>();
		}

		/// <summary>
		/// Creates new instance of <see cref="UITree"/> by copying from the specified source
		/// </summary>
		/// <param name="sourceTree">source tree</param>
		public UITree(IUITree sourceTree)
		{
			if (sourceTree == null)
				throw new MemoryPointerIsNullException("sourceTree");

			this.roots = new List<UITreeNode>();
			Map(sourceTree, this, SimpleMap);
		}

		/// <summary>
		/// Creates new instance of <see cref="UITree"/> by copying from the specified source and using entity mappings
		/// </summary>
		/// <typeparam name="TSourceEntity">entity type in current tree</typeparam>
		/// <typeparam name="TDestinationEntity">entity type in mapped tree</typeparam>
		/// <param name="sourceTree">source tree</param>
		/// <param name="entityMappingFunction">entity mapping function</param>
		/// <returns>new tree instance with entity nodes of new type</returns>
		public static UITree Create<TSourceEntity, TDestinationEntity>(IUITree sourceTree, Func<TSourceEntity, TDestinationEntity> entityMappingFunction)
		{
			if (sourceTree == null)
				throw new MemoryPointerIsNullException("sourceTree");

			if (entityMappingFunction == null)
				throw new MemoryPointerIsNullException("entityMappingFunction");

			var tree = new UITree();
			MapEntityNodes(sourceTree, tree, entityMappingFunction);
			return tree;
		}

		/// <summary>
		/// Gets tree roots
		/// </summary>
		public List<UITreeNode> Roots
		{
			get
			{
				return this.roots;
			}
		}

		/// <summary>
		/// Maps current tree instance using the specified mapping function and returns newly created mapped tree
		/// </summary>
		/// <param name="mappingFunction">mapping function</param>
		/// <returns>new mapped tree instance</returns>
		public UITree Map(Func<List<IUITreeNode>, List<UITreeNode>> mappingFunction)
		{
			if (mappingFunction == null)
				throw new MemoryPointerIsNullException("mappingFunction");

			var tree = new UITree();
			Map(this, tree, mappingFunction);
			return tree;
		}

		/// <summary>
		/// Gets tree with only entity roots, ignoring all other tree nodes
		/// </summary>
		/// <returns>new tree instance with just entity roots</returns>
		public UITree GetEntityRootsTree()
		{
			var tree = new UITree();
			Map(this, tree, MapWithGetOnlyEntityRoots);
			return tree;
		}

		/// <summary>
		/// Gets sidebar-like tree with separators
		/// </summary>
		/// <returns>sidebar-like tree with separators</returns>
		public UITree GetSidebarLikeTreeWithSeparators()
		{
			return this.RemoveEmptyGroups().FlattenGroups().RemoveRedundantSeparators();
		}

		/// <summary>
		/// Gets menu-like tree with separators
		/// </summary>
		/// <returns>menu-like tree with separators</returns>
		public UITree GetMenuLikeTreeWithSeparators()
		{
			throw new SourceCodeNotImplementedException();
		}

		/// <summary>
		/// Removes groups and named groups not containing elements from the tree
		/// </summary>
		/// <returns>new tree instance with empty group nodes removed</returns>
		public UITree RemoveEmptyGroups()
		{
			var tree = new UITree();
			Map(this, tree, MapWithRemoveEmptyGroups);
			return tree;
		}

		/// <summary>
		/// Flattens group nodes in the tree and instead inserts preceding and trailing separators
		/// </summary>
		/// <returns>new tree instance with flattened group nodes</returns>
		public UITree FlattenGroups()
		{
			var tree = new UITree();
			Map(this, tree, MapWithFlatteningGroups);
			return tree;
		}

		/// <summary>
		/// Removes preceding, trailing and duplicate separators from each level of the tree
		/// </summary>
		/// <returns>new tree instance with redundant separator nodes removed</returns>
		public UITree RemoveRedundantSeparators()
		{
			var tree = new UITree();
			Map(this, tree, MapWithRemoveRedundantSeparators);
			return tree;
		}

		#region ITree members

		/// <summary>
		/// Gets tree roots
		/// </summary>
		public List<IUITreeNode> GetRoots()
		{
			return this.roots.Cast<IUITreeNode>().ToList();
		}

		/// <summary>
		/// Performs depth-traverse of object tree using specified action
		/// </summary>
		/// <param name="traverseAction">traverse action</param>
		public void TraverseDepth(Action<IUITreeNode, int> traverseAction)
		{
			foreach (var element in this.roots.Cast<IUITreeNode>())
			{
				element.TraverseDepth(traverseAction, 0);
			}
		}

		#endregion

		#region Tree mapping functions

		private static void Map(IUITree sourceTree, UITree destinationTree, Func<List<IUITreeNode>, List<UITreeNode>> mappingFunction)
		{
			destinationTree.Roots.AddRange(mappingFunction(sourceTree.GetRoots()));
		}

		private static void MapEntityNodes<TSourceEntity, TDestinationEntity>(
			IUITree sourceTree, UITree destinationTree, Func<TSourceEntity, TDestinationEntity> entityMappingFunction)
		{
			destinationTree.Roots.AddRange(MapWithConvertEntityNodes(sourceTree.GetRoots(), entityMappingFunction));
		}

		private static List<UITreeNode> MapWithConvertEntityNodes<TSourceEntity, TDestinationEntity>(List<IUITreeNode> sourceNodes, Func<TSourceEntity, TDestinationEntity> entityMappingFunction)
		{
			var result = new List<UITreeNode>();

			foreach (var sourceNode in sourceNodes)
			{
				var destinationNode = GetDestinationNode<TSourceEntity, TDestinationEntity>(sourceNode, entityMappingFunction);
				if (destinationNode != null)
				{
					destinationNode.ChildNodes.AddRange(MapWithConvertEntityNodes(sourceNode.GetChildNodes(), entityMappingFunction));
					result.Add(destinationNode);
				}
			}
			return result;
		}

		private static UITreeNode GetDestinationNode<TSourceEntity, TDestinationEntity>(IUITreeNode sourceNode, Func<TSourceEntity, TDestinationEntity> entityMappingFunction)
		{
			UITreeNode result = null;
			if (sourceNode.GetNodeType() == UITreeNodeType.Entity)
			{
				var sourceEntity = ((IEntityTreeNode<TSourceEntity>)sourceNode).GetEntity();
				var destinationEntity = entityMappingFunction(sourceEntity);
				if (destinationEntity != null)
				{
					result = new EntityTreeNode<TDestinationEntity>(destinationEntity);
				}
			}
			else
			{
				result = sourceNode.GetTreeNode();
			}
			return result;
		}

		private static List<UITreeNode> SimpleMap(List<IUITreeNode> sourceNodes)
		{
			var result = new List<UITreeNode>();
			foreach (var sourceNode in sourceNodes)
			{
				var destinationNode = sourceNode.GetTreeNode();
				destinationNode.ChildNodes.AddRange(SimpleMap(sourceNode.GetChildNodes()));
				result.Add(destinationNode);
			}
			return result;
		}

		private static List<UITreeNode> MapWithGetOnlyEntityRoots(List<IUITreeNode> sourceNodes)
		{
			var result = new List<UITreeNode>();
			foreach (var sourceNode in sourceNodes)
			{
				if (sourceNode.GetNodeType() == UITreeNodeType.Entity)
				{
					var destinationNode = sourceNode.GetTreeNode();
					result.Add(destinationNode);
				}
			}
			return result;
		}

		private static List<UITreeNode> MapWithRemoveEmptyGroups(List<IUITreeNode> sourceNodes)
		{
			var result = new List<UITreeNode>();

			foreach (var sourceNode in sourceNodes)
			{
				var destinationNode = sourceNode.GetTreeNode();
				destinationNode.ChildNodes.AddRange(MapWithRemoveEmptyGroups(sourceNode.GetChildNodes()));

				var nodeType = destinationNode.GetNodeType();
				if (nodeType != UITreeNodeType.Group && nodeType != UITreeNodeType.NamedGroup || destinationNode.ChildNodes.Count != 0)
				{
					result.Add(destinationNode);
				}
			}
			return result;
		}

		private static List<UITreeNode> MapWithFlatteningGroups(List<IUITreeNode> sourceNodes)
		{
			var result = new List<UITreeNode>();

			foreach (var sourceNode in sourceNodes)
			{
				if (sourceNode.GetNodeType() == UITreeNodeType.Group)
				{
					result.Add(new SeparatorTreeNode());
					result.AddRange(MapWithFlatteningGroups(sourceNode.GetChildNodes()));
					result.Add(new SeparatorTreeNode());
				}
				else
				{
					var destinationNode = sourceNode.GetTreeNode();
					destinationNode.ChildNodes.AddRange(MapWithFlatteningGroups(sourceNode.GetChildNodes()));
					result.Add(destinationNode);
				}
			}
			return result;
		}

		private static List<UITreeNode> MapWithRemoveRedundantSeparators(List<IUITreeNode> sourceNodes)
		{
			var result = new List<UITreeNode>();

			foreach (var sourceNode in sourceNodes)
			{
				var nodeType = sourceNode.GetNodeType();

				// ignore duplicated separators
				if (nodeType != UITreeNodeType.Separator
					|| result.Count == 0
					|| result[result.Count - 1].GetNodeType() != UITreeNodeType.Separator)
				{
					var destinationNode = sourceNode.GetTreeNode();
					destinationNode.ChildNodes.AddRange(MapWithFlatteningGroups(sourceNode.GetChildNodes()));
					result.Add(destinationNode);
				}
			}

			// remove first separator
			if (result.Count > 0 && result[0].GetNodeType() == UITreeNodeType.Separator)
				result.RemoveAt(0);

			// remove last separator
			if (result.Count > 0 && result[result.Count - 1].GetNodeType() == UITreeNodeType.Separator)
				result.RemoveAt(result.Count - 1);

			return result;
		}

		#endregion
	}
}
