﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Plainion.Windows.Interactivity.DragDrop;

namespace Plainion.Windows.Controls.Tree.Forest
{
    public class NodeViewModel : NodeViewModelBase, IDropable, IDragable
    {
        private bool myIsSelected;

        internal NodeViewModel(INode node, INodeViewModelFactory nodeViewModelFactory)
            : base(nodeViewModelFactory)
        {
            Node = node;

            node.PropertyChanged += OnNodePropertyChanged;

            MouseDownCommand = new DelegateCommand<MouseButtonEventArgs>(OnMouseDown);
            EditNodeCommand = new DelegateCommand(OnEditNode);
            DeleteCommand = new DelegateCommand(DeleteChild);
        }

        public ICommand EditNodeCommand { get; private set; }

        private void OnActivated(INode node)
        {
            if (Node == node)
            {
                Node.Parent.IsExpanded = true;
                IsSelected = true;
            }
        }

        private void OnSelected(INode node)
        {
            if (Node == node)
            {
                IsSelected = true;
            }
        }

        private void DeleteChild()
        {
            //ProjectService.Project.DeleteNode( Node );
        }

        public ICommand DeleteCommand
        {
            get;
            private set;
        }

        private void OnNodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Caption" || e.PropertyName == "IsExpanded")
            {
                OnPropertyChanged(e.PropertyName);
            }
        }

        public string Caption
        {
            get { return string.IsNullOrEmpty(Node.Text) ? "<empty>" : Node.Text; }
            set { /*ProjectService.Project.ChangeCaption( Node, value );*/ }
        }

        public bool IsSelected
        {
            get { return myIsSelected; }
            set
            {
                if (myIsSelected == value)
                {
                    return;
                }

                myIsSelected = value;
                OnPropertyChanged("IsSelected");

                if (myIsSelected)
                {
                    // EventAggregator.GetEvent<NodeSelectedEvent>().Publish( Node );
                }
            }
        }

        public bool IsExpanded
        {
            get { return Node.IsExpanded; }
            set { Node.IsExpanded = value; }
        }

        string IDropable.DataFormat
        {
            get { return typeof(NodeViewModel).FullName; }
        }

        bool IDropable.IsDropAllowed(object data, DropLocation location)
        {
            return true;
        }

        void IDropable.Drop(object data, DropLocation location)
        {
            var droppedElement = data as NodeViewModel;

            if (droppedElement == null)
            {
                return;
            }

            if (object.ReferenceEquals(droppedElement, this))
            {
                //if dragged and dropped yourself, don't need to do anything
                return;
            }

            //if( location == DropLocation.Before || location == DropLocation.After )
            //{
            //    var operation = location == DropLocation.Before ? MoveOperation.MoveBefore : MoveOperation.MoveAfter;
            //    ProjectService.Project.MoveNode( droppedElement.Node, Node, operation );
            //}
            //else
            //{
            //    ProjectService.Project.AddChildTo( droppedElement.Node, Node );
            //}

            IsExpanded = true;
        }

        Type IDragable.DataType
        {
            get
            {
                return typeof(NodeViewModel);
            }
        }

        public bool IsFilteredOut
        {
            get;
            private set;
        }

        internal void ApplyFilter(string filter)
        {
            IsFilteredOut = Caption.IndexOf(filter, StringComparison.OrdinalIgnoreCase) < 0;

            foreach (var child in Children)
            {
                child.ApplyFilter(filter);

                if (!child.IsFilteredOut)
                {
                    IsFilteredOut = false;
                }
            }

            VisibleChildren.Refresh();
        }

        protected override void CollapseAll()
        {
            IsExpanded = false;

            base.CollapseAll();
        }

        protected override void ExpandAll()
        {
            IsExpanded = true;

            base.ExpandAll();
        }

        public ICommand MouseDownCommand { get; private set; }

        private void OnMouseDown(MouseButtonEventArgs args)
        {
            if (args.ClickCount == 2)
            {
                //EventAggregator.GetEvent<NodeActivatedEvent>().Publish( Node );
            }
        }

        private void OnEditNode()
        {
            //EventAggregator.GetEvent<NodeActivatedEvent>().Publish( Node );
        }
    }
}
