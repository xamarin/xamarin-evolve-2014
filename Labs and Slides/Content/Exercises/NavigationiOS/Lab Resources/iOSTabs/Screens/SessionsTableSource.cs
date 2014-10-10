using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Evolve.Core;

namespace com.xamarin.university.mobilenav.ios.tabs
{
	public class SessionsTableSource : UITableViewSource
	{		
		static readonly string sessionCellId = "SessionCell";
		List<Session> data;
		IGrouping<int, Session>[] grouping; // sub-group of speakers in each index
		UITableViewController controller;

		public SessionsTableSource (List<Session> sessions, UITableViewController tvc)
		{
			data = sessions;
			grouping = GetSessionsGroupedByDate();
			controller = tvc;
		}
		
		public override int RowsInSection (UITableView tableview, int section)
		{
			return grouping[section].Count ();
		}
		
		public override int NumberOfSections (UITableView tableView)
		{
			return grouping.Count ();
		}
		
		public override string TitleForHeader (UITableView tableView, int section)
		{
			return grouping [section].ElementAt (0).Begins.Date.ToString ("dd MMM yyyy");
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);
			
			controller.NavigationController.PushViewController (new SessionViewController (session), true);
			
			tableView.DeselectRow (indexPath, true);
		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var sessionGroup = grouping [indexPath.Section];
			var session = sessionGroup.ElementAt (indexPath.Row);
			
			var cell = (SessionCell)tableView.DequeueReusableCell (sessionCellId);
			
			if (cell == null)
				cell = new SessionCell (sessionCellId);	
			
			cell.Session = session;
			
			return cell;
		}
		
		
		// helper method
		IGrouping<int, Session>[] GetSessionsGroupedByDate ()
		{
			var sessionsGrouped = (from s in data
			                       group s by s.Begins.Day into g
			                       select g).ToArray ();
			
			return sessionsGrouped;
		}
	} 
}

