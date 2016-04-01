﻿using System.Windows.Input;

namespace Plainion.Windows.Controls.Tree
{
    public class TreeEditorCommands
    {
        public static readonly RoutedCommand ExpandAll = new RoutedCommand();
        public static readonly RoutedCommand CollapseAll = new RoutedCommand();

        public static readonly RoutedCommand Edit = new RoutedCommand();

        public static void RegisterCommandBindings(TreeEditor editor)
        {
            editor.CommandBindings.Add(new CommandBinding(ExpandAll, (sender, e) => OnExpandAll(editor, (INode)e.Parameter)));
            editor.CommandBindings.Add(new CommandBinding(CollapseAll, (sender, e) => OnCollapseAll(editor, (INode)e.Parameter)));

            editor.CommandBindings.Add(new CommandBinding(Edit, (sender, e) => OnEdit(editor, (NodeItem)e.Parameter)));
        }

        private static void OnExpandAll(TreeEditor editor, INode node)
        {
            if (node == null)
            {
                node = editor.Root;
            }

            var nodeState = editor.myTree.StateContainer.GetOrCreate(node);

            nodeState.ExpandAll();
        }

        private static void OnCollapseAll(TreeEditor editor, INode node)
        {
            if (node == null)
            {
                node = editor.Root;
            }

            var nodeState = editor.myTree.StateContainer.GetOrCreate(node);

            nodeState.CollapseAll();
        }

        private static void OnEdit(TreeEditor editor, NodeItem node)
        {
            node.IsInEditMode = true;
        }
    }
}
