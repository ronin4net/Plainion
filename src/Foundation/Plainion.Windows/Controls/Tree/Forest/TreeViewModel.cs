﻿using Plainion.Windows.Interactivity.DragDrop;

namespace Plainion.Windows.Controls.Tree.Forest
{
    public class TreeViewModel : NodeViewModelBase, IDropable
    {
        private string myFilter;
        private bool myIsSelected;

        public TreeViewModel( INodeViewModelFactory nodeViewModelFactory)
            : base( nodeViewModelFactory )
        {
        }

        // needed for tab selection
        public bool IsSelected
        {
            get { return myIsSelected; }
            set { SetProperty( ref myIsSelected, value ); }
        }

        public string Filter
        {
            get
            {
                return myFilter;
            }
            set
            {
                if( myFilter == value )
                {
                    return;
                }

                myFilter = value;
                OnPropertyChanged( "Filter" );

                foreach( var child in Children )
                {
                    child.ApplyFilter( myFilter );
                }

                VisibleChildren.Refresh();
            }
        }

        void IDropable.Drop( object data, DropLocation location )
        {
            var droppedElement = data as NodeViewModel;

            if( droppedElement == null )
            {
                return;
            }

            //ProjectService.Project.AddChildTo( droppedElement.Node, Node );
        }

        string IDropable.DataFormat
        {
            get
            {
                return typeof( NodeViewModel ).FullName;
            }
        }

        bool IDropable.IsDropAllowed( object data, DropLocation location )
        {
            return true;
        }
    }
}
