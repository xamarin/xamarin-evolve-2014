using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.Collections.Specialized;

namespace FileTransfer
{
	/// <summary>
	/// Simple TableViewSource class which utilizes delegates to avoid
	/// most custom implementations
	/// </summary>
	public class DelegateTableViewSource<T> : UITableViewSource
	{
		private IList<T> items;
		protected NSString CellId { get; set; }
		protected UITableView TableView { get; set; }

		/// <summary>
		/// Method to fill in the TableView cell.
		/// </summary>
		/// <value>The get cell func.</value>
		public Func<T, UITableViewCell, UITableViewCell> GetCellFunc { get; set; }

		/// <summary>
		/// Method to decide whether a row is editable
		/// </summary>
		/// <value><c>true</c> if this instance can edit row func; otherwise, <c>false</c>.</value>
		public Func<T, NSIndexPath, bool> CanEditRowFunc { get; set; }

		/// <summary>
		/// Method to call when a row is selected.
		/// </summary>
		/// <value>The row selected.</value>
		public Action<T> RowSelectedFunc { get; set; }

		/// <summary>
		/// Items which will populate the table view.
		/// </summary>
		/// <value>The items.</value>
		public IList<T> Items {
			get {
				return items;
			}
			set {
				if (items != value) {

					if (items != null)
					{
						INotifyCollectionChanged ncc = items as INotifyCollectionChanged;
						if (ncc != null)
							ncc.CollectionChanged -= OnCollectionChanged;
					}

					items = value;

					if (value != null) {
						INotifyCollectionChanged ncc = value as INotifyCollectionChanged;
						if (ncc != null)
							ncc.CollectionChanged += OnCollectionChanged;
					}

					TableView.ReloadData();
				}
			}
		}

		/// <summary>
		/// Collection Changed notification
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			TableView.ReloadData();
		}

		/// <Docs>Table view displaying the sections.</Docs>
		/// <returns>Number of sections required to display the data. The default is 1 (a table must have at least one section).</returns>
		/// <para>Declared in [UITableViewDataSource]</para>
		/// <summary>
		/// Numbers the of sections.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		public override int NumberOfSections(UITableView tableView)
		{
			return 1;
		}

		/// <Docs>Table view displaying the rows.</Docs>
		/// <summary>
		/// Rowses the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override int RowsInSection(UITableView tableview, int section)
		{
			return items.Count;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="cellId">Cell identifier (must be registered).</param>
		public DelegateTableViewSource(UITableView tableView, string cellId)
		{
			this.CellId = new NSString(cellId);
			this.TableView = tableView;
		}

		/// <Docs>Table view requesting the cell.</Docs>
		/// <summary>
		/// Gets the cell - uses the GetCellFunc delegate
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CellId, indexPath);
			var item = items[CollectionIndexFromIndexPath(indexPath)];
			return GetCellFunc(item, cell);
		}

		/// <Docs>Table view requesting insertion or deletion.</Docs>
		/// <paramref name="indexPath"></paramref>
		/// <param name="indexPath">Location of the row.</param>
		/// <remarks>When the user taps the insertion (green plus) or Delete button in a cell, the table view calls this method to
		/// commit the change (if the user taps the deletion (red minus) button, that simply reveals the Delete button).</remarks>
		/// <paramref name="editingStyle"></paramref>
		/// <summary>
		/// Commits the editing style.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="editingStyle">Editing style.</param>
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
		{
			if (editingStyle == UITableViewCellEditingStyle.Delete) 
			{
				Items.RemoveAt(indexPath.Row);
			}
			else if (editingStyle == UITableViewCellEditingStyle.Insert)
			{
				OnInsertItem(indexPath);
			}
		}

		/// <summary>
		/// Override which can insert an item.
		/// </summary>
		/// <param name="indexPath">Index path.</param>
		protected virtual void OnInsertItem(NSIndexPath indexPath)
		{
		}

		/// <summary>
		/// Called when the row is selected. Forwards to our action.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			if (RowSelectedFunc != null)
				RowSelectedFunc(items[CollectionIndexFromIndexPath(indexPath)]);
		}

		/// <summary>
		/// Retrieves the NSIndexPath for a given collection index in Items[]
		/// </summary>
		/// <returns>The path from collection index.</returns>
		/// <param name="index">Index.</param>
		protected virtual NSIndexPath IndexPathFromCollectionIndex(int index)
		{
			return NSIndexPath.FromRowSection(index, 0);
		}

		/// <summary>
		/// Retrieves the collection index for a given NSIndexPath
		/// </summary>
		/// <returns>The index from index path.</returns>
		/// <param name="index">Index.</param>
		protected virtual int CollectionIndexFromIndexPath(NSIndexPath index)
		{
			return index.Row;
		}

		/// <Docs>Table view containing the row.</Docs>
		/// <summary>
		/// Determines whether this instance can edit row the specified tableView indexPath.
		/// </summary>
		/// <returns><c>true</c> if this instance can edit row the specified tableView indexPath; otherwise, <c>false</c>.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
		{
			return CanEditRowFunc != null 
				&& CanEditRowFunc(items[CollectionIndexFromIndexPath(indexPath)], indexPath);
		}
	}

}
