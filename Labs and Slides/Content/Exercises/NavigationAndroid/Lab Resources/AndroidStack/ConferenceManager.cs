using System;
using System.Json;
using System.IO;
using System.Collections.Generic;
using System.Text;
using EvolveTabs.Model;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;

namespace EvolveTabs
{
	/// <summary>
	/// This class is responsible for 
	/// </summary>
	public class ConferenceManager
	{
		private Context _context;

		public ConferenceManager(Context context)
		{
			_context = context;
			Sessions = new Dictionary<int, Session>();
			Speakers = new Dictionary<int, Speaker>();
		}

		/// <summary>
		/// A collection of all the sessions at the conference.
		/// </summary>
		/// <value>The sessions.</value>
		public  Dictionary<int, Session> Sessions { get; set; }

		/// <summary>
		/// A collection of all the speakers at the conference.
		/// </summary>
		/// <value>The speakers.</value>
		public Dictionary<int, Speaker> Speakers { get; set; }

		/// <summary>
		/// Copies the contents of one Steam to another. Closes both streams when finished.
		/// </summary>
		/// <param name="readStream">The Steam we want to copy data from.</param>
		/// <param name="writeStream">The Stream we want to copy data to.</param>
		private void ReadWriteStream(Stream readStream, Stream writeStream)
		{
			int Length = 256;
			Byte[] buffer = new Byte[Length];
			int bytesRead = readStream.Read(buffer, 0, Length);
			// write the required bytes
			while (bytesRead > 0)
			{
				writeStream.Write(buffer, 0, bytesRead);
				bytesRead = readStream.Read(buffer, 0, Length);
			}
			readStream.Close();
			writeStream.Close();
		}


	}
}

