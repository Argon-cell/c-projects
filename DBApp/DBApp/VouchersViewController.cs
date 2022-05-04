// This file has been autogenerated from a class added in the UI designer.

using System;
using AppKit;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBApp.Models;
using Foundation;

namespace DBApp
{
	public partial class VouchersViewController : NSViewController
	{
		//Model
		public class Vouchers
		{
			public DateTime startDate { get; set; }
			public DateTime endDate { get; set; }
			public string duration { get; set; }
			public string hId { get; set; }
			public string tofId { get; set; }
			public string asId { get; set; }
			public string eId { get; set; }
			public string reservationMark { get; set; }
			public string paymentMark { get; set; }
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


		//Methods
		public NSDate ToNsDate(DateTime dateTime)
		{
			if (dateTime.Kind == DateTimeKind.Unspecified)
			{
				dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
			}
			return (NSDate)dateTime;
		}

		public DateTime ToDateTime(NSDate date)
		{
			NSCalendar calendar = new NSCalendar(NSCalendarType.Gregorian) { TimeZone = NSTimeZone.FromGMT(NSTimeZone.LocalTimeZone.GetSecondsFromGMT) };
			NSDateComponents components = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day | NSCalendarUnit.Hour | NSCalendarUnit.Minute | NSCalendarUnit.Second | NSCalendarUnit.Calendar, date);

			return new DateTime((int)components.Year, (int)components.Month, (int)components.Day, (int)components.Hour, (int)components.Minute, (int)components.Second);
		}


		//GlobalVariables
		int currentPage = 0;
		List<Vouchers> vouchers = new List<Vouchers>();
		DataBase DBObject = new DataBase();
		public static List<string> bitTypes = new List<string>(new string[] { "0", "1" });


		//Main Controller
		public VouchersViewController(IntPtr handle) : base(handle)
		{
		}


		//Events
		public override void ViewWillAppear()
		{
			base.ViewWillAppear();

			SqlCommand command = new SqlCommand("SELECT * FROM Vouchers", DBObject.connection);
			DBObject.OpenConnection();
			Console.WriteLine("Loading start data...");

			using (SqlDataReader reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Vouchers voucher = new Vouchers();
					voucher.startDate = Convert.ToDateTime(reader[0]);
					voucher.endDate = Convert.ToDateTime(reader[1]);
					voucher.duration = reader[2].ToString();
					voucher.hId = reader[3].ToString();
					voucher.tofId = reader[4].ToString();
					voucher.asId = reader[5].ToString();
					voucher.eId = reader[6].ToString();
					voucher.reservationMark = reader[7].ToString();
					voucher.paymentMark = reader[8].ToString();
					vouchers.Add(voucher);
				}
			}

			startDateDatePicker.DateValue = ToNsDate(vouchers[0].startDate);
			endDateDatePicker.DateValue = ToNsDate(vouchers[0].endDate);
			durationTextField.StringValue = vouchers[0].duration;
			hIdTextField.StringValue = vouchers[0].hId;
			tofIdTextField.StringValue = vouchers[0].tofId;
			asIdTextField.StringValue = vouchers[0].asId;
			clientIdTextField.StringValue = vouchers[0].eId;

			reservationMarkComboBox.UsesDataSource = true;
			reservationMarkComboBox.DataSource = new BitTypes(bitTypes);
			reservationMarkComboBox.SelectItem(Convert.ToInt32(vouchers[0].reservationMark));

			payementMarkComboBox.UsesDataSource = true;
			payementMarkComboBox.DataSource = new BitTypes(bitTypes);
			payementMarkComboBox.SelectItem(Convert.ToInt32(vouchers[0].paymentMark));

			Console.WriteLine("Loaded!");
		}


		//Buttons and their actions
		partial void FirstClicked(NSButton sender)
		{
			FirstData();
		}

		private void FirstData()
		{
			Console.WriteLine("First Data");
			currentPage = 0;

			startDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].startDate);
			endDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].endDate);
			durationTextField.StringValue = vouchers[currentPage].duration;
			hIdTextField.StringValue = vouchers[currentPage].hId;
			tofIdTextField.StringValue = vouchers[currentPage].tofId;
			asIdTextField.StringValue = vouchers[currentPage].asId;
			clientIdTextField.StringValue = vouchers[currentPage].eId;

			reservationMarkComboBox.UsesDataSource = true;
			reservationMarkComboBox.DataSource = new BitTypes(bitTypes);
			reservationMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].reservationMark));

			payementMarkComboBox.UsesDataSource = true;
			payementMarkComboBox.DataSource = new BitTypes(bitTypes);
			payementMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].paymentMark));

		}

		partial void NextClicked(NSButton sender)
		{
			NextData();
		}

		private void NextData()
		{
			Console.WriteLine("Next Data");
			if (currentPage + 1 < vouchers.Count) {
				currentPage += 1;
			}

			startDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].startDate);
			endDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].endDate);
			durationTextField.StringValue = vouchers[currentPage].duration;
			hIdTextField.StringValue = vouchers[currentPage].hId;
			tofIdTextField.StringValue = vouchers[currentPage].tofId;
			asIdTextField.StringValue = vouchers[currentPage].asId;
			clientIdTextField.StringValue = vouchers[currentPage].eId;

			reservationMarkComboBox.UsesDataSource = true;
			reservationMarkComboBox.DataSource = new BitTypes(bitTypes);
			reservationMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].reservationMark));

			payementMarkComboBox.UsesDataSource = true;
			payementMarkComboBox.DataSource = new BitTypes(bitTypes);
			payementMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].paymentMark));


		}

		partial void PastClicked(NSButton sender)
		{
			PastData();
		}

		private void PastData()
		{
			Console.WriteLine("Past Data");

			if (currentPage - 1 >= 0)
			{
				currentPage -= 1;
			}

			startDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].startDate);
			endDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].endDate);
			durationTextField.StringValue = vouchers[currentPage].duration;
			hIdTextField.StringValue = vouchers[currentPage].hId;
			tofIdTextField.StringValue = vouchers[currentPage].tofId;
			asIdTextField.StringValue = vouchers[currentPage].asId;
			clientIdTextField.StringValue = vouchers[currentPage].eId;

			reservationMarkComboBox.UsesDataSource = true;
			reservationMarkComboBox.DataSource = new BitTypes(bitTypes);
			reservationMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].reservationMark));

			payementMarkComboBox.UsesDataSource = true;
			payementMarkComboBox.DataSource = new BitTypes(bitTypes);
			payementMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].paymentMark));

		}

		partial void LastClicked(NSButton sender)
		{
			LastData();
		}

		private void LastData()
		{
			Console.WriteLine("Last Data");
			currentPage = vouchers.Count - 1;

			startDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].startDate);
			endDateDatePicker.DateValue = ToNsDate(vouchers[currentPage].endDate);
			durationTextField.StringValue = vouchers[currentPage].duration;
			hIdTextField.StringValue = vouchers[currentPage].hId;
			tofIdTextField.StringValue = vouchers[currentPage].tofId;
			asIdTextField.StringValue = vouchers[currentPage].asId;
			clientIdTextField.StringValue = vouchers[currentPage].eId;

			reservationMarkComboBox.UsesDataSource = true;
			reservationMarkComboBox.DataSource = new BitTypes(bitTypes);
			reservationMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].reservationMark));

			payementMarkComboBox.UsesDataSource = true;
			payementMarkComboBox.DataSource = new BitTypes(bitTypes);
			payementMarkComboBox.SelectItem(Convert.ToInt32(vouchers[currentPage].paymentMark));


		}

		partial void SaveClicked(NSButton sender)
		{
			SaveData();
		}

		private void SaveData()
		{
			Console.WriteLine("Save Data");

			string stringCommand = string.Format("UPDATE Vouchers SET V_START_DATE = '{0}', V_END_DATE = '{1}', V_DURATION = N'{2}', H_ID = {3}, TOF_ID = {4}, AS_ID = {5}, E_ID = {6}, V_RESERVATION_MARK = {7}, V_PAYMENT_MARK = {8} WHERE V_START_DATE = '{9}' AND V_END_DATE = '{10}' AND V_DURATION = N'{11}' AND H_ID = {12} AND TOF_ID = {13} AND AS_ID = {14} AND E_ID = {15} AND V_RESERVATION_MARK = {16} AND V_PAYMENT_MARK = {17}", ToDateTime(startDateDatePicker.DateValue), ToDateTime(endDateDatePicker.DateValue), durationTextField.StringValue, hIdTextField.StringValue, tofIdTextField.StringValue, asIdTextField.StringValue, clientIdTextField.StringValue, reservationMarkComboBox.StringValue, payementMarkComboBox.StringValue, vouchers[currentPage].startDate, vouchers[currentPage].endDate, vouchers[currentPage].duration, vouchers[currentPage].hId, vouchers[currentPage].tofId, vouchers[currentPage].asId, vouchers[currentPage].eId, vouchers[currentPage].reservationMark, vouchers[currentPage].paymentMark);

			SqlCommand command = new SqlCommand(stringCommand, DBObject.connection);
			command.ExecuteNonQuery();

			vouchers[currentPage].startDate = ToDateTime(startDateDatePicker.DateValue);
			vouchers[currentPage].endDate = ToDateTime(startDateDatePicker.DateValue);
			vouchers[currentPage].duration = durationTextField.StringValue;
			vouchers[currentPage].hId = hIdTextField.StringValue;
			vouchers[currentPage].tofId = tofIdTextField.StringValue;
			vouchers[currentPage].asId = asIdTextField.StringValue;
			vouchers[currentPage].eId = clientIdTextField.StringValue;
			vouchers[currentPage].reservationMark = reservationMarkComboBox.StringValue;
			vouchers[currentPage].paymentMark = payementMarkComboBox.StringValue;
		}

		partial void DeleteClicked(NSButton sender)
		{
			DeleteData();
		}

		private void DeleteData()
		{
			Console.WriteLine("Delete Data");


			string stringCommand = string.Format("DELETE FROM Vouchers WHERE V_START_DATE = '{9}' AND V_END_DATE = '{10}' AND V_DURATION = N'{11}' AND H_ID = {12} AND TOF_ID = {13} AND AS_ID = {14} AND E_ID = {15} AND V_RESERVATION_MARK = {16} AND V_PAYMENT_MARK = {17}", ToDateTime(startDateDatePicker.DateValue), ToDateTime(endDateDatePicker.DateValue), durationTextField.StringValue, hIdTextField.StringValue, tofIdTextField.StringValue, asIdTextField.StringValue, clientIdTextField.StringValue, reservationMarkComboBox.StringValue, payementMarkComboBox.StringValue, vouchers[currentPage].startDate, vouchers[currentPage].endDate, vouchers[currentPage].duration, vouchers[currentPage].hId, vouchers[currentPage].tofId, vouchers[currentPage].asId, vouchers[currentPage].eId, vouchers[currentPage].reservationMark, vouchers[currentPage].paymentMark);

			SqlCommand command = new SqlCommand(stringCommand, DBObject.connection);
			command.ExecuteNonQuery();


			vouchers.Remove(vouchers[currentPage]);
			FirstData();


		}


	}
}
