using System;
using SQLite.Net.Attributes;

namespace MobileData
{
	[Table("checks")]
	public class Check : BaseViewModel
	{
		int id;
		[PrimaryKey, AutoIncrement]
		public int Id {
			get {
				return id;
			}
			set {
				SetValue(ref id, value);
			}
		}

		[Unique]
		public int CheckNumber { get; set; }

		DateTime date;
		public DateTime Date {
			get {
				return date;
			}
			set {
				SetValue(ref date, value);
			}
		}

		string payee;
		[MaxLength(200), Column("payee")]
		public string Payee {
			get {
				return payee;
			}
			set {
				SetValue(ref payee, value);
			}
		}

		double amount;
		public double Amount {
			get {
				return amount;
			}
			set {
				SetValue(ref amount, value);
			}
		}

		bool cleared;
		public bool Cleared {
			get {
				return cleared;
			}
			set {
				SetValue(ref cleared, value);
			}
		}
	}
}

