// This file has been autogenerated from a class added in the UI designer.
using System;
using AppKit;
using System.Data.SqlClient;
using DBApp.Models;
using System.Collections.Generic;
using Foundation;

namespace DBApp
{
	public partial class VouchersTableViewController : NSViewController
	{
		//Models
		public class Vouchers
		{
			public string startDate { get; set; }
			public string endDate { get; set; }
			public string duration { get; set; }
			public string hId { get; set; }
			public string tofId { get; set; }
			public string asId { get; set; }
			public string eId { get; set; }
			public string reservationMark { get; set; }
			public string paymentMark { get; set; }

			public Vouchers()
			{
				startDate = "";
				endDate = "";
				duration = "";
				hId = "";
				tofId = "";
				asId = "";
				eId = "";
				reservationMark = "";
				paymentMark = "";

			}

		}

		public class ProductTableDataSource : NSTableViewDataSource
		{
			public List<Vouchers> Vouchers = new List<Vouchers>();

			public ProductTableDataSource()
			{
			}

			public override nint GetRowCount(NSTableView tableView)
			{
				return Vouchers.Count;
			}
		}

		public class ProductTableDelegate : NSTableViewDelegate
		{
			private const string CellIdentifier = "ProdCell";
			private ProductTableDataSource DataSource;

			public ProductTableDelegate(ProductTableDataSource datasource)
			{
				this.DataSource = datasource;
			}

			public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
			{
				NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);

				if (view == null)
				{
					view = new NSTextField();
					view.Identifier = CellIdentifier;
					view.BackgroundColor = NSColor.Clear;
					view.Bordered = false;
					view.Selectable = false;
					view.Editable = false;
				}

				switch (tableColumn.Title)
				{
					case "V_START_DATE":
						view.StringValue = DataSource.Vouchers[(int)row].startDate.ToString();
						break;

					case "V_END_DATE":
						view.StringValue = DataSource.Vouchers[(int)row].endDate.ToString();
						break;

					case "V_DURATION":
						view.StringValue = DataSource.Vouchers[(int)row].duration;
						break;

					case "H_ID":
						view.StringValue = DataSource.Vouchers[(int)row].hId;
						break;

					case "TOF_ID":
						view.StringValue = DataSource.Vouchers[(int)row].tofId;
						break;

					case "AS_ID":
						view.StringValue = DataSource.Vouchers[(int)row].asId;
						break;

					case "E_ID":
						view.StringValue = DataSource.Vouchers[(int)row].eId;
						break;

					case "V_RESERVATION_MARK":
						view.StringValue = DataSource.Vouchers[(int)row].reservationMark;
						break;

					case "V_PAYMENT_MARK":
						view.StringValue = DataSource.Vouchers[(int)row].paymentMark;
						break;
				}

				return view;
			}
		}

		public class ProductTableSinglesDelegate : NSTableViewDelegate
		{
			private const string CellIdentifier = "ProdCell2";
			private ProductTableDataSource DataSource;

			public ProductTableSinglesDelegate(ProductTableDataSource datasource)
			{
				this.DataSource = datasource;
			}

			public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
			{
				NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);

				if (view == null)
				{
					view = new NSTextField();
					view.Identifier = CellIdentifier;
					view.BackgroundColor = NSColor.Clear;
					view.Bordered = false;
					view.Selectable = false;
					view.Editable = false;
				}

				switch (tableColumn.Title)
				{
					case "V_START_DATE":
						if (DataSource.Vouchers[(int)row].startDate.ToString() != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].startDate.ToString();
						} else
						{
							view.StringValue = "";
						}

						 
						break;

					case "V_END_DATE":
						if (DataSource.Vouchers[(int)row].endDate.ToString() != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].endDate.ToString();
						} else
						{
							view.StringValue = "";
						}
						break;

					case "V_DURATION":
						if (DataSource.Vouchers[(int)row].duration != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].duration;
						} else
						{
							view.StringValue = "";
						}
						break;

					case "H_ID":
						if (DataSource.Vouchers[(int)row].hId != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].hId;
						}
						else
						{
							view.StringValue = "";
						}
						break;

					case "TOF_ID":
						if (DataSource.Vouchers[(int)row].tofId != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].tofId;
						}
						else
						{
							view.StringValue = "";
						}
						break;

					case "AS_ID":
						if (DataSource.Vouchers[(int)row].asId != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].asId;
						}
						else
						{
							view.StringValue = "";
						}
						break;

					case "E_ID":
						if (DataSource.Vouchers[(int)row].eId != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].eId;
						}
						else
						{
							view.StringValue = "";
						}
						break;

					case "V_RESERVATION_MARK":
						if (DataSource.Vouchers[(int)row].reservationMark != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].reservationMark;
						}
						else
						{
							view.StringValue = "";
						}
						break;

					case "V_PAYMENT_MARK":
						if (DataSource.Vouchers[(int)row].paymentMark != null)
						{
							view.StringValue = DataSource.Vouchers[(int)row].paymentMark;
						}
						else
						{
							view.StringValue = "";
						}
						break;
				}

				return view;
			}
		}

		public class BitTypes : NSComboBoxDataSource
		{
			readonly List<string> source;

			public BitTypes(List<string> source)
			{
				this.source = source;
			}

			public override string CompletedString(NSComboBox comboBox, string uncompletedString)
			{
				return source.Find(n => n.StartsWith(uncompletedString, StringComparison.InvariantCultureIgnoreCase));
			}

			public override nint IndexOfItem(NSComboBox comboBox, string value)
			{
				return source.FindIndex(n => n.Equals(value, StringComparison.InvariantCultureIgnoreCase));
			}

			public override nint ItemCount(NSComboBox comboBox)
			{
				return source.Count;
			}

			public override NSObject ObjectValueForItem(NSComboBox comboBox, nint index)
			{
				return NSObject.FromObject(source[(int)index]);
			}
		}


		//GlobalVariables
		DataBase DBObject = new DataBase();
		public static List<string> bitTypes = new List<string>(new string[] { "V_START_DATE", "V_END_DATE", "V_DURATION", "H_ID", "TOF_ID", "AS_ID", "E_ID", "V_RESERVATION_MARK", "V_PAYMENT_"});

		//MainView
		public VouchersTableViewController (IntPtr handle) : base (handle)
		{
		}
		
		//Events
		public override void ViewWillAppear()
		{
			base.ViewWillAppear();
			var DataSource = new ProductTableDataSource();
			SqlCommand command = new SqlCommand("SELECT * FROM Vouchers", DBObject.connection);
			DBObject.OpenConnection();
			Console.WriteLine("Loading start data...");

			

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Vouchers voucher = new Vouchers();
					
					voucher.startDate = reader[0].ToString();
					voucher.endDate = reader[1].ToString();
					voucher.duration = reader[2].ToString();
					voucher.hId = reader[3].ToString();
					voucher.tofId = reader[4].ToString();
					voucher.asId = reader[5].ToString();
					voucher.eId = reader[6].ToString();
					voucher.reservationMark = reader[7].ToString();
					voucher.paymentMark = reader[8].ToString();

					DataSource.Vouchers.Add(voucher);

				}

				vouchersMainTableView.DataSource = DataSource;
				vouchersMainTableView.Delegate = new ProductTableDelegate(DataSource);

				filterComboBox.UsesDataSource = true;
				filterComboBox.DataSource = new BitTypes(bitTypes);
				filterComboBox.SelectItem(0);

			}

			Console.WriteLine("Loaded!");
		}

		partial void findClicked(NSButton sender)
		{
			FindData();
		}

		private void FindData()
		{
			Console.WriteLine("Find Data");

			var DataSource = new ProductTableDataSource();
			string stringCommand;

			if (searchTextField.StringValue == "")
			{
				stringCommand = String.Format("SELECT * FROM Vouchers");
			}
			else
			{
				stringCommand = String.Format("SELECT * FROM Vouchers WHERE {0} {1}", filterComboBox.StringValue, searchTextField.StringValue);
			}


				
			SqlCommand command = new SqlCommand(stringCommand, DBObject.connection);

			using (SqlDataReader reader = command.ExecuteReader())
			{
				//bool finded = false;
				while (reader.Read())
				{
					Vouchers voucher = new Vouchers();

					voucher.startDate = reader[0].ToString();
					voucher.endDate = reader[1].ToString();
					voucher.duration = reader[2].ToString();
					voucher.hId = reader[3].ToString();
					voucher.tofId = reader[4].ToString();
					voucher.asId = reader[5].ToString();
					voucher.eId = reader[6].ToString();
					voucher.reservationMark = reader[7].ToString();
					voucher.paymentMark = reader[8].ToString();

                    //if (Convert.ToString(voucher.startDate) == searchTextField.StringValue
                    //	|| Convert.ToString(voucher.endDate) == searchTextField.StringValue
                    //	|| voucher.duration == searchTextField.StringValue
                    //	|| voucher.hId == searchTextField.StringValue
                    //	|| voucher.tofId == searchTextField.StringValue
                    //	|| voucher.asId == searchTextField.StringValue
                    //	|| voucher.eId == searchTextField.StringValue
                    //	|| voucher.reservationMark == searchTextField.StringValue
                    //	|| voucher.paymentMark == searchTextField.StringValue)
                    //{
                    //	finded = true;
                    DataSource.Vouchers.Add(voucher);
					//}

				}

				//if (finded)
				//{
				vouchersMainTableView.DataSource = DataSource;
				vouchersMainTableView.Delegate = new ProductTableDelegate(DataSource);
				//}
			}

			Console.WriteLine("Loaded!");

		}

		partial void showClicked(NSButton sender)
		{
			ShowAllData();
		}

		private void ShowAllData()
		{
			Console.WriteLine("Show All Data");

			var DataSource = new ProductTableDataSource();

			SqlCommand command = new SqlCommand("SELECT * FROM Vouchers", DBObject.connection);

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Vouchers voucher = new Vouchers();

					voucher.startDate = reader[0].ToString();
					voucher.endDate = reader[1].ToString();
					voucher.duration = reader[2].ToString();
					voucher.hId = reader[3].ToString();
					voucher.tofId = reader[4].ToString();
					voucher.asId = reader[5].ToString();
					voucher.eId = reader[6].ToString();
					voucher.reservationMark = reader[7].ToString();
					voucher.paymentMark = reader[8].ToString();
					DataSource.Vouchers.Add(voucher);

				}

				vouchersMainTableView.DataSource = DataSource;
				vouchersMainTableView.Delegate = new ProductTableDelegate(DataSource);

			}

			Console.WriteLine("Loaded!");

		}

		partial void filterClicked(NSButton sender)
		{
			FilterData();
		}

		private void FilterData()
		{
			Console.WriteLine("Filter Data");

			var DataSource = new ProductTableDataSource();

			string stringCommand = String.Format("SELECT {0} FROM Vouchers", filterComboBox.StringValue);

			SqlCommand command = new SqlCommand(stringCommand, DBObject.connection);

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Vouchers voucher = new Vouchers();

					switch (filterComboBox.StringValue)
                    {
						case "V_START_DATE":
							voucher.startDate = reader[0].ToString();
							break;
						case "V_END_DATE":
							voucher.endDate = reader[0].ToString();
							break;
						case "V_DURATION":
							voucher.duration = reader[0].ToString();
							break;
						case "H_ID":
							voucher.hId = reader[0].ToString();
							break;
						case "TOF_ID":
							voucher.tofId = reader[0].ToString();
							break;
						case "AS_ID":
							voucher.asId = reader[0].ToString();
							break;
						case "E_ID":
							voucher.eId = reader[0].ToString();
							break;
						case "V_RESERVATION_MARK":
							voucher.reservationMark = reader[0].ToString();
							break;
						case "V_PAYMENT_":
							voucher.paymentMark = reader[0].ToString();
							break;
						default:
							break;


					}
					
					DataSource.Vouchers.Add(voucher);

				}

				vouchersMainTableView.DataSource = DataSource;
				vouchersMainTableView.Delegate = new ProductTableSinglesDelegate(DataSource);

			}

			Console.WriteLine("Loaded!");

		}




	}
}